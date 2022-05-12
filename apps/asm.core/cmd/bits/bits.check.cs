//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        [CmdOp("bits/check")]
        Outcome CheckBits(CmdArgs args)
        {
            BitCheckers.run();

            CheckBitConverters();
            return true;
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
                Write(string.Format("{0,-3} | {1,-3} | {2,-3}", i, hex, bin));
            }

            var checks = Classifiers.Checks(Wf);
            checks.Run();
        }

    }
}