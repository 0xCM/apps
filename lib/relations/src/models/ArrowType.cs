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

    public readonly struct ArrowType : IEquatable<ArrowType>
    {
        public Type Source {get;}

        public Type Target {get;}

        public Type Kind {get;}

        [MethodImpl(Inline)]
        internal ArrowType(Type src, Type dst)
        {
            Source = src;
            Target = dst;
            Kind = typeof(void);
        }

        [MethodImpl(Inline)]
        internal ArrowType(Type src, Type dst, Type kind)
        {
            Source = src;
            Target = dst;
            Kind = kind;
        }

        [MethodImpl(Inline)]
        public bool Equals(ArrowType src)
            => api.eq(this, src);

        public string Format()
            => relations.format(this);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)api.hash32(this);

        public override bool Equals(object src)
            => src is ArrowType x && Equals(x);

        [MethodImpl(Inline)]
        public static bool operator ==(ArrowType a, ArrowType b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(ArrowType a, ArrowType b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator ArrowType((Type src, Type dst) x)
            => new ArrowType(x.src, x.dst);

        [MethodImpl(Inline)]
        public static implicit operator ArrowType((Type src, Type dst, Type kind) x)
            => new ArrowType(x.src, x.dst, x.kind);
    }
}