//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IActionRunner<S,T>
    {
        T Run(S src);
    }

    [Free]
    public interface IActionRunner : IActionRunner<CmdArgs,Outcome>
    {
        ShellCmdDef Def {get;}

        ref readonly asci32 CmdName
            => ref Def.CmdName;
    }
}