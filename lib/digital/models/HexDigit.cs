//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct HexDigit
    {
        readonly byte Storage;

        public HexDigitValue Value
        {
            [MethodImpl(Inline)]
            get => (HexDigitValue)(Storage & 0xF);
        }

        [MethodImpl(Inline)]
        public HexDigit(HexDigitValue src)
        {
            Storage = (byte)((uint)src | (1 << 4));
        }

        [MethodImpl(Inline)]
        public HexDigit(HexDigitValue src, bit upper)
        {
            Storage = (byte)((uint)src | ((uint)upper << 4));
        }

        public bool IsUpper
        {
            [MethodImpl(Inline)]
            get =>  (Storage >> 4) != 0;
        }

        public bool IsLower
        {
            [MethodImpl(Inline)]
            get =>  (Storage >> 4) == 0;
        }

        public LetterCaseKind Case
        {
            [MethodImpl(Inline)]
            get => IsUpper ? LetterCaseKind.Upper : LetterCaseKind.Lower;
        }

        public HexDigitSym Symbol
        {
            [MethodImpl(Inline)]
            get => Digital.symbol(Case,Value);
        }

        public char Char
        {
            [MethodImpl(Inline)]
            get => (char)Symbol;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Value;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Char.ToString();


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(HexDigit src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public static implicit operator HexDigit(HexDigitValue src)
            => new HexDigit(src);

        [MethodImpl(Inline)]
        public static implicit operator HexDigitValue(HexDigit src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator byte(HexDigit src)
            => (byte)src.Value;
    }
}