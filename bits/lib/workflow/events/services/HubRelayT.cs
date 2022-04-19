//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a sink that forwards deposits to a receiver
    /// </summary>
    public readonly struct HubRelay<E> : IWfEventSink
        where E : struct, IWfEvent
    {
        readonly EventReceiver<E> Receiver;

        [MethodImpl(Inline)]
        internal HubRelay(EventReceiver<E> receiver)
            => Receiver = receiver;

        [MethodImpl(Inline)]
        public void Deposit(in E e)
            => Receiver(e);

        public void Deposit(IWfEvent e)
            => Receiver((E)e);
    }
}