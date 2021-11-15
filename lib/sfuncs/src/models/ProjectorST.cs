//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct SFx
    {
        public readonly struct Projector<S,T> : ISFxProjector<S,T>
        {
            readonly Func<S,T> Fx;

            [MethodImpl(Inline)]
            public Projector(Func<S,T> fx)
                => Fx = fx;

            [MethodImpl(Inline)]
            public T Invoke(S a)
                => Fx(a);
        }
    }
}