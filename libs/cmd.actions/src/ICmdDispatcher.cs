//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdDispatcher
    {
        Outcome Dispatch(string action, CmdArgs args);

        Outcome Dispatch(string action);

        IEnumerable<string> SupportedActions {get;}

        Outcome Dispatch(CmdSpec cmd)
            => Dispatch(cmd.Name, cmd.Args);
    }
}