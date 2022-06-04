//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmOpCodes
    {
        [MethodImpl(Inline)]
        public static bool diff(AsmOpCode oc1, AsmOpCode oc2, out AsmOcToken x)
        {
            var count = min(oc1.TokenCount, oc2.TokenCount);
            for(var i=0; i<count; i++)
            {
                ref readonly var ta = ref oc1[i];
                ref readonly var tb = ref oc2[i];
                if(ta.Kind == AsmOcTokenKind.Sep && tb.Kind == AsmOcTokenKind.Sep)
                    continue;

                if(ta != tb)
                {
                    x = tb;
                    return true;
                }
            }

            x = default;
            return false;
        }

        [Op]
        public static AsmOpCode define(ReadOnlySpan<AsmOcToken> src)
        {
            var storage = @as<AsmOcToken,Cell512>(src);
            var tokens = recover<AsmOcToken>(storage.Bytes);
            var counter = z8;
            for(var i=0; i<AsmOpCode.TokenCapacity; i++)
            {
                if(skip(tokens,i).Id != 0)
                    counter++;
                else
                    break;
            }

            storage.Cell8(31) = counter;
            return new AsmOpCode(storage);
        }
    }
}