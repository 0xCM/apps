//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    public interface IMessageSink : ISink<IAppMsg>
    {
        void Deposit(IEnumerable<IAppMsg> msg)
            => core.iter(msg, Deposit);

        void Notify(string msg, LogLevel? kind = null)
            => Deposit(AppMsg.define(msg, kind ?? LogLevel.Status));

        void NotifyConsole(IAppMsg msg)
            => Deposit(msg);
    }
}