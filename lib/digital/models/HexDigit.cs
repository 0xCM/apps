//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = HexDigitSym;
    using C = HexDigitCode;
    using V = HexDigitValue;
    using D = HexDigit;
    using A = AsciCode;
    using T = System.Byte;
    using B = Base16;

    [DataWidth(4)]
    public readonly record struct HexDigit : IDigit<D,B,S,C,V>
    {
        readonly T Storage;

        [MethodImpl(Inline)]
        public HexDigit(V src)
        {
            Storage = (T)((uint)src | (1 << 4));
        }

        [MethodImpl(Inline)]
        public HexDigit(V src, bit upper)
        {
            Storage = (T)((uint)src | ((uint)upper << 4));
        }

        public V Value
        {
            [MethodImpl(Inline)]
            get => (V)(Storage & 0xF);
        }

        public S Symbol
        {
            [MethodImpl(Inline)]
            get => Digital.symbol(Case,Value);
        }

        public C Code
        {
            [MethodImpl(Inline)]
            get => (C)Symbol;
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


        public override int GetHashCode()
            => Hash;

        public string Format()
            => Char.ToString();


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(D src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public int CompareTo(D src)
            => Storage.CompareTo(src.Storage);

        [MethodImpl(Inline)]
        public static implicit operator D(HexDigitValue src)
            => new D(src);

        [MethodImpl(Inline)]
        public static implicit operator V(D src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator T(D src)
            => (T)src.Value;
    }
}