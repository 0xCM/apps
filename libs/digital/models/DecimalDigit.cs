//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = DecimalDigitSym;
    using C = DecimalDigitCode;
    using V = DecimalDigitValue;
    using D = DecimalDigit;
    using A = AsciCode;
    using T = System.Byte;
    using B = Base10;

    [DataWidth(4)]
    public readonly record struct DecimalDigit : IDigit<D,B,S,C,V>
    {
        readonly T Storage;

        [MethodImpl(Inline)]
        public DecimalDigit(V src)
        {
            Storage = (T)src;
        }

        public readonly V Value
        {
            [MethodImpl(Inline)]
            get => (V)Storage;
        }

        public S Symbol
        {
            [MethodImpl(Inline)]
            get => Digital.symbol(Value);
        }

        public C Code
        {
            [MethodImpl(Inline)]
            get => Digital.code(Value);
        }

        public char Char
        {
            [MethodImpl(Inline)]
            get => (char)Symbol;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Storage;
        }

        [MethodImpl(Inline)]
        public int CompareTo(D src)
            => Storage.CompareTo(src.Storage);


        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(D src)
            => Value == src.Value;

        public string Format()
            => Char.ToString();


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator byte(D src)
            => (byte)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator D(V src)
            => new D(src);

        [MethodImpl(Inline)]
        public static implicit operator V(D src)
            => src.Value;
    }
}