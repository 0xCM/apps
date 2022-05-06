//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using W = W16;
    using I = imm16u;

    /// <summary>
    /// Defines a 16-bit immediate value
    /// </summary>
    [DataWidth(Width,Width)]
    public readonly struct imm16u : IImm<I,ushort>
    {
        public const byte Width = 16;

        public ushort Value {get;}

        public static W W => default;

        [MethodImpl(Inline)]
        public imm16u(ushort src)
            => Value = src;

        public AsmOpClass OpClass
        {
            [MethodImpl(Inline)]
            get => AsmOpClass.Imm;
        }

        public ImmKind ImmKind
            => ImmKind.Imm16u;

        public AsmOpKind OpKind
            => AsmOpKind.Imm16;

        public NativeSize Size
            => NativeSizeCode.W16;

        public string Format()
            => AsmRender.imm(this);

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
        public static implicit operator AsmOperand(imm16u src)
            => new AsmOperand(src);
     }
}