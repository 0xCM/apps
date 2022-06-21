//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ToolScript
    {
        public readonly ToolId Tool;

        public readonly ScriptId Script;

        public readonly CmdVars Vars;

        [MethodImpl(Inline)]
        public ToolScript(ToolId tool, ScriptId script, CmdVars vars)
        {
            Tool = tool;
            Script = script;
            Vars = vars;
        }
    }
}