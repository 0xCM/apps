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
        public Outcome CheckCases()
        {
            var cases = DigitParserCases.create();
            var results = DigitParserCases.run(cases).View;
            var count = results.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var result = ref skip(results,i);
                if(!result.Passed)
                    return (false,result.Format());
            }

            return true;
        }
    }
}