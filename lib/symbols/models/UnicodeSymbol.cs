//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct UnicodeSymbol: INatBytes<UnicodeSymbol,N2>
    {
        public readonly ushort Code;

        public string Text
        {
            [MethodImpl(Inline), Op]
            get => ((char)Code).ToString();
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline), Op]
            get => bytes(this);
        }

        public char Decoded
        {
            [MethodImpl(Inline), Op]
            get => (char)Code;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline), Op]
            get => Code == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline), Op]
            get => Code != 0;
        }

        [MethodImpl(Inline)]
        public bool Equals(UnicodeSymbol src)
            => Code == src.Code;

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public override int GetHashCode()
            => (int)Code;

        public override bool Equals(object src)
            => src is UnicodeSymbol c && Equals(c);

        public override string ToString()
            => Text;
    }
}