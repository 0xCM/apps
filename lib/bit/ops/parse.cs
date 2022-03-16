//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct bit
    {
        [MethodImpl(Inline), Op]
        public static bit parse(char c)
            => c == One;

        [MethodImpl(Inline), Op]
        public static bit parse(string src)
            => parse(text.ifempty(src, "0")[0]);

        public static bool parse(string src, out bit dst)
        {
            var result = false;
            dst = Off;
            var input = text.remove(text.trim(text.ifempty(src,EmptyString)),"0b");
            if(input.Length > 0)
            {
                var c = input[0];
                if(c == Zero)
                {
                    dst = Off;
                    result = true;
                }
                else if(c == One)
                {
                    dst = On;
                    result = true;
                }
            }
            return result;
        }
    }
}