//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Flows
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct NativeFlow<S,T> : INativeFlow<S,T>
        where S : INativeChannel
        where T : INativeChannel
    {
        public S Source {get;}

        public T Target {get;}

        [MethodImpl(Inline)]
        public NativeFlow(S src, T dst)
        {
            Source = src;
            Target = dst;
        }

        public string Format()
            => flows.format(this);


        public override string ToString()
            => Format();

        public string IdentityText
            => flows.syntax(this);

        [MethodImpl(Inline)]
        public static implicit operator NativeFlow<S,T>((S src, T dst) x)
            => new NativeFlow<S,T>(x.src, x.dst);

        [MethodImpl(Inline)]
        public static implicit operator NativeFlow<S,T>(Paired<S,T> x)
            => new NativeFlow<S,T>(x.Left, x.Right);
    }
}