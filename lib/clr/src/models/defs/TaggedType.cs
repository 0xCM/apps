//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    public readonly struct TaggedType<A>
        where A : Attribute
    {
        public Type Type {get;}

        public A Tag {get;}

        [MethodImpl(Inline)]
        public TaggedType(Type type, A tag)
        {
            Type = type;
            Tag = tag;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Tag == null;
        }

        [MethodImpl(Inline)]
        public static implicit operator TaggedType<A>((TypeInfo Type, A tag) src)
            => new TaggedType<A>(src.Type, src.tag);

        public static TaggedType<A> Empty
        {
            [MethodImpl(Inline)]
            get => new TaggedType<A>(EmptyVessels.EmptyType, default);
        }
    }
}