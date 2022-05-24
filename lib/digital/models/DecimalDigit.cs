//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct DecimalDigit
    {
        public readonly DecimalDigitValue Value;

        [MethodImpl(Inline)]
        public DecimalDigit(DecimalDigitValue src)
        {
            Value = src;
        }

        public DecimalDigitCode Code
        {
            [MethodImpl(Inline)]
            get => Digital.code(Value);
        }

        public DecimalDigitSym Symbol
        {
            [MethodImpl(Inline)]
            get => Digital.symbol(Value);
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

        [MethodImpl(Inline)]
        public bool Equals(DecimalDigit src)
            => Value == src.Value;

        public string Format()
            => Char.ToString();


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator byte(DecimalDigit src)
            => (byte)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator DecimalDigit(DecimalDigitValue src)
            => new DecimalDigit(src);

        [MethodImpl(Inline)]
        public static implicit operator DecimalDigitValue(DecimalDigit src)
            => src.Value;
    }
}