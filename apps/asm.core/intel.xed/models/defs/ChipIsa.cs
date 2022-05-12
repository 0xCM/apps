//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [StructLayout(LayoutKind.Sequential, Pack=1), DataWidth(16)]
        public readonly struct ChipIsa
        {
            public readonly ChipCode Chip;

            public readonly InstIsaKind Isa;

            [MethodImpl(Inline)]
            public ChipIsa(ChipCode chip, InstIsaKind isa)
            {
                Chip = chip;
                Isa = isa;
            }

            [MethodImpl(Inline)]
            public static implicit operator ChipIsa((ChipCode chip, InstIsaKind isa) src)
                => new ChipIsa(src.chip, src.isa);
        }
    }
}