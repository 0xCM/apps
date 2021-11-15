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

    /// <summary>
    /// Defines the type signature for a node-homogenous link
    /// </summary>
    public readonly struct ArrowType<T>
    {
        public Type Source {get;}

        public Type Target {get;}

        [MethodImpl(Inline)]
        internal ArrowType(Type src, Type dst)
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
            get => (uint)typeof(ArrowType<T>).GetHashCode();
        }

        public ulong Hash64
        {
            [MethodImpl(Inline)]
            get => alg.hash.combine(Source,Target);
        }

        public override int GetHashCode()
            => (int)Hashed;

        public static implicit operator Type(ArrowType<T> src)
            => typeof(ArrowType<T>);

        [MethodImpl(Inline)]
        public static implicit operator ArrowType(ArrowType<T> src)
            => new ArrowType(src.Source, src.Target);
    }
}