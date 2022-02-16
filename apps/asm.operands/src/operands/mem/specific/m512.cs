//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands
{
    [DataType(TypeSyntax.Mem512), StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct m512 : IMemOp512<m512>
    {
        public NativeSize TargetSize {get;}

        public AsmAddress Address {get;}

        [MethodImpl(Inline)]
        public m512(AsmAddress address)
        {
            Address = address;
            TargetSize = NativeSizeCode.W512;
        }

        [MethodImpl(Inline)]
        public m512(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
        {
            Address = new AsmAddress(@base, index, scale, disp);
            TargetSize = NativeSizeCode.W512;
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => TargetSize;
        }

        public AsmOpKind OpKind
            => AsmOpKind.Mem512;

        public AsmOpClass OpClass
            => AsmOpClass.Mem;

        public string Format()
            => AsmRender.mem(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator m512(AsmAddress src)
            => new m512(src);

        [MethodImpl(Inline)]
        public static implicit operator m512(mem<m512> src)
            => new m512(src);

        [MethodImpl(Inline)]
        public static implicit operator mem<m512>(m512 src)
            => new mem<m512>(src.TargetSize,src.Address);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(m512 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator MemOp(m512 src)
            => new MemOp(src.TargetSize, src.Address);

    }
}