//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct EventHubClient : IEventHubClient
    {
        public IEventHub Hub {get;}

        readonly IWfEventSink Sink;

        readonly Action Connector;

        readonly Action Executor;

        [MethodImpl(Inline)]
        public EventHubClient(IEventHub hub, IWfEventSink sink, Action connect, Action exec)
        {
            Hub = hub;
            Sink = sink;
            Connector = connect;
            Executor = exec;
            Connect();
        }

        public void Deposit(IWfEvent e)
            => Sink.Deposit(e);

        public void Deposit<S>(in S e)
            where S : struct, IWfEvent
                => Sink.Deposit(e);

        [MethodImpl(Inline)]
        public void Connect()
            => Connector();

        [MethodImpl(Inline)]
        public void Exec()
            => Executor();
    }
}