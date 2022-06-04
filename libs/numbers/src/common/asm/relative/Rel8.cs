//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using W = W8;
    using T = Rel8;

    public readonly struct Rel8 : IRelOp<byte>
    {
        public const AsmRelKind Kind = AsmRelKind.Rel8;

        public const byte Width = 8;

        public readonly byte Value;

        [MethodImpl(Inline)]
        public Rel8(byte src)
            => Value = src;

        public AsmOpKind OpKind
            => AsmOpKind.Rel8;

        public NativeSize Size
            => NativeSizeCode.W8;

        public AsmOpClass OpClass
            => AsmOpClass.Rel;

        public string Format()
            => HexFormatter.format(w, Value, HexPadStyle.Unpadded, prespec:true, @case:UpperCase);

        public override string ToString()
            => Format();

        byte IRelOp<byte>.Value
            => Value;

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.calc(Value);
        }

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public int CompareTo(T src)
            => Value == src.Value ? 0 : Value < src.Value ? -1 : 1;

        [MethodImpl(Inline)]
        public bool Equals(T src)
            => Value == src.Value;

        public override bool Equals(object src)
            => src is T x && Equals(x);

        [MethodImpl(Inline)]
        public Address8 ToAddress()
            => Value;

        [MethodImpl(Inline)]
        public static bool operator <(T a, T b)
            => a.Value < b.Value;

        [MethodImpl(Inline)]
        public static bool operator >(T a, T b)
            => a.Value > b.Value;

        [MethodImpl(Inline)]
        public static bool operator <=(T a, T b)
            => a.Value <= b.Value;

        [MethodImpl(Inline)]
        public static bool operator >=(T a, T b)
            => a.Value >= b.Value;

        [MethodImpl(Inline)]
        public static bool operator ==(T a, T b)
            => a.Value == b.Value;

        [MethodImpl(Inline)]
        public static bool operator !=(T a, T b)
            => a.Value != b.Value;

        [MethodImpl(Inline)]
        public static implicit operator byte(T src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator T(byte src)
            => new T(src);

        public static W w => default;
    }
}