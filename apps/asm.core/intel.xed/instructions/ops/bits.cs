//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static bool bits(asci8 src)
        {
            var result = true;
            var n=0;
            var data = recover<AsciCode>(bytes(src));
            for(var i=0; i<data.Length; i++)
            {
                ref readonly var b = ref skip(data,i);
                if(b == AsciCode.Space)
                    continue;

                if(b==AsciCode.d0 || b == AsciCode.d1)
                    n++;
                else
                    break;
            }

            return n != 0;
        }
    }
}