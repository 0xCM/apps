//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IActionInvoker<S,T>
    {
        T Invoke(S src);
    }

    [Free]
    public interface ICmdActionInvoker : IActionInvoker<CmdArgs,Outcome>
    {
        ShellCmdDef Def {get;}

        ref readonly asci32 CmdName
            => ref Def.CmdName;
    }
}