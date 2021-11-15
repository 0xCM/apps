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

    public readonly struct ArrowType<S,T,K>
        where K : unmanaged
    {
        public Type Kind {get;}

        public Type Source {get;}

        public Type Target {get;}

        [MethodImpl(Inline)]
        internal ArrowType(Type kind, Type src, Type dst)
        {
            Kind = kind;
            Source = src;
            Target = dst;
        }

        [MethodImpl(Inline)]
        public bool Equals(ArrowType src)
            => api.eq(this, src);

        [MethodImpl(Inline)]
        public string Format()
            => api.format(this);

        public override int GetHashCode()
            => (int)api.hash32(this);

        public static implicit operator Type(ArrowType<S,T,K> src)
            => typeof(Arrow<S,T,K>);

        [MethodImpl(Inline)]
        public static implicit operator ArrowType(ArrowType<S,T,K> src)
            => new ArrowType(src.Source, src.Target, src.Kind);

    }
}