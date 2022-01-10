//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    using Operands;

    public readonly struct MergeMask : IAsmMaskOp<MergeMask>
    {
        public rK Reg {get;}

        [MethodImpl(Inline)]
        public MergeMask(rK reg)
        {
            Reg = reg;
        }

        public RegIndexCode RegIndex
        {
            [MethodImpl(Inline)]
            get => Reg.Index;
        }

        public AsmRegMaskKind MaskKind
            => AsmRegMaskKind.Merge;

        public string Format()
            => AsmRender.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator MergeMask(rK src)
            => new MergeMask(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmRegMask(MergeMask src)
            => new AsmRegMask(src.Reg, src.MaskKind);
    }
}