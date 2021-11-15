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

    public readonly struct ArrowType<S,T>
    {
        public Type Source {get;}

        public Type Target {get;}

        [MethodImpl(Inline)]
        public ArrowType(Type src, Type dst)
        {
            Source = src;
            Target = dst;
        }

        [MethodImpl(Inline)]
        public bool Equals(ArrowType src)
            => api.eq(this, src);

        [MethodImpl(Inline)]
        public string Format()
            => api.format(this);

        public uint Hashed
        {
            [MethodImpl(Inline)]
            get => (uint)typeof(ArrowType<S,T>).GetHashCode();
        }

        public override int GetHashCode()
            => (int)api.hash32(this);

        [MethodImpl(Inline)]
        public static implicit operator Type(ArrowType<S,T> src)
            => typeof(ArrowType<S,T>);

        [MethodImpl(Inline)]
        public static implicit operator ArrowType(ArrowType<S,T> src)
            => new ArrowType(src.Source, src.Target);
    }
}