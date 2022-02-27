//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static Asm.AsmDirectives;

    partial class AsmCmdProvider
    {
        [CmdOp("asm/check/directives")]
        Outcome CheckDirectives(CmdArgs args)
        {
            var data = array<byte>(1,2,3,4,5,6);
            var actual = NativeShape.calc(data);
            var expect = NativeShape.define(n4:1, n2:1);
            Require.equal(actual,expect);

            var a = AsmDirectives.section(CoffSectionKind.ReadOnlyData, CoffSectionFlags.d | CoffSectionFlags.r, CoffComDatKind.Discard, "block, vpmuldq_1, sdm/opcode, vpmuldq");
            var x = ".section .rdata, \"dr\", discard, \"block, vpmuldq_1, sdm/opcode, vpmuldq\"";
            Require.equal(a.Format(),x);
            return true;
        }
    }
}