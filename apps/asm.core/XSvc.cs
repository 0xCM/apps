//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    sealed class ServiceCache : ServiceCache<ServiceCache>
    {


    }

    [ApiHost]
    public static class XSvc
    {
        static ServiceCache Svc = new();

        static AsmCmdRt runtime(IWfRuntime wf, Index<ICmdProvider> providers, bool start = true)
        {
            var runtime = Z0.AsmCmdRt.create(wf);
            runtime.XedRt = XedRuntime.create(wf);
            runtime.CmdSvc = AsmCoreCmd.create(wf, runtime, providers);
            if(start)
                runtime.Xed.Start();
            return runtime;
        }

        public static AsmCmdRt AsmCmdRt(this IWfRuntime wf, Index<ICmdProvider> providers, bool start = true)
            => Svc.Service<AsmCmdRt>(wf, _ => runtime(wf, providers, start));

        public static AsmCmdRt AsmCmdRt(this IWfRuntime wf, bool start = true)
            => Svc.Service<AsmCmdRt>(wf, _ => runtime(wf, sys.empty<ICmdProvider>(), start));

        [Op]
        public static IntelSdm IntelSdm(this IWfRuntime wf)
            => Svc.Service<IntelSdm>(wf);

        [Op]
        public static XedImport XedImport(this IWfRuntime wf, XedRuntime xed)
            => Svc.Service<XedImport>(wf).With(xed);

        [Op]
        public static XedRules XedRules(this IWfRuntime wf, XedRuntime xed)
            => Svc.Service<XedRules>(wf).With(xed);

        [Op]
        public static XedDb XedDb(this IWfRuntime wf, XedRuntime xed)
            => Svc.Service<XedDb>(wf).With(xed);

        [Op]
        public static XedDisasmSvc XedDisasm(this IWfRuntime wf, XedRuntime xed)
            => Svc.Service<XedDisasmSvc>(wf).With(xed);

        public static XedDocs XedDocs(this IWfRuntime wf, XedRuntime xed)
            => Svc.Service<XedDocs>(wf).With(xed);

        [Op]
        public static XedTool XedTool(this IWfRuntime wf)
            => Svc.Service<XedTool>(wf);

        [Op]
        public static XedPaths XedPaths(this IWfRuntime wf)
            => Z0.XedPaths.Service;

        [Op]
        public static CpuIdSvc CpuId(this IWfRuntime wf)
            => Svc.Service<CpuIdSvc>(wf);

        [Op]
        public static AsmCodeGen AsmCodeGen(this IWfRuntime wf)
            => Svc.Service<AsmCodeGen>(wf);

        [Op]
        public static ApiResPackEmitter ResPackEmitter(this IWfRuntime wf)
            => Z0.ApiResPackEmitter.create(wf);

        [Op]
        public static AsmDocs AsmDocs(this IWfRuntime wf)
            => Asm.AsmDocs.create(wf);

        [Op]
        public static DumpBin DumpBin(this IWfRuntime wf)
            => Z0.DumpBin.create(wf);
        [Op]
        public static ApiDataPaths ApiDataPaths(this IWfRuntime wf)
            => Z0.ApiDataPaths.create(wf);

        [Op]
        public static ApiCodeBanks ApiCodeBanks(this IWfRuntime wf)
            => Z0.ApiCodeBanks.create(wf);

        [Op]
        public static AsmObjects AsmObjects(this IWfRuntime wf)
            => Z0.AsmObjects.create(wf);

        [Op]
        public static AsmOpCodes AsmOpCodes(this IWfRuntime context)
            => Asm.AsmOpCodes.create(context);

        public static ProcessAsmBuffers ProcessAsmBuffers(this IWfRuntime wf)
            => Asm.ProcessAsmBuffers.create(wf);

        [Op]
        public static IntelSdmPaths SdmPaths(this IWfRuntime wf)
            => Asm.IntelSdmPaths.create(wf);

        [Op]
        public static NasmCatalog NasmCatalog(this IWfRuntime wf)
            => Asm.NasmCatalog.create(wf);

        [Op]
        public static StanfordAsmCatalog StanfordCatalog(this IWfRuntime wf)
            => Asm.StanfordAsmCatalog.create(wf);

        [Op]
        public static StanfordFormPipe AsmFormPipe(this IWfRuntime wf)
            => Asm.StanfordFormPipe.create(wf);

        [Op]
        public static Nasm Nasm(this IWfRuntime wf)
            => Z0.Nasm.create(wf);

        [Op]
        public static NDisasm NDisasm(this IWfRuntime wf)
            => Z0.NDisasm.create(wf);

        [Op]
        public static CoffServices CoffServices(this IWfRuntime wf)
            => Svc.Service<CoffServices>(wf);

        [Op]
        public static AsmTables AsmTables(this IWfRuntime wf)
            => Svc.Service<AsmTables>(wf);

        public static EncodingCollector EncodingCollector(this IWfRuntime wf)
            => Svc.Service<EncodingCollector>(wf);
   }
}