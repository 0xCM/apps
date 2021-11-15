//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ToolScript
    {
        public ToolId Tool {get;}

        public ScriptId Script {get;}

        public CmdVars Vars {get;}

        [MethodImpl(Inline)]
        public ToolScript(ToolId tool, ScriptId script, CmdVars vars)
        {
            Tool = tool;
            Script = script;
            Vars = vars;
        }
    }
}