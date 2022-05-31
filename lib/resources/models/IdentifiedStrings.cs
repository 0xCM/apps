//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct IdentifiedStrings
    {
        readonly Index<IdentifiedString> Data;

        [MethodImpl(Inline)]
        public IdentifiedStrings(IdentifiedString[] src)
        {
            Data = src;
        }
        public IdentifiedString[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public ReadOnlySpan<IdentifiedString> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<IdentifiedString> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }


        [MethodImpl(Inline)]
        public static implicit operator IdentifiedStrings(IdentifiedString[] src)
            => new(src);
    }
}