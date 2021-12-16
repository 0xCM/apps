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

    partial struct bit
    {
        [MethodImpl(Inline), Op]
        public static bit parse(char c)
            => c == One;

        [MethodImpl(Inline)]
        static string ifempty(string src, string replace)
            => sys.empty(src) ? replace ?? EmptyString : src;

        [MethodImpl(Inline), Op]
        public static bit parse(string src)
            => parse(ifempty(src, "0")[0]);

        [MethodImpl(Inline)]
        public static bool parse(string src, out bit dst)
        {
            dst = 0;
            if((src?.Length ?? 0) > 0)
            {
                var c = src[0];
                if(c == Zero)
                {
                    return true;
                }
                else if(c == One)
                {
                    dst = 1;
                    return true;
                }
            }
            return false;
        }

        [MethodImpl(Inline), Op]
        public static uint parse(ReadOnlySpan<char> src, Span<bit> dst)
        {
            var count = (uint)min(src.Length,dst.Length);
            var lastix = count - 1;
            for(var i=0; i<= lastix; i++)
               seek(dst, lastix - i) = skip(src,i) == bit.Zero ? bit.Off : bit.On;
            return count;
        }
    }
}