//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    using static XedImport;

    sealed class ServiceCache : AppServices<ServiceCache>
    {
        static AsmCmdRt runtime(IWfRuntime wf, Index<ICmdProvider> providers, bool start = true)
        {
            var runtime = Z0.AsmCmdRt.create(wf);
            runtime.XedRt = XedRuntime.create(wf);
            runtime.CmdSvc = AsmCoreCmd.create(wf, runtime, providers);
            if(start)
                runtime.Xed.Start();
            return runtime;
        }

        public IntelSdm IntelSdm(IWfRuntime wf)
            => Service<IntelSdm>(wf);

        public XedImport XedImport(IWfRuntime wf, XedRuntime xed)
            => Service<XedImport>(wf).With(xed);

        public XedRules XedRules(IWfRuntime wf, XedRuntime xed)
            => Service<XedRules>(wf).With(xed);

        public XedDb XedDb(IWfRuntime wf, XedRuntime xed)
            => Service<XedDb>(wf).With(xed);

        public XedDisasmSvc XedDisasm(IWfRuntime wf, XedRuntime xed)
            => Service<XedDisasmSvc>(wf).With(xed);

        public XedDocs XedDocs(IWfRuntime wf, XedRuntime xed)
            => Service<XedDocs>(wf).With(xed);

        public AsmCmdRt AsmCmdRt(IWfRuntime wf, Index<ICmdProvider> providers, bool start = true)
            => Service<AsmCmdRt>(wf, _ => runtime(wf, providers, start));

        public AsmCmdRt AsmCmdRt(IWfRuntime wf, bool start = true)
            => Service<AsmCmdRt>(wf, _ => runtime(wf, sys.empty<ICmdProvider>(), start));

        public CoffServices CoffServices(IWfRuntime wf)
            => Service<CoffServices>(wf);

        public AsmTables AsmTables(IWfRuntime wf)
            => Service<AsmTables>(wf);

        public AsmObjects AsmObjects(IWfRuntime wf)
            => Service<AsmObjects>(wf);

        public XedTool XedTool(IWfRuntime wf)
            => Service<XedTool>(wf);

        public XedPaths XedPaths(IWfRuntime wf)
            => Z0.XedPaths.Service;

        public CpuIdSvc CpuId(IWfRuntime wf)
            => Service<CpuIdSvc>(wf);

        public InstBlockImporter BlockImporter(IWfRuntime wf)
            => Service<InstBlockImporter>(wf);

    }

    [ApiHost]
    public static class XSvc
    {
        static ServiceCache Services => ServiceCache.Instance;

        public static AsmCmdRt AsmCmdRt(this IWfRuntime wf, Index<ICmdProvider> providers, bool start = true)
            => Services.AsmCmdRt(wf,providers,start);

        public static AsmCmdRt AsmCmdRt(this IWfRuntime wf, bool start = true)
            => Services.AsmCmdRt(wf, start);

        public static IntelSdm IntelSdm(this IWfRuntime wf)
            => Services.IntelSdm(wf);

        public static XedImport XedImport(this IWfRuntime wf, XedRuntime xed)
            => Services.XedImport(wf, xed);

        public static XedRules XedRules(this IWfRuntime wf, XedRuntime xed)
            => Services.XedRules(wf, xed);

        public static XedDb XedDb(this IWfRuntime wf, XedRuntime xed)
            => Services.XedDb(wf, xed);

        public static XedDisasmSvc XedDisasm(this IWfRuntime wf, XedRuntime xed)
            => Services.XedDisasm(wf, xed);

        public static XedDocs XedDocs(this IWfRuntime wf, XedRuntime xed)
            => Services.XedDocs(wf, xed);

        public static InstBlockImporter BlockImporter(this IWfRuntime wf)
            => Services.BlockImporter(wf);

        public static CoffServices CoffServices(this IWfRuntime wf)
            => Services.CoffServices(wf);

        public static AsmTables AsmTables(this IWfRuntime wf)
            => Services.AsmTables(wf);

        public static AsmObjects AsmObjects(this IWfRuntime wf)
            => Services.AsmObjects(wf);

        public static XedTool XedTool(this IWfRuntime wf)
            => Services.XedTool(wf);

        public static XedPaths XedPaths(this IWfRuntime wf)
            => Services.XedPaths(wf);

        public static CpuIdSvc CpuId(this IWfRuntime wf)
            => Services.CpuId(wf);

        public static ApiResPackEmitter ResPackEmitter(this IWfRuntime wf)
            => Z0.ApiResPackEmitter.create(wf);

        public static AsmCodeGen AsmCodeGen(this IWfRuntime wf)
            => Services.Service<AsmCodeGen>(wf);

        public static AsmDocs AsmDocs(this IWfRuntime wf)
            => Asm.AsmDocs.create(wf);

        public static DumpBin DumpBin(this IWfRuntime wf)
            => Z0.DumpBin.create(wf);

        public static ApiCodeBanks ApiCodeBanks(this IWfRuntime wf)
            => Z0.ApiCodeBanks.create(wf);

        public static AsmOpCodes AsmOpCodes(this IWfRuntime context)
            => Asm.AsmOpCodes.create(context);

        public static ProcessAsmBuffers ProcessAsmBuffers(this IWfRuntime wf)
            => Asm.ProcessAsmBuffers.create(wf);

        public static IntelSdmPaths SdmPaths(this IWfRuntime wf)
            => Asm.IntelSdmPaths.create(wf);

        public static NasmCatalog NasmCatalog(this IWfRuntime wf)
            => Asm.NasmCatalog.create(wf);

        public static StanfordAsmCatalog StanfordCatalog(this IWfRuntime wf)
            => Asm.StanfordAsmCatalog.create(wf);

        public static StanfordFormPipe AsmFormPipe(this IWfRuntime wf)
            => Asm.StanfordFormPipe.create(wf);

        public static Nasm Nasm(this IWfRuntime wf)
            => Z0.Nasm.create(wf);

        public static NDisasm NDisasm(this IWfRuntime wf)
            => Z0.NDisasm.create(wf);
   }
}