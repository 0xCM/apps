//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("native/checks")]
        unsafe Outcome TestNativeCells(CmdArgs args)
        {
            CheckNativeCells();
            CheckBitConverters();
            return true;
        }

        void CheckNativeCells()
        {
            var n = n16;
            var count = num.count(n);
            byte length = (byte)n;
            var result = Outcome.Success;
            using var native = NativeCells.alloc<string>(count, out var id);
            var bits = num.bitstrings(n);
            for(var i=0u; i<count; i++)
            {
                var offset = i*n;
                native.Content(i) = new string(slice(bits, offset, n));
            }
        }

        void CheckBitConverters()
        {
            var n = n8;
            var count = num.count(n);
            var convert = BitConverters.converter(n);
            for(var i=0; i<count; i++)
            {
                ref readonly var hex = ref convert.Chars(base16, (ushort)i);
                ref readonly var bin = ref convert.Chars(base2, (ushort)i);
                ref readonly var oct = ref convert.Chars(base8, (ushort)i);

                Write(string.Format("{0,-3} | {1,-3} | {2,-3} | {3,-3}", i, hex, bin, oct));
            }

            var checks = Classifiers.Checks(Wf);
            checks.Run();

        }
    }
}