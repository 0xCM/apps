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

        ProjectManager ProjectCollector => Service(Wf.ProjectManager);

        LlvmRepo LlvmRepo => Service(Wf.LlvmRepo);

        LlvmReadObjSvc ReadObj => Service(Wf.LlvmReadObj);

        LlvmDataProvider DataProvider => Service(Wf.LlvmDataProvider);

        LlvmDataEmitter DataEmitter => Service(Wf.LlvmDataEmitter);

        LlvmCodeGen LlvmCodeGen => Service(Wf.LlvmCodeGen);

        LlvmConfigSvc LlvmConfig => Service(Wf.LlvmConfig);

        Generators Generators => Service(Wf.Generators);
    }
}