//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        public readonly struct Marker<T>
        {
            public T Element{get;}

            [MethodImpl(Inline)]
            public Marker(T src)
                => Element = src;

            public static implicit operator Marker(Marker<T> src)
                => new Marker(src.Element);

            public static implicit operator Marker<T>(T src)
                => new Marker<T>(src);
        }
    }
}