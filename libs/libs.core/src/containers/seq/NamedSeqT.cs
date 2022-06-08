//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NamedSeq<T> : ISeq<T>
        where T : IEquatable<T>
    {
        readonly Index<T> Data;

        public readonly Name Name;

        [MethodImpl(Inline)]
        public NamedSeq(Name name, T[] src)
        {
            Data = src;
            Name = name;
        }

        public ReadOnlySpan<T> View
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