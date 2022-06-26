//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static ApiGranules;

    public partial class LlvmCmd : AppCmdService<LlvmCmd>
    {
        LlvmDataImporter Importer => Wf.LlvmDataImporter();

        new LlvmPaths Paths => Wf.LlvmPaths();

        WsArchive WsArchive => new WsArchive(AppDb.LlvmRoot(), "llvm");

        LlvmDataProvider DataProvider => Wf.LlvmDataProvider();

        LlvmDataEmitter DataEmitter => Wf.LlvmDataEmitter();

        LlvmCodeGen CodeGen => Wf.LlvmCodeGen();

        LlvmConfigSvc Config => Wf.LlvmConfig();

        LlvmQuery Query => DataEmitter.Query;

        ToolId SelectedTool;

        FS.Files TdFiles()
            => DbArchive.filter(Paths.LlvmRoot, FS.ext(td)).Files().Array();

        public LlvmCmd()
        {
            SelectedTool = ToolId.Empty;
        }
    }
}