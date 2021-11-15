//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct SFxProjector<T> : ISFxProjector<T>
    {
        readonly System.Func<T,T> Fx;

        [MethodImpl(Inline)]
        public SFxProjector(System.Func<T,T> fx)
            => Fx = fx;

        [MethodImpl(Inline)]
        public T Invoke(T a)
            => Fx(a);
    }
}