//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public class ApiCapture : AppService<ApiCapture>
    {
        AppSvcOps AppSvc => Wf.AppSvc();

        AsmDecoder AsmDecoder => Service(Wf.AsmDecoder);

        ApiCodeFiles ApiCodeFiles => Wf.ApiCodeFiles();

        ApiCode ApiCode => Wf.ApiCode();

        ApiMd ApiMd => Wf.ApiMetadata();

        public void Run()
        {
            using var symbols = Alloc.dispenser(Alloc.symbols);

            iter(ApiMd.Parts, part => Run(symbols,part), true);
        }

        public void Run(PartId id)
        {
            if(ApiRuntimeCatalog.FindPart(id, out var src))
            {
                using var symbols = Alloc.dispenser(Alloc.symbols);
                Run(symbols, src);
            }
        }

        public void Run(CmdArgs args)
        {
            if(args.Count != 0)
            {
                var spec = text.trim(AppCmd.arg(args,0).Value.Format());
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
            using var symbols = Alloc.dispenser(Alloc.symbols);
            Run(symbols, src);
        }

        void Run(SymbolDispenser symbols, ApiHostUri src)
        {
            var collected = ApiCode.Collect(src);
            var size = ApiCode.EmitHex(collected, ApiCodeFiles.HexPath(src));
            var csv = ApiCode.EmitCsv(collected, ApiCodeFiles.CsvPath(src));
            var asm = EmitAsm(symbols, src, collected);
        }

        void Run(SymbolDispenser symbols, IPart src)
        {
            var collected = ApiCode.Collect(symbols,src).Sort();
            var size = ApiCode.EmitHex(collected, ApiCodeFiles.HexPath(src.Id));
            var csv = ApiCode.EmitCsv(collected, ApiCodeFiles.CsvPath(src.Id));
            var asm = EmitAsm(symbols, src.Id, collected);
        }

        Index<AsmRoutine> EmitAsm(SymbolDispenser symbols, PartId part, Index<CollectedEncoding> src)
        {
            var dst = alloc<AsmRoutine>(src.Count);
            var emitter = text.emitter();
            for(var i=0; i<src.Count; i++)
            {
                var routine = AsmDecoder.Decode(src[i]);
                seek(dst,i) = routine;
                emitter.AppendLine(routine.AsmRender(routine));
            }

            AppSvc.FileEmit(emitter.Emit(), src.Count, ApiCodeFiles.AsmPath(part));
            return dst;
        }

        Index<AsmRoutine> EmitAsm(SymbolDispenser symbols, ApiHostUri host, Index<CollectedEncoding> src)
        {
            var dst = alloc<AsmRoutine>(src.Count);
            var emitter = text.emitter();
            for(var i=0; i<src.Count; i++)
            {
                var routine = AsmDecoder.Decode(src[i]);
                seek(dst,i) = routine;
                emitter.AppendLine(routine.AsmRender(routine));
            }

            AppSvc.FileEmit(emitter.Emit(), src.Count, ApiCodeFiles.AsmPath(host));
            return dst;
        }
    }
}