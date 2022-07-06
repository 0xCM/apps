//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct bit
    {
        [MethodImpl(Inline), Op]
        public static bit parse(char c)
            => c == One;

        [MethodImpl(Inline), Op]
        public static bit parse(string src)
            => parse(text.ifempty(src, "0")[0]);

        // public static bool parse(string src, out bit dst)
        // {
        //     var result = false;
        //     dst = Off;
        //     var input = text.remove(text.trim(text.ifempty(src,EmptyString)),"0b");
        //     if(input.Length > 0)
        //     {
        //         var c = input[0];
        //         if(c == Zero)
        //         {
        //             dst = Off;
        //             result = true;
        //         }
        //         else if(c == One)
        //         {
        //             dst = On;
        //             result = true;
        //         }
        //     }
        //     return result;
        // }


        // public static int parse(string src, Span<bit> dst)
        // {
        //     var input = core.span(BitParser.cleanse(src)).Reverse();
        //     if(input.Length > dst.Length)
        //         return -1;

        //     var result = true;
        //     var count = min(input.Length, dst.Length);
        //     var counter = 0;
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var c = ref skip(input,i);
        //         ref var bit = ref seek(dst, i);
        //         if(c == bit.Zero)
        //             bit = Off;
        //         else if(c == bit.One)
        //             bit = On;
        //         else
        //         {
        //             result = false;
        //             break;
        //         }
        //         counter++;
        //     }
        //     return result ? counter : -1;
        // }
    }
}