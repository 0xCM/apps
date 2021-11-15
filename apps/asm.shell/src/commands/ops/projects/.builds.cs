//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static ProjectScriptNames;
    using static WsAtoms;
    using static Root;

    partial class AsmCmdService
    {
        [CmdOp(".build")]
        Outcome BuildProject(CmdArgs args)
            => RunProjectScript(State.Project(), Build);

        [CmdOp(".c-ast")]
        Outcome DumpCAst(CmdArgs args)
            => RunProjectScript(args, DumpAst, c);

        [CmdOp(".c-layouts")]
        Outcome CLayoutDump(CmdArgs args)
            => RunProjectScript(args, DumpLayouts, c);

        [CmdOp(".cpp-build-run")]
        Outcome BuildRunCpp(CmdArgs args)
        {
            var result = Outcome.Success;
            var home = State.Project().Home();
            result = OmniScript.RunProjectScript(home, arg(args,0).Value, CppBuild, false, out var flows);
            if(result.Fail)
                return result;
            return RunExe(flows);
         }

        [CmdOp(".c-build-run")]
        Outcome BuildRunC(CmdArgs args)
        {
            var result = Outcome.Success;
            var home = State.Project().Home();
            result = OmniScript.RunProjectScript(home, arg(args,0).Value, CBuild, false, out var flows);
            if(result.Fail)
                return result;

            return RunExe(flows);
        }
    }
}