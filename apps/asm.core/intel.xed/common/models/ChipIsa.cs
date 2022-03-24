//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct XedChipIsa
    {
        public readonly ChipCode Chip;

        public readonly IsaKind Isa;

        [MethodImpl(Inline)]
        public XedChipIsa(ChipCode chip, IsaKind isa)
        {
            Chip = chip;
            Isa = isa;
        }

        [MethodImpl(Inline)]
        public static implicit operator XedChipIsa((ChipCode chip, IsaKind isa) src)
            => new XedChipIsa(src.chip, src.isa);
    }
}