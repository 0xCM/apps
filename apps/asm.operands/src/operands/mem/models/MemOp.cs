//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct MemOp : IMemOp
    {
        public readonly NativeSize TargetSize;

        public readonly AsmAddress Address;

        [MethodImpl(Inline)]
        public MemOp(NativeSize target, AsmAddress address)
        {
            TargetSize = target;
            Address = address;
        }

        public AsmOpClass OpClass
        {
            [MethodImpl(Inline)]
            get => AsmOpClass.Mem;
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => TargetSize;
        }

        public AsmOpKind OpKind
        {
            [MethodImpl(Inline)]
            get => AsmOps.kind(OpClass, Size);
        }

        public string Format()
            => AsmRender.mem(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(MemOp src)
            => new AsmOperand(src);

        public static MemOp Empty => default;

        AsmAddress IMemOp.Address
            => Address;

        NativeSize IMemOp.TargetSize
            => Size;
    }
}