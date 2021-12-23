//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static XedModels;

    [StructLayout(LayoutKind.Sequential), DataType("xed.chipisa")]
    public readonly struct XedChipIsa
    {
        public ChipCode Chip {get;}

        public IsaKind Isa {get;}

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