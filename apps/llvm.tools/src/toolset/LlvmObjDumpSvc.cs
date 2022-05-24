//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    [Tool(ToolId)]
    public sealed class LlvmObjDumpSvc : ToolService<LlvmObjDumpSvc>
    {
        public const string ToolId = ToolNames.llvm_objdump;

        WsProjects Projects => Service(Wf.WsProjects);

        public LlvmObjDumpSvc()
            : base(ToolId)
        {

        }

        public Outcome Run(FS.FilePath src, FS.FolderPath dst)
        {
            var tool = ToolNames.llvm_objdump;
            var cmd = Cmd.cmdline(Ws.Tools().Script(tool, "run").Format(PathSeparator.BS));
            var vars = WsVars.create();
            vars.DstDir = dst;
            vars.SrcDir = src.FolderPath;
            vars.SrcFile = src.FileName;
            var result = OmniScript.Run(cmd, vars.ToCmdVars(), out var response);
            if(result)
            {
               var items = CmdResponse.parse(response);
               iter(items, item => Write(item));
            }
            return result;
        }
    }
}