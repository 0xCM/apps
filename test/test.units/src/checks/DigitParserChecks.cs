//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;


    public class DigitParserChecks: Checker<DigitParserChecks>
    {
        public Outcome Check()
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
                    return (false,result.Format());
            }

            var case0 = "34289";
            DigitParser.parse32u(case0, out var _u32);
            Write(string.Format("{0} ?=? {1:x}", case0, _u32));

            return true;
        }
    }
}