//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands
{
    [DataType(TypeSyntax.Mem8)]
    public readonly struct m8 : IMemOp8<m8>
    {
        public AsmAddress Address {get;}

        [MethodImpl(Inline)]
        public m8(AsmAddress address)
        {
            Address = address;
        }

        [MethodImpl(Inline)]
        public m8(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
        {
            Address = new AsmAddress(@base, index, scale, disp);
        }

        public AsmOpKind OpKind
            => AsmOpKind.Mem8;

        public AsmOpClass OpClass
            => AsmOpClass.Mem;

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => Sizes.native(8);
        }

        [MethodImpl(Inline)]
        public AsmOperand Untyped()
            => new AsmOperand(this);

        public string Format()
            => Address.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator m8(AsmAddress src)
            => new m8(src);

        [MethodImpl(Inline)]
        public static implicit operator m8(mem<m8> src)
            => new m8(src);

        [MethodImpl(Inline)]
        public static implicit operator mem<m8>(m8 src)
            => new mem<m8>(src.Address);
    }
}