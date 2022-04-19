//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ICmdRouter
    {
        ReadOnlySpan<CmdId> SupportedCommands {get;}

        void Enlist(Index<ICmdReactor> reactors);

        CmdResult Dispatch(ICmd cmd);

        CmdResult Dispatch(ICmd cmd, string msg);
    }

    [Free]
    public interface ICmdRouter<H> : ICmdRouter
        where H : ICmdRouter<H>, new()
    {

    }
}