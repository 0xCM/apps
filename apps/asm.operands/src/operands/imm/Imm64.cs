//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using W = W64;
    using I = imm64;

    /// <summary>
    /// Defines a 64-bit immediate value
    /// </summary>
    [DataType(TypeSyntax.Imm64)]
    public readonly struct imm64 : IImm<imm64,ulong>
    {
        [Parser]
        public static Outcome parse(string src, out imm64 dst)
        {
            var result = Outcome.Success;
            dst = default;
            var i = text.index(src,HexFormatSpecs.PreSpec);
            var imm = 0ul;
            if(i>=0)
            {
                result = HexParser.parse64u(src, out imm);
                if(result)
                    dst = imm;
            }
            else
            {
                result = DataParser.parse(src, out imm);
                if(result)
                    dst = imm;
            }
            return result;
        }

        public const ImmKind Kind = ImmKind.Imm64u;

        public const byte Width = 64;

        public ulong Value {get;}

        public static W W => default;

        [MethodImpl(Inline)]
        public imm64(ulong src)
            => Value = src;

        public ImmKind ImmKind
            => Kind;

        public AsmOpClass OpClass
            => AsmOpClass.Imm;

        public AsmOpKind OpKind
            => AsmOpKind.Imm64;

        public NativeSize Size
            => NativeSizeCode.W64;

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.calc(Value);
        }


        public override int GetHashCode()
            => (int)Hash;

        public string Format()
            => AsmRender.imm(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(I src)
            => Value == src.Value ? 0 : Value < src.Value ? -1 : 1;

        [MethodImpl(Inline)]
        public bool Equals(I src)
            => Value == src.Value;

        public override bool Equals(object src)
            => src is I x && Equals(x);

        [MethodImpl(Inline)]
        public Address64 ToAddress()
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
        public static implicit operator ulong(I src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Imm<ulong>(I src)
            => new Imm<ulong>(src);

        [MethodImpl(Inline)]
        public static implicit operator I(ulong src)
            => new I(src);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(I src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator I(MemoryAddress src)
            => new I(src);

        [MethodImpl(Inline)]
        public static implicit operator Imm(I src)
            => new Imm(src.ImmKind, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(imm64 src)
            => new AsmOperand(src);
   }
}