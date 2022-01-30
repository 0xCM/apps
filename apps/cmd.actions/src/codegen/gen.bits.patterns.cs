//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class CodeGenProvider
    {
        [CmdOp("gen/bits/patterns")]
        Outcome GenBitfield(CmdArgs args)
        {
            var sib = BitfieldPatterns.describe(Sib.BitPattern);
            var modrm = BitfieldPatterns.describe(ModRm.BitPattern);
            var rex = BitfieldPatterns.describe(RexPrefix.BitPattern);
            var vexC4 = BitfieldPatterns.describe(VexPrefixC4.BitPattern);
            var vexC5 = BitfieldPatterns.describe(VexPrefixC5.BitPattern);
            Write(modrm.Descriptor);
            Write(sib.Descriptor);
            Write(rex.Descriptor);
            Write(vexC4.Descriptor);
            Write(vexC5.Descriptor);

            byte data = 0b10_110_011;
            Write(BitfieldPatterns.bitstring(sib, data));
            return true;
        }
    }
}