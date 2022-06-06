//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public partial class LlvmCmdProvider : AppCmdService<LlvmCmdProvider>
    {
        LlvmDataImporter Importer => Service(Wf.LlvmDataImporter);

        LlvmToolset Toolset => Service(Wf.LLvmToolset);

        new LlvmPaths Paths => Service(Wf.LlvmPaths);

        LlvmRepo Repo => Service(Wf.LlvmRepo);

        LlvmReadObjSvc ReadObj => Service(Wf.LlvmReadObj);

        LlvmDataProvider DataProvider => Wf.LlvmDataProvider();

        LlvmDataEmitter DataEmitter => Wf.LlvmDataEmitter();

        LlvmCodeGen CodeGen => Service(Wf.LlvmCodeGen);

        LlvmDataCalcs Calcs => Wf.LlvmDataCalcs();

        LlvmConfigSvc Config => Service(Wf.LlvmConfig);

        LlvmQuery Query => DataEmitter.Query;

        ToolId SelectedTool;

        FS.Files TdFiles()
            => FileArchives.filtered(Paths.LlvmRoot, FS.ext("td")).Files().Array();

        public LlvmCmdProvider()
        {
            SelectedTool = ToolId.Empty;
        }
    }
}