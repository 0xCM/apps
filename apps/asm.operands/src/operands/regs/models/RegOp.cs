//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using api = AsmRegs;

    /// <summary>
    /// Specifies a register operand
    /// </summary>
    public readonly struct RegOp : IRegOp
    {
        readonly ushort Data;

        [MethodImpl(Inline)]
        internal RegOp(ushort src)
        {
            Data = src;
        }

        public ushort Bitfield
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public AsmOpClass OpClass
        {
            [MethodImpl(Inline)]
            get => AsmOpClass.Reg;
        }

        public bit IsInvalid
        {
            [MethodImpl(Inline)]
            get => Data == ushort.MaxValue;
        }

        public NativeSizeCode Size
        {
            [MethodImpl(Inline)]
            get => api.width(this);
        }

        public RegClassCode RegClassCode
        {
            [MethodImpl(Inline)]
            get => api.@class(this);
        }

        public RegIndexCode Index
        {
            [MethodImpl(Inline)]
            get => api.index(this);
        }

        public RegKind RegKind
        {
            [MethodImpl(Inline)]
            get => (RegKind)Data;
        }

        public RegClass RegClass
        {
            [MethodImpl(Inline)]
            get => RegClassCode;
        }

        public AsmOpKind OpKind
        {
            [MethodImpl(Inline)]
            get => AsmOps.kind(AsmOpClass.Reg, Size);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data != 0;
        }

        public AsmRegName Name
        {
            [MethodImpl(Inline)]
            get => api.name(Size, RegClass, Index);
        }

        public string Format()
            => Name.Format().Trim();

        public override string ToString()
            =>  Format();

        [MethodImpl(Inline)]
        public static implicit operator RegOp(RegKind kind)
            => new RegOp((ushort)kind);

         [MethodImpl(Inline)]
        public static implicit operator AsmOperand(RegOp src)
            => new AsmOperand(src);

        public static RegOp Empty
        {
            [MethodImpl(Inline)]
            get => new RegOp(0);
        }
    }
}