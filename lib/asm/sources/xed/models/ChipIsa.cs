//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    partial struct XedModels
    {
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct ChipIsa
        {
            public ChipCode Chip {get;}

            public IsaKind Isa {get;}

            [MethodImpl(Inline)]
            public ChipIsa(ChipCode chip, IsaKind isa)
            {
                Chip = chip;
                Isa = isa;
            }

            [MethodImpl(Inline)]
            public static implicit operator ChipIsa((ChipCode chip, IsaKind isa) src)
                => new ChipIsa(src.chip, src.isa);
        }
    }
}