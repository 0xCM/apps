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

        ApiCode ApiCode => Wf.ApiCode();

        Runtime Runtime => Wf.Runtime();

        public void Run()
        {
            var parts = ApiPartCapture.create(Wf);
            var dst = ApiPacks.create();
            parts.Capture(dst);
            Runtime.EmitContext(dst);
            CliEmitter.Emit(CliEmitOptions.@default(), dst);
        }

        public void Run2()
        {
            var parts = ApiPartCapture.create(Wf);
            var dst = ApiPacks.create();
            parts.Capture2(dst);
            Runtime.EmitContext(dst);
            CliEmitter.Emit(CliEmitOptions.@default(), dst);

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
                Run2();
        }

        public void Run(ApiHostUri src)
        {
            using var symbols = Dispense.composite();
            Run(symbols, src);
        }

        void Run(ICompositeDispenser symbols, ApiHostUri src)
        {
            var collected = ApiCode.Collect(src);
            ApiCode.EmitHex(collected, CodeFiles.HexPath(src));
            ApiCode.EmitCsv(collected, CodeFiles.CsvPath(src));
            EmitAsm(symbols, src, collected);
        }

        void Run(ICompositeDispenser symbols, IPart src)
        {
            var collected = ApiCode.Collect(symbols,src);
            ApiCode.EmitHex(collected, CodeFiles.HexPath(src.Id));
            ApiCode.EmitCsv(collected, CodeFiles.CsvPath(src.Id));
            EmitAsm(symbols, src.Id, collected);
        }

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

        ReadOnlySeq<AsmRoutine> EmitAsm(ICompositeDispenser symbols, ApiHostUri host, ReadOnlySeq<CollectedEncoding> src)
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