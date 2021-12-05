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

    public readonly struct TaggedMethod<A>
        where A : Attribute
    {
        public MethodInfo Method {get;}

        public A Tag {get;}

        [MethodImpl(Inline)]
        public TaggedMethod(MethodInfo method, A tag)
        {
            Method = method;
            Tag = tag;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Tag == null;
        }

        [MethodImpl(Inline)]
        public static implicit operator TaggedMethod<A>((MethodInfo method, A tag) src)
            => new TaggedMethod<A>(src.method, src.tag);

        public static TaggedMethod<A> Empty
        {
            [MethodImpl(Inline)]
            get => new TaggedMethod<A>(EmptyVessels.EmptyMethod, default);
        }
    }
}