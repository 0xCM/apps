//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using System;


    using static core;

    partial class CodeGenProvider
    {
        [CmdOp("gen/records")]
        Outcome GenRecords(CmdArgs args)
        {
            var g = Generators.Records();
            var src = Tables.definition(typeof(XedModels.OperandState));
            var dst =  text.buffer();
            g.Emit(0u,src,dst);
            Write(dst.Emit());
            return true;
        }

        [CmdOp("gen/bitfield")]
        Outcome GenBitfield(CmdArgs args)
        {
            var sib = BitPatterns.describe(Sib.BitPattern);
            var modrm = BitPatterns.describe(ModRm.BitPattern);
            var rex = BitPatterns.describe(RexPrefix.BitPattern);
            var vexC4 = BitPatterns.describe(VexPrefixC4.BitPattern);
            var vexC5 = BitPatterns.describe(VexPrefixC5.BitPattern);
            Write(modrm.Descriptor);
            Write(sib.Descriptor);
            Write(rex.Descriptor);
            Write(vexC4.Descriptor);
            Write(vexC5.Descriptor);

            byte data = 0b10_110_011;
            Write(BitPatterns.bitstring(sib,data));
            return true;
        }
    }
}