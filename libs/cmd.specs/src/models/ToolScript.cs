//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ToolScript
    {
        public readonly ToolId Tool {get;}

        public readonly ScriptId Script {get;}

        public readonly CmdVars Vars {get;}

        [MethodImpl(Inline)]
        public ToolScript(ToolId tool, ScriptId script, CmdVars vars)
        {
            Tool = tool;
            Script = script;
            Vars = vars;
        }
    }
}