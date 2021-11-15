//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = relations;

    public readonly struct DataFlow<S,T> : IDataFlow<S,T>
    {
        public readonly S Source;

        public readonly T Target;

        [MethodImpl(Inline)]
        public DataFlow(S src, T dst)
        {
            Source = src;
            Target = dst;
        }

        public string Format()
            => api.format(this);

        public string IdentityText
            => api.specifier(this);

        public override string ToString()
            => Format();

        S IArrow<S,T>.Source
            => Source;

        T IArrow<S,T>.Target
            => Target;

        [MethodImpl(Inline)]
        public static implicit operator DataFlow<S,T>((S src, T dst) x)
            => new DataFlow<S,T>(x.src, x.dst);

        [MethodImpl(Inline)]
        public static implicit operator DataFlow<S,T>(Paired<S,T> x)
            => new DataFlow<S,T>(x.Left, x.Right);
    }
}