//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    using Operands;

    public readonly struct AsmRegMask : IAsmMaskOp<AsmRegMask>
    {
        public rK Reg {get;}

        public AsmRegMaskKind MaskKind {get;}

        [MethodImpl(Inline)]
        public AsmRegMask(RegIndexCode reg, AsmRegMaskKind kind)
        {
            Reg = reg;
            MaskKind = kind;
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => NativeSizeCode.W64;
        }

        public RegIndexCode RegIndex
        {
            [MethodImpl(Inline)]
            get => Reg.Index;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => MaskKind == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => MaskKind != 0;
        }

        public string Format()
            => AsmRender.format(this);

        public override string ToString()
            => Format();
    }
}