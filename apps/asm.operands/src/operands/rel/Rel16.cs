//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using W = W32;
    using T = Rel16;

    /// <summary>
    /// Defines a 32-bit immediate value
    /// </summary>
    [DataType("rel<w:16>", Kind, Width, Width)]
    public readonly struct Rel16 : IRelOp<ushort>
    {
        public const AsmRelKind Kind = AsmRelKind.Rel16;

        public const byte Width = 16;

        public ushort Value {get;}

        [MethodImpl(Inline)]
        public Rel16(ushort src)
            => Value = src;

        public AsmOpKind OpKind
            => AsmOpKind.Rel16;

        public string Format()
            => HexFormatter.format(w, Value, HexPadStyle.Unpadded, prespec:true, @case:UpperCase);

        public override string ToString()
            => Format();

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
        public Address16 ToAddress()
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
        public static implicit operator ushort(T src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator T(ushort src)
            => new Rel16(src);

        public static W w=> default;
    }
}