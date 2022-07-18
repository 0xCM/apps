//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public class ApiCapture : WfSvc<ApiCapture>
    {
        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiCodeFiles CodeFiles => Wf.ApiCodeFiles();

        CliEmitter CliEmitter => Wf.CliEmitter();

        ApiCatalogs ApiCatalogs => Wf.ApiCatalogs();

        ApiPacks ApiPacks => Wf.ApiPacks();

        Runtime Runtime => Wf.Runtime();

        ApiMd ApiMd => Wf.ApiMetadata();

        public static MemoryHeap heap(FS.FilePath src)
        {
            var dst = alloc<byte>(src.Size);
            using var reader = src.AsciLineReader();
            var line = AsciLineCover.Empty;
            var offset = 0u;
            var result = true;
            while(reader.Next(out line) && result)
            {
                var data = line.Codes;
                var i = SQ.index(data, Chars.Space);
                if(i > 0)
                {
                    result = Hex.parse(SQ.left(data,i), out ulong a);
                    result &= Hex.parse(SQ.right(data,i), ref offset, dst);
                }

            }
            return default;
        }

        public void Run(IApiPack dst)
        {
            var parts = ApiPartCapture.create(Wf);
            var captured = parts.Capture(dst);
            var members = ApiMembers.create(captured.SelectMany(x => x.Resolved.Members).Array());
            // ApiCatalogs.Rebase(members,dst);
            ApiMd.EmitDatasets(dst);
            CliEmitter.Emit(CliEmitOptions.@default(), dst);
            Runtime.EmitContext(dst);
            ApiPacks.Link(dst);
        }

        ClrEventListener OpenEventLog(Timestamp ts)
            => ClrEventListener.create(AppDb.App().Path($"clr.events.{ts}", FileKind.Log));

        ReadOnlySeq<AsmRoutine> EmitAsm(ICompositeDispenser symbols, PartId part, ReadOnlySeq<CollectedEncoding> src)
        {
            var dst = alloc<AsmRoutine>(src.Count);
            var emitter = text.emitter();
            for(var i=0; i<src.Count; i++)
            {
                var routine = AsmDecoder.Decode(src[i]);
                seek(dst,i) = routine;
                emitter.AppendLine(routine.AsmRender(routine));
            }

            FileEmit(emitter.Emit(), src.Count, CodeFiles.AsmPath(part));
            return dst;
        }
    }
}