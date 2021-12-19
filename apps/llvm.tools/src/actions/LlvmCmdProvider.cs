//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public partial class LlvmCmdProvider : AppCmdProvider<LlvmCmdProvider>
    {
        LlvmDataImporter DataImporter => Service(Wf.LlvmDataImporter);

        LlvmToolset Toolset => Service(Wf.LLvmToolset);

        LlvmPaths LlvmPaths => Service(Wf.LlvmPaths);

        LlvmProjectCollector ProjectCollector => Service(Wf.LlvmProjectCollector);

        LlvmRepo LlvmRepo => Service(Wf.LlvmRepo);

        LlvmReadObjSvc ReadObj => Service(Wf.LlvmReadObj);

        LlvmDataProvider DataProvider => Service(Wf.LlvmDataProvider);

        LlvmDataEmitter DataEmitter => Service(Wf.LlvmDataEmitter);

        LlvmCodeGen CodeGen => Service(Wf.LlvmCodeGen);

        LlvmConfigSvc LlvmConfig => Service(Wf.LlvmConfig);
    }
}