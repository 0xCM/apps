//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Represents an operand expression of the form BaseReg + IndexReg*Scale + Displacement
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct mem<T> : IMemOp<T>
        where T : unmanaged, IMemOp<T>
    {
        public NativeSize TargetSize {get;}

        public AsmAddress Address {get;}

        [MethodImpl(Inline)]
        public mem(NativeSize target, AsmAddress src)
        {
            TargetSize = target;
            Address = src;
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => Address.Base.Size;
        }

        public AsmOpClass OpClass
        {
            [MethodImpl(Inline)]
            get => AsmOpClass.Mem;
        }

        public AsmOpKind OpKind
        {
            [MethodImpl(Inline)]
            get => (AsmOpKind)((ushort)OpClass | ((ushort)TargetSize << 8));
        }

        public RegOp Base
        {
            [MethodImpl(Inline)]
            get => Address.Base;
        }

        public RegOp Index
        {
            [MethodImpl(Inline)]
            get => Address.Index;
        }

        public MemoryScale Scale
        {
            [MethodImpl(Inline)]
            get => Address.Scale;
        }

        public Disp Disp
        {
            [MethodImpl(Inline)]
            get => Address.Disp;
        }

        public string Format()
            => AsmRender.mem(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmAddress(mem<T> src)
            => new AsmAddress(src.Base, src.Index, src.Scale, src.Disp);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(mem<T> src)
            => new MemOp(src.TargetSize,src.Address);
    }
}
