//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using C = AsciCode;

    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static uint count(ReadOnlySpan<C> src)
        {
            var length = src.Length;
            var counter = 0u;
            for(var i=0; i<length; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(SQ.whitespace(c))
                {
                    if(counter == 0)
                        continue;
                }
                else
                    return counter;

                if(SQ.digit(base16, c))
                    counter++;
                else
                    break;
            }
            return counter;
        }
    }
}