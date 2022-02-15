//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands
{
    [DataType(TypeSyntax.Mem256)]
    public readonly struct m256 : IMemOp256<m256>
    {
        public AsmAddress Address {get;}

        [MethodImpl(Inline)]
        public m256(AsmAddress address)
        {
            Address = address;
        }

        [MethodImpl(Inline)]
        public m256(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
        {
            Address = new AsmAddress(@base, index, scale, disp);
        }

        public AsmOpKind OpKind
            => AsmOpKind.Mem256;

        public AsmOpClass OpClass
            => AsmOpClass.Mem;

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => Sizes.native(256);
        }

        [MethodImpl(Inline)]
        public AsmOperand Untyped()
            => new AsmOperand(this);

        public string Format()
            => Address.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator m256(AsmAddress src)
            => new m256(src);

        [MethodImpl(Inline)]
        public static implicit operator m256(mem<m256> src)
            => new m256(src);

        [MethodImpl(Inline)]
        public static implicit operator mem<m256>(m256 src)
            => new mem<m256>(src.Address);
    }
}