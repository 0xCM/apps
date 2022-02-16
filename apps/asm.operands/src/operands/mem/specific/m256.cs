//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands
{
    [DataType(TypeSyntax.Mem256), StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct m256 : IMemOp256<m256>
    {
        public NativeSize TargetSize {get;}

        public AsmAddress Address {get;}

        [MethodImpl(Inline)]
        public m256(AsmAddress address)
        {
            Address = address;
            TargetSize = NativeSizeCode.W256;
        }

        [MethodImpl(Inline)]
        public m256(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
        {
            Address = new AsmAddress(@base, index, scale, disp);
            TargetSize = NativeSizeCode.W256;
        }

        public AsmOpKind OpKind
            => AsmOpKind.Mem256;

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
        public static implicit operator m256(AsmAddress src)
            => new m256(src);

        [MethodImpl(Inline)]
        public static implicit operator m256(mem<m256> src)
            => new m256(src);

        [MethodImpl(Inline)]
        public static implicit operator mem<m256>(m256 src)
            => new mem<m256>(src.TargetSize,src.Address);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(m256 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator MemOp(m256 src)
            => new MemOp(src.TargetSize, src.Address);
    }
}