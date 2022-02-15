//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands
{
    [DataType(TypeSyntax.Mem512)]
    public readonly struct m512 : IMemOp512<m512>
    {
        public AsmAddress Address {get;}

        [MethodImpl(Inline)]
        public m512(AsmAddress address)
        {
            Address = address;
        }

        [MethodImpl(Inline)]
        public m512(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
        {
            Address = new AsmAddress(@base, index, scale, disp);
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => Sizes.native(512);
        }

        public AsmOpKind OpKind
            => AsmOpKind.Mem512;

        public AsmOpClass OpClass
            => AsmOpClass.Mem;

        [MethodImpl(Inline)]
        public AsmOperand Untyped()
            => new AsmOperand(this);

        public string Format()
            => Address.Format();

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
            => new mem<m512>(src.Address);
    }
}