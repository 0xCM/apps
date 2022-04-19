//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct ViewTrigger<T>
    {
        Receiver<T> Receiver;

        [MethodImpl(Inline)]
        public ViewTrigger(Receiver<T> receiver)
            => Receiver = receiver;

        [MethodImpl(Inline)]
        public void Raise(in T src)
            => Receiver(src);
    }
}