//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ParserChecks : Checker<ParserChecks>
    {
        const uint ElementCount = 512;

        public Outcome CheckBitParser()
        {
            var result = Outcome.Success;
            var a0 = "0b10111";
            var a1 = (byte)0b10111;
            Span<bit> a2 = array<bit>(1,1,1,0,1);
            result = bits.parse(a0, out var a3);
            if(result.Fail)
                return result;

            result = a3.Length == a2.Length;
            if(result.Fail)
                return (false, string.Format("Unexpected length: {0} != {1}", a3.Length, a2.Length));

            for(var i=0; i<a3.Length; i++)
            {
                result = skip(a2, i) == skip(a3,i);
                if(result.Fail)
                    break;
            }

            if(result.Fail)
                return (false, string.Format("Parsed bitstring value incorrect: {0} != {1}", a2.FormatPacked(), a3.FormatPacked()));

            var a4 = BitPack.scalar<byte>(a3);
            result = (a4 == a1);
            if(result.Fail)
                return (false, string.Format("Incorrect scalar extracted: {0} != {1}", a4, a1));


            return result;
        }

        public Outcome CheckU8Parser()
        {
            var result = Outcome.Success;
            var src = Random.Array<byte>(ElementCount);
            var inputs = src.Select(x => x.ToString());
            var parser = Wf.Parsers().ValueParser<byte>();
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