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
            var modrm = BitfieldPatterns.infer(ModRm.BitPattern);
            Write(modrm.Descriptor);

            var rex = BitfieldPatterns.infer(RexPrefix.BitPattern);
            Write(rex.Descriptor);

            var vexC4 = BitfieldPatterns.infer(VexPrefixC4.BitPattern);
            Write(vexC4.Descriptor);

            var vexC5 = BitfieldPatterns.infer(VexPrefixC5.BitPattern);
            Write(vexC5.Descriptor);

            var sib = BitfieldPatterns.infer(Sib.BitPattern);
            Write(sib.Descriptor);

            byte data = 0b10_110_011;
            Write(BitfieldPatterns.bitstring(sib, data));
            return true;
        }
    }
}