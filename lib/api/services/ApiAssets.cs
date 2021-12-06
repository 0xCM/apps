//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.IO;
    using System.Collections.Generic;

    using static core;

    public sealed class ApiAssets : AppService<ApiAssets>
    {
        public Outcome EmitMsil(CmdArgs args)
        {
            var result = Outcome.Success;
            var catalog = Service(ApiRuntimeLoader.catalog);
             var  hosts = catalog.ApiHosts;

            // if(args.Length != 0)
            // {
            //     result = ApiParsers.host(arg(args,0), out var uri);
            //     if(result.Ok)
            //     {
            //         result = catalog.FindHost(uri, out var host);
            //         if(result.Ok)
            //             hosts = array(host);
            //     }
            // }
            Write(string.Format("Emitting msil for {0} hosts", hosts.Length));

            //result = EmitMsil(hosts);
            return result;
        }

        // Outcome EmitMsil(ReadOnlySpan<IApiHost> hosts)
        // {
        //     var result = Outcome.Success;
        //     var catalog = Service(ApiRuntimeLoader.catalog);
        //     var buffer = text.buffer();
        //     var jit = Wf.ApiJit();
        //     var pipe = Wf.MsilPipe();
        //     var counter = 0u;
        //     for(var i=0; i<hosts.Length; i++)
        //     {
        //         ref readonly var host = ref skip(hosts, i);
        //         var members = jit.JitHost(host).View;
        //         var count = members.Length;
        //         if(count == 0)
        //             continue;

        //         var dst = MsilOutPath(host.HostUri);
        //         var flow = EmittingFile(dst);

        //         for(var j=0; j<count; j++)
        //         {
        //             ref readonly var member = ref members[j];
        //             ref readonly var msil = ref member.Msil;
        //             pipe.RenderCode(msil, buffer);
        //             counter++;
        //         }

        //         using var writer = dst.UnicodeWriter();
        //         writer.Write(buffer.Emit());
        //         EmittedFile(flow, count);
        //     }

        //     return result;
        // }

        // Outcome EmitMsil(ReadOnlySpan<ApiHostUri> hosts)
        // {
        //     var result = Outcome.Success;
        //     var catalog = Service(ApiRuntimeLoader.catalog);
        //     var buffer = text.buffer();
        //     var pipe = Wf.MsilPipe();
        //     for(var i=0; i<hosts.Length; i++)
        //     {
        //         ref readonly var uri = ref skip(hosts,i);
        //         result = catalog.FindHost(uri, out var host);
        //         if(result.Fail)
        //         {
        //             result = (false, AppMsg.HostNotFound.Format(uri));
        //             break;
        //         }

        //         var members = Wf.ApiJit().JitHost(host);
        //         var count = members.Count;
        //         for(var j=0; j<count; j++)
        //             pipe.RenderCode(members[j].Msil, buffer);

        //         var dst = MsilOutPath(uri);
        //         var flow = EmittingFile(dst);
        //         using var writer = dst.UnicodeWriter();
        //         writer.Write(buffer.Emit());
        //         EmittedFile(flow, count);
        //     }

        //     return result;
        // }

        FS.FilePath MsilOutPath(ApiHostUri uri)
            => Ws.Project("db").Subdir("api/msil") + FS.hostfile(uri, FS.Il);

        public Index<ResEmission> Run(EmitResDataCmd cmd)
            => EmitEmbedded(cmd.Source, cmd.Target, cmd.Match, cmd.ClearTarget);

        public Index<ResEmission> EmitAssetContent()
        {
            var outer = Wf.Running("Emitting reference data");
            var components = Wf.ApiCatalog.Components;
            var descriptors = Resources.descriptors(components).SelectMany(x => x.Storage).View;
            var count = descriptors.Length;
            var root = Db.RefDataRoot();
            var emissions = sys.alloc<ResEmission>(count);
            for(var i=0; i<count; i++)
            {
                try
                {
                    ref var emission = ref seek(emissions,i);
                    ref readonly var descriptor = ref skip(descriptors,i);
                    emission = Emit(descriptor, root);
                }
                catch(Exception e)
                {
                    Wf.Error(e);
                }
            }
            Wf.Ran(outer, string.Format("Emitted <{0}> reference files", count));
            return emissions;
        }

        void Emit(ReadOnlySpan<Assembly> src, StreamWriter dst, List<DocLibEntry> entries)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                entries.AddRange(Emit(skip(src,i),dst));
        }

        static Index<DocLibEntry> entries(Assembly src)
        {
            var names = @readonly(src.GetManifestResourceNames());
            var count = names.Length;
            var buffer = alloc<DocLibEntry>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(dst,i) =new DocLibEntry(skip(names,i), Path.GetExtension(skip(names,i)));
            return buffer;
        }

        Index<DocLibEntry> Emit(Assembly src, StreamWriter dst)
        {
            var _entries = entries(src);
            Emit(_entries, dst);
            return _entries;
        }

        uint Emit(ReadOnlySpan<DocLibEntry> entries, StreamWriter dst)
        {
            var count = (uint)entries.Length;
            var formatter = Tables.formatter<DocLibEntry>(82);
            for(var i=0u; i<count; i++)
                dst.WriteLine(formatter.Format(skip(entries, i)));
            return count;
        }

        public Index<ResEmission> EmitEmbedded(Assembly src, FS.FolderPath root, utf8 match, bool clear)
        {
            var flow = Wf.Running(string.Format("Emitting resources embedded in {0}", src.GetSimpleName()));
            var descriptors = match.IsEmpty ? Resources.descriptors(src) : Resources.descriptors(src, match);
            var count = descriptors.ResourceCount;

            if(count == 0)
                Wf.Warn(Msg.NoMatchingResources.Format(src, match));
            else
                Wf.Status(Msg.EmittingResources.Format(src, count));

            var buffer = sys.alloc<ResEmission>(count);
            ref var emission = ref first(buffer);

            if(clear)
                root.Clear();

            var invalid = Path.GetInvalidPathChars();
            var sources = descriptors.View;
            for(var i=0; i<count; i++)
            {
                ref readonly var descriptor = ref skip(sources,i);
                var size = descriptor.Size;
                seek(emission,i) = Emit(descriptor, root);
                Wf.Status($"Emitted {emission.Target}");
            }

            Wf.Ran(flow);
            return buffer;
        }

        public ResEmission Emit(in Asset src, FS.FolderPath root)
        {
            var invalid = Path.GetInvalidPathChars();
            var name =  src.Name.ToString().ReplaceAny(invalid, Chars.Underscore);
            var target = root + FS.file(name);
            var flow = Wf.EmittingFile(target);
            var utf = Resources.utf8(src);
            using var writer = target.Writer();
            writer.Write(utf);
            Wf.EmittedFile(flow,1);
            return flows.arrow(src,target);
        }
    }

    partial struct Msg
    {

    }
}