//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ToolCmdDef : ICmdDef
    {
        public Name CmdName {get;}

        public Actor Tool {get;}

        public FS.FilePath ExePath {get;}

        public ToolCmdArgs Args {get;}
    }
}