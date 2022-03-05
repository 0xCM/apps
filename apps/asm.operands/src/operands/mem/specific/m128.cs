//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands
{
    [DataType(TypeSyntax.Mem128), StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct m128 : IMemOp128<m128>
    {
        public NativeSize TargetSize {get;}

        public AsmAddress Address {get;}

        [MethodImpl(Inline)]
        public m128(AsmAddress address)
        {
            Address = address;
            TargetSize = NativeSizeCode.W128;
        }

        [MethodImpl(Inline)]
        public m128(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
        {
            Address = new AsmAddress(@base, index, scale, disp);
            TargetSize = NativeSizeCode.W128;
        }

        public AsmOpKind OpKind
            => AsmOpKind.Mem128;

        public AsmOpClass OpClass
            => AsmOpClass.Mem;

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => TargetSize;
        }

        public string Format()
            => AsmRender.mem(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator m128(AsmAddress src)
            => new m128(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(m128 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator MemOp(m128 src)
            => new MemOp(src.TargetSize, src.Address);
    }
}