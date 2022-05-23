//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public partial class LlvmCmdProvider : AppCmdProvider<LlvmCmdProvider>
    {
        LlvmDataImporter Importer => Service(Wf.LlvmDataImporter);

        LlvmToolset Toolset => Service(Wf.LLvmToolset);

        AppServices AppSvc => Service(Wf.AppServices);

        new LlvmPaths Paths => Service(Wf.LlvmPaths);

        LlvmRepo Repo => Service(Wf.LlvmRepo);

        LlvmReadObjSvc ReadObj => Service(Wf.LlvmReadObj);

        LlvmDataProvider DataProvider => Service(Wf.LlvmDataProvider);

        LlvmDataEmitter DataEmitter => Service(Wf.LlvmDataEmitter);

        LlvmCodeGen CodeGen => Service(Wf.LlvmCodeGen);

        LlvmConfigSvc Config => Service(Wf.LlvmConfig);

        LlvmQuery Query => DataEmitter.Query;

        LlvmCmd LlvmCmd;

        ToolId SelectedTool;

        FS.Files TdFiles()
            => FileArchives.filtered(Paths.LlvmRoot, FS.ext("td")).Files().Array();

        public LlvmCmdProvider()
        {
            SelectedTool = ToolId.Empty;
        }

        public static LlvmCmdProvider create(IWfRuntime wf, LlvmCmd cmd)
            => create(wf).With(cmd);

        LlvmCmdProvider With(LlvmCmd cmd)
        {
            LlvmCmd = cmd;
            return this;
        }
    }
}