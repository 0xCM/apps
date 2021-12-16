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

    public class ParserChecks : Checker<ParserChecks>
    {
        const uint ElementCount = 512;

        public Outcome CheckU8Parser()
        {
            var result = Outcome.Success;
            var src = Random.Array<byte>(ElementCount);
            var inputs = src.Select(x => x.ToString());
            var parser = Parsers.Service.Parser<byte>();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(inputs,i);
                result = parser.Parse(input, out var output);
                if(result.Fail)
                    break;

                ref readonly var expect = ref skip(src,i);
                if(output != expect)
                {
                    result = (false, string.Format("{0} != {1}", output, expect));
                    break;
                }
            }

            return result;
        }
    }
}