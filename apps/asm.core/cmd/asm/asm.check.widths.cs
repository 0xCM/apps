//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static Asm.AsmChecks;

    partial class AsmCoreCmd
    {
        [CmdOp("asm/check/widths")]
        Outcome TestAsmWidths(CmdArgs args)
        {
            var result = bit.On;
            var pass = bit.Off;
            var test = default(AsmSizeCheck);
            var inputs = Symbols.index<NativeSizeCode>().Kinds;
            var count = inputs.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(inputs,i);
                test.Input = input;
                pass = check(ref test);
                result &= pass;
                Write(test, pass ? FlairKind.Status : FlairKind.Error);
            }

            BitWidth w8 = 8;
            BitWidth w16 = 16;
            BitWidth w32 = 32;
            BitWidth w64 = 64;

            var sz8 = Sizes.native(w8);
            var sz16 = Sizes.native(w16);
            var sz32 = Sizes.native(w32);
            var sz64 = Sizes.native(w64);
            Write(sz8);
            Write(sz16);
            Write(sz32);
            Write(sz64);

            return (result, result ? "Pass" : "Fail");
        }
    }
}