//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".test-digit-parser")]
        public Outcome TestDigitParser(CmdArgs args)
        {
            var cases = DigitParserCases.create();
            var results = DigitParserCases.run(cases).View;
            var count = results.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var result = ref skip(results,i);
                if(result.Passed)
                    Status(result.Format());
                else
                    Error(result.Format());
            }

            var case0 = "34289";
            DigitParser.parse32u(case0, out var _u32);
            Write(string.Format("{0} ?=? {1:x}", case0, _u32));

            return true;
        }
    }
}