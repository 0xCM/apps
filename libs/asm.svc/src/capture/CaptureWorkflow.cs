//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public partial class CaptureWorkflow : IRunnable<CaptureWorkflow.CaptureSettings>
    {
        readonly IWfRuntime Wf;

        readonly IWfSvc Svc;

        readonly IApiPack Target;

        public readonly CaptureSettings Settings;

        public CaptureWorkflow(IWfSvc svc, CaptureSettings settings)
        {
            Svc = svc;
            Wf = svc.Wf;
            Settings = settings;
            Target = ApiPacks.create();
        }

        CaptureSettings IRunnable<CaptureSettings>.Settings
            => Settings;

        ApiMd ApiMd => Wf.ApiMd();

        IApiCatalog Catalog => ApiMd.Catalog;

        CliEmitter CliEmitter => Wf.CliEmitter();

        Runtime Runtime => Wf.Runtime();

        ApiPacks ApiPacks => Wf.ApiPacks();

        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiCode ApiCode => Wf.ApiCode();

        public void Run()
        {
            using var dispenser = Dispense.composite();
            var hosts = Capture(Target, dispenser);
            var members = ApiQuery.members(hosts.SelectMany(x => x.Resolved.Members).Where(x => x != null).Array());
            var rebased = catalog(members);
            Svc.TableEmit(rebased, Target.Table<ApiCatalogEntry>(), UTF8);
            ApiMd.EmitDatasets(Target);
            CliEmitter.Emit(CliEmitOptions.@default(), Target);
            Runtime.EmitContext(Target);
            ApiPacks.Link(Target);
        }

        void RedirectEmissions(IApiPack dst)
            => Wf.RedirectEmissions(Loggers.emission(ExecutingPart.Component, dst.Path("capture.emissions", FileKind.Csv)));

        public CollectedHosts Capture(IApiPack dst)
        {
            RedirectEmissions(dst);
            using var dispenser = Dispense.composite();
            return Capture(Catalog, dispenser, dst);
        }

        public CollectedHosts Capture(IApiPack dst, ICompositeDispenser dispenser)
        {
            RedirectEmissions(dst);
            return Capture(Catalog, dispenser, dst);
        }

        public CollectedHosts Capture(IApiCatalog src, ICompositeDispenser dispenser, IApiPack dst)
        {
            var buffer = bag<CollectedHost>();
            iter(src.PartCatalogs(),
                part => {
                    var _bag = bag<CollectedHost>();
                    ApiCode.gather(part, Svc.Wf.EventLog, dispenser, _bag);
                    var code = _bag.ToArray();
                    ApiCode.Emit(part.PartId, code, dst);
                    EmitAsm(dispenser, code, dst);
                    iter(_bag, x => buffer.Add(x));
                },
            Settings.PllExec);

            return buffer.ToIndex();
        }

        void EmitAsm(ICompositeDispenser symbols, ReadOnlySeq<CollectedHost> src, IApiPack dst)
        {
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var host = ref src[i];
                var path = dst.AsmExtractPath(host.Host);
                var flow = Svc.EmittingFile(path);
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
                Svc.EmittedFile(flow, AppMsg.EmittedBytes.Capture(size,path));
            }
        }
    }
}