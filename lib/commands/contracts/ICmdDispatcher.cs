//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ICmdDispatcher
    {
        Outcome Dispatch(string command, CmdArgs args);

        Outcome Dispatch(string command);

        ReadOnlySpan<string> Supported {get;}

        Outcome Dispatch(CmdSpec cmd)
            => Dispatch(cmd.Name, cmd.Args);
    }
}