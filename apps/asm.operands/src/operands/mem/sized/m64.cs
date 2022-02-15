//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands
{
    [DataType(TypeSyntax.Mem64)]
    public readonly struct m64 : IMemOp64<m64>
    {
        public AsmAddress Address {get;}

        [MethodImpl(Inline)]
        public m64(AsmAddress address)
        {
            Address = address;
        }

        [MethodImpl(Inline)]
        public m64(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
        {
            Address = new AsmAddress(@base, index, scale, disp);
        }

        public AsmOpKind OpKind
            => AsmOpKind.Mem64;

        public AsmOpClass OpClass
            => AsmOpClass.Mem;

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => Sizes.native(64);
        }

        [MethodImpl(Inline)]
        public AsmOperand Untyped()
            => new AsmOperand(this);

        public string Format()
            => Address.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator m64(AsmAddress src)
            => new m64(src);

        [MethodImpl(Inline)]
        public static implicit operator m64(mem<m64> src)
            => new m64(src);

        [MethodImpl(Inline)]
        public static implicit operator mem<m64>(m64 src)
            => new mem<m64>(src.Address);
    }
}