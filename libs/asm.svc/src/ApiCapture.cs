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

        ApiCode ApiCode => Wf.ApiCode();

        Runtime Runtime => Wf.Runtime();

        public void Run()
        {
            var parts = ApiPartCapture.create(Wf);
            var ts = core.timestamp();
            using var observer = RuntimeObservers.MethodLoad.observe(AppDb.App().Path($"clr.events.methodload.{ts}", FileKind.Csv));
            //using var log = OpenEventLog(ts);
            parts.Capture(ts);
            //Runtime.EmitContext(ts);
        }

        public void Run(PartId id)
        {
            if(ApiRuntimeCatalog.FindPart(id, out var src))
            {
                using var symbols = Dispense.composite();
                Run(symbols, src);
            }
        }

        ClrEventListener OpenEventLog(Timestamp ts)
            => ClrEventListener.create(AppDb.App().Path($"clr.events.{ts}", FileKind.Log));

        public void Run(CmdArgs args)
        {
            if(args.Count != 0)
            {
                var spec = text.trim(ShellCmd.arg(args,0).Value);
                var i = text.index(spec, Chars.FSlash);
                if(i>0)
                    Run(ApiHostUri.define(ApiParsers.part(text.left(spec,i)), text.right(spec,i)));
                else
                    Run(ApiParsers.part(spec));
            }
            else
                Run();
        }

        public void Run(ApiHostUri src)
        {
            using var symbols = Dispense.composite();
            Run(symbols, src);
        }

        void Run(ICompositeDispenser symbols, ApiHostUri src)
        {
            var collected = ApiCode.Collect(src);
            var size = ApiCode.EmitHex(collected, CodeFiles.HexPath(src));
            var csv = ApiCode.EmitCsv(collected, CodeFiles.CsvPath(src));
            var asm = EmitAsm(symbols, src, collected);
        }

        void Run(ICompositeDispenser symbols, IPart src)
        {
            var collected = ApiCode.Collect(symbols,src).Sort();
            var size = ApiCode.EmitHex(collected, CodeFiles.HexPath(src.Id));
            var csv = ApiCode.EmitCsv(collected, CodeFiles.CsvPath(src.Id));
            var asm = EmitAsm(symbols, src.Id, collected);
        }

        Index<AsmRoutine> EmitAsm(ICompositeDispenser symbols, PartId part, Index<CollectedEncoding> src)
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

        Index<AsmRoutine> EmitAsm(ICompositeDispenser symbols, ApiHostUri host, Index<CollectedEncoding> src)
        {
            var dst = alloc<AsmRoutine>(src.Count);
            var emitter = text.emitter();
            for(var i=0; i<src.Count; i++)
            {
                var routine = AsmDecoder.Decode(src[i]);
                seek(dst,i) = routine;
                emitter.AppendLine(routine.AsmRender(routine));
            }

            FileEmit(emitter.Emit(), src.Count, CodeFiles.AsmPath(host));
            return dst;
        }
    }
}