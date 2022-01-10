//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using Operands;

    using static Root;

    public readonly struct ZeroMask : IAsmMaskOp<ZeroMask>
    {
        public rK Reg {get;}

        [MethodImpl(Inline)]
        public ZeroMask(rK reg)
        {
            Reg = reg;
        }

        public RegIndexCode RegIndex
        {
            [MethodImpl(Inline)]
            get => Reg.Index;
        }

        public AsmRegMaskKind MaskKind
            => AsmRegMaskKind.Zero;

        public string Format()
            => AsmRender.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ZeroMask(rK src)
            => new ZeroMask(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmRegMask(ZeroMask src)
            => new AsmRegMask(src.Reg, src.MaskKind);
    }
}