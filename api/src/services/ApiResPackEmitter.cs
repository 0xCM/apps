//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static CodeGenerator;
    using static core;

    public sealed class ApiResPackEmitter : AppService<ApiResPackEmitter>
    {
        FS.FolderPath SourceDir
            => Db.PartSrcDir("respack") + FS.folder("content") + FS.folder("bytes");

        protected override void OnInit()
        {
        }

        public ReadOnlySpan<ApiHostRes> Emit()
        {
            return Emit(Wf.ApiHex().ReadBlocks().Storage);
        }

        void RunScripts()
        {
            var runner = Wf.ScriptRunner();
            var build = runner.RunControlScript(ControlScripts.BuildRespack);
            iter(build, line => Wf.Row(line));
            var pack = runner.RunControlScript(ControlScripts.PackRespack);
            iter(pack, line => Wf.Row(line));
        }

        public ReadOnlySpan<ApiHostRes> Emit(ReadOnlySpan<ApiCodeBlock> blocks)
            => Emit(blocks, SourceDir);

        public ReadOnlySpan<ApiHostRes> Emit(ReadOnlySpan<ApiCodeBlock> blocks, FS.FolderPath dst)
            => Emit(ApiCodeBlocks.hosted(blocks), dst);

        ReadOnlySpan<ApiHostRes> Emit(ReadOnlySpan<ApiHostBlocks> src, FS.FolderPath dst)
        {
            var flow = Running();
            var count = src.Length;
            var counter = 0u;
            var buffer = alloc<ApiHostRes>(count);
            dst.Clear();

            ref var target = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                seek(target,i) = Emit(skip(src,i), dst);
                counter += seek(target,i).Count;
            }

            RunScripts();

            Ran(flow);

            return buffer;
        }

        // ReadOnlySpan<ApiHostRes> Emit(ApiBlockIndex index, FS.FolderPath dst)
        // {
        //     var emissions = list<ApiHostRes>();
        //     var flow = Running();
        //     dst.Clear();
        //     foreach(var host in index.NonemptyHosts)
        //     {
        //         var emitted = Emit(index.HostCodeBlocks(host), dst);
        //         emissions.Add(emitted);
        //     }
        //     Ran(flow);
        //     return emissions.ViewDeposited();
        // }

        ApiHostRes Emit(in ApiHostBlocks src, FS.FolderPath dst)
        {
            var target = dst + ApiFiles.filename(src.Host, FS.Cs);
            var flow = EmittingFile(target);
            var emission = Emit(src, target);
            EmittedFile(flow, emission.Count);
            return emission;
        }

        ApiHostRes Emit(in ApiHostBlocks src, FS.FilePath target)
        {
            if(empty(src.Host.HostName))
            {
                Warn(string.Format("Cannot emit {0} because host name is undefined", target.ToUri()));
                return ApiHostRes.Empty;
            }

            var resources = SpanRes.hostres(src);
            var hostname = src.Host.HostName.ReplaceAny(array('.'), '_');
            var typename = string.Concat(src.Host.Part.Format(), Chars.Underscore, hostname);
            var members = hashset<string>();
            using var writer = target.Writer();
            EmitFileHeader(writer);
            OpenFileNamespace(writer, "Z0.ByteCode");
            EmitUsingStatements(writer);
            DeclareStaticClass(writer, typename);
            for(var i=0; i<resources.Count; i++)
            {
                ref readonly var res = ref resources[i];
                if(!members.Contains(res.Identifier))
                {
                    EmitMember(writer, bytespan(res));
                    members.Add(res.Identifier);
                }
            }
            CloseTypeDeclaration(writer);
            CloseFileNamespace(writer);
            return resources;
        }
    }
}