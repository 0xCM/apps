//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ToolCmdDef : CmdDef<ToolCmdDef>
    {
        public override CmdKind CmdKind
            => CmdKind.ToolCmd;

        public asci32 CmdName {get;}

        public ToolId Tool {get;}

        public FS.FilePath ExePath {get;}

        public ToolCmdArgs Args {get;}
    }
}