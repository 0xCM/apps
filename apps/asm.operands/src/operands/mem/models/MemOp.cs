//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct MemOp : IMemOp
    {
        public NativeSize TargetSize {get;}

        public AsmAddress Address {get;}

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

        public AsmOpKind OpKind
        {
            [MethodImpl(Inline)]
            get => (AsmOpKind)((ushort)AsmOpKind.Mem | ((ushort)TargetSize.Code << 8));
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => Address.Base.Size;
        }

        [MethodImpl(Inline)]
        public AsmOperand Untyped()
            => new AsmOperand(this);

        public string Format()
            => Address.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(MemOp src)
            => src.Untyped();

        public static MemOp Empty => default;
    }
}