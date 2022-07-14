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

        Runtime Runtime => Wf.Runtime();

        public void Run()
        {
            var parts = ApiPartCapture.create(Wf);
            var dst = AppDb.apipack();
            parts.Capture(dst);
            CliEmitter.Emit(CliEmitOptions.@default(), dst);
            Runtime.EmitContext(dst);
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