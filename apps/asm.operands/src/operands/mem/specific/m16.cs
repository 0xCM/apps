//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands
{
    [DataType(TypeSyntax.Mem16), StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct m16 : IMemOp16<m16>
    {
        public NativeSize TargetSize {get;}

        public AsmAddress Address {get;}

        [MethodImpl(Inline)]
        public m16(AsmAddress address)
        {
            Address = address;
            TargetSize = NativeSizeCode.W16;
        }

        [MethodImpl(Inline)]
        public m16(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
        {
            Address = new AsmAddress(@base, index, scale, disp);
            TargetSize = NativeSizeCode.W16;
        }

        public AsmOpKind OpKind
            => AsmOpKind.Mem16;

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
        public static implicit operator m16(AsmAddress src)
            => new m16(src);

        [MethodImpl(Inline)]
        public static implicit operator m16(mem<m16> src)
            => new m16(src);

        [MethodImpl(Inline)]
        public static implicit operator mem<m16>(m16 src)
            => new mem<m16>(src.TargetSize,src.Address);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(m16 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator MemOp(m16 src)
            => new MemOp(src.TargetSize, src.Address);

    }
}