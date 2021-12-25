//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Gen;

    partial class AsmCmdService
    {
        Generators Generators => Service(Wf.Generators);

        [CmdOp(".gen-shell")]
        Outcome GenShell(CmdArgs args)
        {
            var result = Outcome.Success;
            var gen = Generators.Shells();
            var spec = new ShellSpec("z0.shell", "zsh0");
            var dst = Ws.Gen().OutDir();
            gen.Generate(spec,dst);
            return result;
        }
    }
}