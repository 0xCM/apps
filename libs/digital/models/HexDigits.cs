//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct HexDigits : IIndex<HexDigit>
    {
        readonly Index<HexDigit> Data;

        [MethodImpl(Inline)]
        public HexDigits(HexDigit[] src)
        {
            Data = src;
        }

        public ReadOnlySpan<HexDigit> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public HexDigit[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref HexDigit this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref HexDigit this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public string Format()
            => Digital.format(Storage);

        public override string ToString()
            => Format();

        public static HexDigits Empty => new HexDigits(sys.empty<HexDigit>());
    }
}