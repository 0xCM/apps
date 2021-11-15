//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".primes")]
        Outcome Primes(CmdArgs args)
        {
            var result = Outcome.Success;
            var emitter = PrimeEmitter.create();
            var prime = 0ul;
            var buffer = list<ListItem<ulong>>();
            var limit = uint.MaxValue;
            DataParser.parse(arg(args,0).Value, out uint count);

            for(var i=0u; i<count; i++)
            {
                prime = emitter.Next();
                if(prime > limit)
                    break;

                buffer.Add((i, prime));
            }

            var dst = ListItems.list(buffer.ToArray());
            Write(dst.Format());

            return result;
        }
    }
}