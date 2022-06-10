//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using Asm;

    public class AsmHexChecks : Checker<AsmHexChecks>
    {
        public void RunChecks()
        {
            var dst = span<string>(32);
            var count = Lines.lines(DataSource, dst);
            var data = slice(dst,0,count);
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(data,i);
                AsmHexCode.parse(input, out var code);
                Write(code.Format());
            }
        }

        const string DataSource = @"66 2e 0f 1f 84 00 00 00 00 00
c4 e2 7d 24 01
c3
66 2e 0f 1f 84 00 00 00 00 00
c4 e2 7d 25 01
c3
66 2e 0f 1f 84 00 00 00 00 00
c5 f8 77
c5 f8 99 c8";

    }


}
