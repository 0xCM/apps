//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands
{
    [DataType(TypeSyntax.Mem8), StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct m8 : IMemOp8<m8>
    {
        public NativeSize TargetSize {get;}

        public AsmAddress Address {get;}

        [MethodImpl(Inline)]
        public m8(AsmAddress address)
        {
            Address = address;
            TargetSize = NativeSizeCode.W8;
        }

        [MethodImpl(Inline)]
        public m8(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
        {
            Address = new AsmAddress(@base, index, scale, disp);
            TargetSize = NativeSizeCode.W8;
        }

        public AsmOpKind OpKind
            => AsmOpKind.Mem8;

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
        public static implicit operator m8(AsmAddress src)
            => new m8(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(m8 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator MemOp(m8 src)
            => new MemOp(src.TargetSize, src.Address);
    }
}