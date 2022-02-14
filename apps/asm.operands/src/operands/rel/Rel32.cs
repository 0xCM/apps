//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Asm;

    using W = W32;
    using I = Rel32;

    /// <summary>
    /// Defines a 32-bit immediate value
    /// </summary>
    [DataType("rel<w:32>", Kind, Width, Width)]
    public readonly struct Rel32 : IRelOp<uint>
    {
        public const AsmRelKind Kind = AsmRelKind.Rel32;

        public const byte Width = 32;

        public uint Value {get;}

        [MethodImpl(Inline)]
        public Rel32(uint src)
            => Value = src;

        public AsmOpKind OpKind
            => AsmOpKind.Rel32;

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
        public int CompareTo(I src)
            => Value == src.Value ? 0 : Value < src.Value ? -1 : 1;

        [MethodImpl(Inline)]
        public bool Equals(I src)
            => Value == src.Value;

        public override bool Equals(object src)
            => src is I x && Equals(x);

        [MethodImpl(Inline)]
        public Address32 ToAddress()
            => Value;

        [MethodImpl(Inline)]
        public static bool operator <(I a, I b)
            => a.Value < b.Value;

        [MethodImpl(Inline)]
        public static bool operator >(I a, I b)
            => a.Value > b.Value;

        [MethodImpl(Inline)]
        public static bool operator <=(I a, I b)
            => a.Value <= b.Value;

        [MethodImpl(Inline)]
        public static bool operator >=(I a, I b)
            => a.Value >= b.Value;

        [MethodImpl(Inline)]
        public static bool operator ==(I a, I b)
            => a.Value == b.Value;

        [MethodImpl(Inline)]
        public static bool operator !=(I a, I b)
            => a.Value != b.Value;

        [MethodImpl(Inline)]
        public static implicit operator uint(I src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator I(uint src)
            => new I(src);

        public static W w => default;
    }
}