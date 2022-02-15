//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Asm;

    using W = W16;
    using I = imm16;

    /// <summary>
    /// Defines a 16-bit immediate value
    /// </summary>
    [DataType(TypeSyntax.Imm16, Kind, Width, Width)]
    public readonly struct imm16 : IImm<I,ushort>
    {
        public const ImmKind Kind = ImmKind.Imm16;

        public const byte Width = 16;

        public ushort Value {get;}

        public static W W => default;

        [MethodImpl(Inline)]
        public imm16(ushort src)
            => Value = src;

        public AsmOpClass OpClass
        {
            [MethodImpl(Inline)]
            get => AsmOpClass.Imm;
        }

        public ImmKind ImmKind
            => Kind;

        public AsmOpKind OpKind
            => AsmOpKind.Imm16;

        public string Format()
            => HexFormatter.format(w16, Value, HexPadStyle.Unpadded, prespec:true, @case:UpperCase);

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
        public Address16 ToAddress()
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
        public static implicit operator ushort(I src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Imm<ushort>(I src)
            => new Imm<ushort>(src);

        [MethodImpl(Inline)]
        public static implicit operator I(ushort src)
            => new I(src);

        [MethodImpl(Inline)]
        public static implicit operator Imm(I src)
            => new Imm(src.ImmKind, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(imm16 src)
            => new AsmOperand(src);
     }
}