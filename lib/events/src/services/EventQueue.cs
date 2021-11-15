//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Collections.Concurrent;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public sealed class EventQueue : IEventSink, IEventEmitter
    {
        public static EventQueue allocate(Type host)
            => new EventQueue(host);

        public static EventQueue allocate(Type host, Action<IWfEvent> receiver)
            => new EventQueue(host, receiver);

        readonly ConcurrentQueue<IWfEvent> Storage = new();

        readonly Action<IWfEvent> Receiver;

        readonly EventSignal Signal;

        readonly Type Host;

        internal EventQueue(Type host)
        {
            Host = host;
            Receiver = e => {};
            Signal = EventSignals.signal(this, Host);
        }

        internal EventQueue(Type host, Action<IWfEvent> receiver)
        {
            Host = host ?? GetType();
            Receiver = receiver;
            Signal = EventSignals.signal(this, Host);
        }

        public void Deposit(IWfEvent e)
        {
            if(e != null)
            {
                run(() => Receiver.Invoke(e));
                Storage.Enqueue(e);
            }
            else
                term.error("Null messages don't belong in the queue");

        }

        public void Dispose()
        {
            if(Storage.Count != 0)
                term.warn("Nonempty queue disposed");
        }

        [MethodImpl(Inline)]
        public bool Emit(out IWfEvent e)
            => Storage.TryDequeue(out e);
    }
}