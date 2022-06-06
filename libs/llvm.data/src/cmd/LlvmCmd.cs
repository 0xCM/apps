//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public partial class LlvmCmd : AppCmdService<LlvmCmd>
    {
        LlvmDataImporter Importer => Wf.LlvmDataImporter();

        LlvmToolset Toolset => Wf.LLvmToolset();

        new LlvmPaths Paths => Wf.LlvmPaths();

        LlvmRepo Repo => Wf.LlvmRepo();

        LlvmDataProvider DataProvider => Wf.LlvmDataProvider();

        LlvmDataEmitter DataEmitter => Wf.LlvmDataEmitter();

        LlvmCodeGen CodeGen => Wf.LlvmCodeGen();

        LlvmDataCalcs Calcs => Wf.LlvmDataCalcs();

        LlvmConfigSvc Config => Wf.LlvmConfig();

        LlvmQuery Query => DataEmitter.Query;

        ToolId SelectedTool;

        FS.Files TdFiles()
            => FileArchives.filtered(Paths.LlvmRoot, FS.ext("td")).Files().Array();

        public LlvmCmd()
        {
            SelectedTool = ToolId.Empty;
        }
    }
}