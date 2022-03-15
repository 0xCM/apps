//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    using static XedRules;

    [ApiHost]
    public static class XSvc
    {
        [Op]
        public static ApiResPackEmitter ResPackEmitter(this IWfRuntime wf)
            => Z0.ApiResPackEmitter.create(wf);

        [Op]
        public static RuleTables XedRuleTables(this IWfRuntime wf)
            => RuleTables.create(wf);

        [Op]
        public static XedCmdProvider XedCommands(this IWfRuntime wf)
            => XedCmdProvider.create(wf);

        [Op]
        public static AsmDocs AsmDocs(this IWfRuntime wf)
            => Asm.AsmDocs.create(wf);

        [Op]
        public static DumpBin DumpBin(this IWfRuntime wf)
            => Z0.DumpBin.create(wf);

        [Op]
        public static FileCatalog FileCatalog(this IProjectWs src)
            => Z0.FileCatalog.load(src);

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
        public static ApiAssets ApiAssets(this IWfRuntime wf)
            => Z0.ApiAssets.create(wf);

        [Op]
        public static WsProjects WsProjects(this IWfRuntime wf)
            => Z0.WsProjects.create(wf);

        [Op]
        public static IntelSdm IntelSdm(this IWfRuntime wf)
            => Asm.IntelSdm.create(wf);

        [Op]
        public static IntelIntrinsicSvc IntelIntrinsics(this IWfRuntime wf)
            => Asm.IntelIntrinsicSvc.create(wf);

        [Op]
        public static XedRules XedRules(this IWfRuntime wf)
            => Z0.XedRules.create(wf);

        [Op]
        public static IntelXed IntelXed(this IWfRuntime wf)
            => Asm.IntelXed.create(wf);

        public static XedDisasmSvc XedDisasm(this IWfRuntime wf)
            => Z0.XedDisasmSvc.create(wf);

        [Op]
        public static XedTool XedTool(this IWfRuntime wf)
            => Z0.XedTool.create(wf);

        [Op]
        public static XedTypes XedTypeProvider(this IWfRuntime wf)
            => Z0.XedTypes.create(wf);

        [Op]
        public static XedPaths XedPaths(this IWfRuntime wf)
            => Z0.XedPaths.create(wf);

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
            => Z0.CoffServices.create(wf);

        [Op]
        public static AsmTables AsmTables(this IWfRuntime wf)
            => Asm.AsmTables.create(wf);

        public static EncodingCollector EncodingCollector(this IWfRuntime wf)
            => Z0.EncodingCollector.create(wf);

        public static Parsers Parsers(this IWfRuntime wf)
            => Z0.Parsers.create(wf);
   }
}