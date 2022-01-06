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
            var sib = BitPatterns.define(Sib.BitPattern);
            Write(sib.Descriptor());
            var members = sib.BitfieldMembers();
            foreach(var member in members)
            {
                Write(string.Format("{0}:{1}", member.Name, member.Mask));
            }

            Write(BitPatterns.define(ModRm.BitPattern).Descriptor());
            Write(BitPatterns.define(VexPrefixC4.BitPattern).Descriptor());
            Write(BitPatterns.define(VexPrefixC5.BitPattern).Descriptor());

            return true;
        }
    }
}