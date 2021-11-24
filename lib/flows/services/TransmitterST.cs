//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Flows
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class Transmitter<S,T>
    {
        readonly Transformer<S,T> Transformer;

        readonly Index<Receiver<T>> Targets;

        public Transmitter(Transformer<S,T> transfomer, Receiver<T>[] dst)
        {
            Transformer = transfomer;
            Targets = dst;
        }

        public void Broadcast(ReadOnlySpan<S> src)
        {
            var message = Transformer.Transform(src);
            var count = Targets.Count;
            for(var i=0; i<count; i++)
                Targets[i].Deposit(message);
        }
    }
}