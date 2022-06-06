//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    using static XedImport;

    [ApiHost]
    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
            public IntelSdm IntelSdm(IWfRuntime wf)
                => Service<IntelSdm>(wf);

            public XedImport XedImport(IWfRuntime wf, XedRuntime xed)
                => Service<XedImport>(wf).With(xed);

            public XedRules XedRules(IWfRuntime wf, XedRuntime xed)
                => Service<XedRules>(wf).With(xed);

            public XedOps XedOps(IWfRuntime wf, XedRuntime xed)
                => Service<XedOps>(wf).With(xed);

            public XedDb XedDb(IWfRuntime wf, XedRuntime xed)
                => Service<XedDb>(wf).With(xed);

            public XedDisasmSvc XedDisasm(IWfRuntime wf, XedRuntime xed)
                => Service<XedDisasmSvc>(wf).With(xed);

            public XedDisasm XedDisasm2(IWfRuntime wf, XedRuntime xed)
                => Service<XedDisasm>(wf).With(xed);

            public XedDocs XedDocs(IWfRuntime wf, XedRuntime xed)
                => Service<XedDocs>(wf).With(xed);

            public AsmTables AsmTables(IWfRuntime wf)
                => Service<AsmTables>(wf);

            public XedTool XedTool(IWfRuntime wf)
                => Service<XedTool>(wf);

            public XedPaths XedPaths(IWfRuntime wf)
                => Z0.XedPaths.Service;

            public CpuIdSvc CpuId(IWfRuntime wf)
                => Service<CpuIdSvc>(wf);

            public InstBlockImporter BlockImporter(IWfRuntime wf)
                => Service<InstBlockImporter>(wf);

            public IntelSdmPaths SdmPaths(IWfRuntime wf)
                => Service<IntelSdmPaths>(wf);

            public ApiResPackEmitter ResPackEmitter(IWfRuntime wf)
                => Service<ApiResPackEmitter>(wf);

            public DumpBin DumpBin(IWfRuntime wf)
                => Service<DumpBin>(wf);

            public AsmDocs AsmDocs(IWfRuntime wf)
                => Service<AsmDocs>(wf);

            public AsmOpCodes AsmOpCodes(IWfRuntime wf)
                => Service<AsmOpCodes>(wf);

            public X86Dispatcher X86Dispatcher(IWfRuntime wf)
                => Service<X86Dispatcher>(wf);

            public AsmChecks AsmChecks(IWfRuntime wf)
                => Service<AsmChecks>(wf);

            public XedDisasm.Analyzer DisasmAnalyzer(IWfRuntime wf)
                => Service<XedDisasm.Analyzer>(wf);

            public NasmCatalog NasmCatalog(IWfRuntime wf)
                => Service<NasmCatalog>(wf);

            public AsmCoreCmd AsmCoreCmd(IWfRuntime wf)
                => Service<AsmCoreCmd>(wf);

            public Nasm Nasm(IWfRuntime wf)
                => Service<Nasm>(wf);

            public NDisasm NDisasm(IWfRuntime wf)
                => Service<NDisasm>(wf);
        }

        static Svc Services => Svc.Instance;

        public static IntelSdm IntelSdm(this IWfRuntime wf)
            => Services.IntelSdm(wf);

        public static XedRuntime XedRuntime(this IWfRuntime wf)
            => GlobalSvc.Instance.Service<XedRuntime>(wf);

        public static XedImport XedImport(this IWfRuntime wf, XedRuntime xed)
            => Services.XedImport(wf, xed);

        public static XedRules XedRules(this IWfRuntime wf, XedRuntime xed)
            => Services.XedRules(wf, xed);

        public static XedOps XedOps(this IWfRuntime wf, XedRuntime xed)
            => Services.XedOps(wf, xed);

        public static XedDb XedDb(this IWfRuntime wf, XedRuntime xed)
            => Services.XedDb(wf, xed);

        public static XedDisasmSvc XedDisasm(this IWfRuntime wf, XedRuntime xed)
            => Services.XedDisasm(wf, xed);

        public static XedDocs XedDocs(this IWfRuntime wf, XedRuntime xed)
            => Services.XedDocs(wf, xed);

        public static InstBlockImporter BlockImporter(this IWfRuntime wf)
            => Services.BlockImporter(wf);

        public static AsmTables AsmTables(this IWfRuntime wf)
            => Services.AsmTables(wf);

        public static XedDisasm.Analyzer DisasmAnalyser(this IWfRuntime wf)
            => Services.DisasmAnalyzer(wf);

        public static XedTool XedTool(this IWfRuntime wf)
            => Services.XedTool(wf);

        public static XedPaths XedPaths(this IWfRuntime wf)
            => Services.XedPaths(wf);

        public static CpuIdSvc CpuId(this IWfRuntime wf)
            => Services.CpuId(wf);

        public static ApiResPackEmitter ResPackEmitter(this IWfRuntime wf)
            => Services.ResPackEmitter(wf);

        public static AsmCodeGen AsmCodeGen(this IWfRuntime wf)
            => Services.Service<AsmCodeGen>(wf);

        public static AsmDocs AsmDocs(this IWfRuntime wf)
            => Services.AsmDocs(wf);

        public static DumpBin DumpBin(this IWfRuntime wf)
            => Services.DumpBin(wf);

        public static AsmOpCodes AsmOpCodes(this IWfRuntime wf)
            => Services.AsmOpCodes(wf);

        public static IntelSdmPaths SdmPaths(this IWfRuntime wf)
            => Services.SdmPaths(wf);

        public static X86Dispatcher X86Dispatcher(this IWfRuntime wf)
            => Services.X86Dispatcher(wf);

        public static AsmChecks AsmChecks(this IWfRuntime wf)
            => Services.AsmChecks(wf);

        public static NasmCatalog NasmCatalog(this IWfRuntime wf)
            => Services.NasmCatalog(wf);

        public static AsmCoreCmd AsmCoreCmd(this IWfRuntime wf)
            => Services.AsmCoreCmd(wf);

        public static Nasm Nasm(this IWfRuntime wf)
            => Services.Nasm(wf);

        public static NDisasm NDisasm(this IWfRuntime wf)
            => Services.NDisasm(wf);

        public static StanfordAsmCatalog StanfordCatalog(this IWfRuntime wf)
            => Asm.StanfordAsmCatalog.create(wf);

        public static StanfordFormPipe AsmFormPipe(this IWfRuntime wf)
            => Asm.StanfordFormPipe.create(wf);

   }
}