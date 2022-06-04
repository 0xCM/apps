//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct RegMask : IRegMask
    {
        public RegOp Target {get;}

        public RegIndex Mask {get;}

        public RegMaskKind MaskKind {get;}

        [MethodImpl(Inline)]
        public RegMask(RegOp target, RegIndex mask, RegMaskKind kind)
        {
            Target = target;
            Mask = mask;
            MaskKind = kind;
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => Target.Size;
        }

        public AsmOpKind OpKind
        {
            [MethodImpl(Inline)]
            get => AsmOps.kind(AsmOpClass.RegMask, Size);
        }

        public AsmOpClass OpClass
            => AsmOpClass.RegMask;

        public string Format()
            => AsmRender.regmask(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(RegMask src)
            => new AsmOperand(src);
    }
}