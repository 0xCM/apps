//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    class ApiPartCapture : WfSvc<ApiPartCapture>
    {
        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiCode ApiCode => Wf.ApiCode();

        void RedirectEmissions(IApiPack dst)
            => Wf.RedirectEmissions(Loggers.emission(ExecutingPart.Component, dst.Path("capture.emissions", FileKind.Csv)));

        public CollectedHosts Capture(IApiPack dst)
        {
            RedirectEmissions(dst);
            using var dispenser = Dispense.composite();
            return Capture(ApiRuntimeCatalog, dispenser, true, dst);

        }

        public CollectedHosts Capture(IApiCatalog src, ICompositeDispenser dispenser, bool pll, IApiPack dst)
        {
            var buffer = bag<CollectedHost>();
            iter(src.PartCatalogs(),
                part => {
                    var code = ApiCode.collect(part, EventLog, dispenser);
                    ApiCode.Emit(part.PartId, code, dst);
                    EmitAsm(dispenser, code, dst);
                },
            pll);

            return buffer.ToIndex().Sort();
        }

        void EmitAsm(ICompositeDispenser symbols, ReadOnlySeq<CollectedHost> src, IApiPack dst)
        {
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var host = ref src[i];
                var path = dst.AsmExtractPath(host.Host);
                var flow = EmittingFile(path);
                var size = ByteSize.Zero;
                using var writer = path.AsciWriter();
                for(var j=0; j<host.Blocks.Count; j++)
                {
                    ref readonly var blocks = ref host.Blocks[j];
                    var routine = AsmDecoder.Decode(blocks);
                    var asm = routine.AsmRender(routine);
                    size += (ulong)asm.Length;
                    writer.AppendLine(asm);
                }
                EmittedFile(flow, AppMsg.EmittedBytes.Capture(size,path));
            }
        }
    }
}