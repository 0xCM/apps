//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static ProjectScriptNames;
    using static WsAtoms;

    partial class AsmCmdService
    {
        [CmdOp(".build")]
        Outcome BuildProject(CmdArgs args)
            => WsProjects.RunProjectScript(State.Project(), Build);

        [CmdOp(".c-ast")]
        Outcome DumpCAst(CmdArgs args)
            => WsProjects.RunProjectScript(State.Project(),args, DumpAst, c);

        [CmdOp(".c-layouts")]
        Outcome CLayoutDump(CmdArgs args)
            => WsProjects.RunProjectScript(State.Project(), args, DumpLayouts, c);
    }
}