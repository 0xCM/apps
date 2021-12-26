//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct NamedSeq<T> : ISeq<T>
        where T : IEquatable<T>
    {
        readonly Index<T> Data;

        public Name Name {get;}

        [MethodImpl(Inline)]
        internal NamedSeq(Name name, T[] src)
        {
            Data = src;
            Name = name;
        }

        public ReadOnlySpan<T> Elements
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }
    }
}