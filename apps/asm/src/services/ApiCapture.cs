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

        public void Run()
        {
            using var symbols = Alloc.dispenser(Alloc.symbols);
            var parts = ApiRuntimeCatalog.Parts.Index();
            iter(parts, part => Run(symbols,part), true);
        }

        void Run(SymbolDispenser symbols, IPart part)
        {
            var id = part.Id;
            var collected = ApiCode.Collect(symbols,part).Sort();
            var size = ApiCode.EmitHex(collected, ApiCodeFiles.HexPath(id));
            var records = ApiCode.EmitCsv(collected, ApiCodeFiles.CsvPath(id));
            var asm = EmitAsm(symbols, id, collected);
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
    }
}