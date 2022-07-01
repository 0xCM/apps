//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ToolScript
    {
        public readonly IToolWs Ws;

        public readonly Actor Tool;

        public readonly ScriptId Script;

        public readonly CmdVars Vars;

        [MethodImpl(Inline)]
        public ToolScript(IToolWs ws, Actor tool, ScriptId script, CmdVars vars)
        {
            Ws = ws;
            Tool = tool;
            Script = script;
            Vars = vars;
        }

        public FS.FilePath Path()
            => Ws.ScriptDir() + FS.file(Script.Id, FileKind.Cmd);
    }
}