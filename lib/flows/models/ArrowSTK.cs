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
    /// Defines kinded link
    /// </summary>
    public readonly struct Arrow<S,T,K> : IArrow<S,T,K>
    {
        /// <summary>
        /// The source
        /// </summary>
        public S Source {get;}

        /// <summary>
        /// The target
        /// </summary>
        public T Target {get;}

        /// <summary>
        /// The kind classifier
        /// </summary>
        public K Kind {get;}

        [MethodImpl(Inline)]
        public Arrow(S src, T dst, K kind)
        {
            Kind = kind;
            Source = src;
            Target = dst;
        }

        public string IdentityText
        {
            [MethodImpl(Inline)]
            get => string.Format(RP.Arrow, Source, Target);
        }

        [MethodImpl(Inline)]
        public static implicit operator Arrow<S,T,K>((K k, S s, T t) src)
            => new Arrow<S,T,K>(src.s, src.t, src.k);

        [MethodImpl(Inline)]
        public static implicit operator (K k, S s, T t)(Arrow<S,T,K> x)
            => (x.Kind, x.Source, x.Target);
    }
}