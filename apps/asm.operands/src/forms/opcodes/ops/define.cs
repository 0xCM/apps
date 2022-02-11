//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmOpCodes
    {
        [Op]
        public static AsmOpCode define(ReadOnlySpan<AsmOcToken> src)
        {
            var storage = @as<AsmOcToken,Cell512>(src);
            var tokens = recover<AsmOcToken>(storage.Bytes);
            var counter = z8;
            for(var i=0; i<AsmOpCode.TokenCapacity; i++)
            {
                if(skip(tokens,i) != 0)
                    counter++;
                else
                    break;
            }

            storage.Cell8(31) = counter;
            return new AsmOpCode(storage);
        }
    }
}