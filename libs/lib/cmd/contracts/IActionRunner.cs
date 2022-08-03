//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IActionRunner<S,T>
    {
        T Run(S src, IWfEventTarget log);
    }

    [Free]
    public interface IActionRunner : IActionRunner<CmdArgs,Outcome>
    {
        AppCmdDef Def {get;}

        ref readonly Name CmdName
            => ref Def.CmdName;
    }
}