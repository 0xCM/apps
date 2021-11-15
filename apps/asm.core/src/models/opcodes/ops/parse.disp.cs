//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static AsciCharSym;

    using C = AsciCharSym;
    using T = AsmOpCodeTokens.DispToken;

    partial struct AsmOpCodes
    {
        [MethodImpl(Inline), Op]
        public static bit disp(ReadOnlySpan<char> src)
            => parse(src, out T _);

        /// <summary>
        /// Attempts to match one of ['cb', 'cw', 'cd', 'cp', 'co', 'ct']
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        [MethodImpl(Inline), Op]
        public static bit parse(ReadOnlySpan<char> src, out T dst)
            => scan(recover<char,C>(src), out dst);

        [MethodImpl(Inline), Op]
        static bit scan(ReadOnlySpan<C> src, out T dst)
        {
            var count = src.Length;
            var found = bit.Off;
            dst = default;
            for(var i=0; i<count; i++)
            {
                if(parse(src, out dst))
                {
                    found = bit.On;
                    break;
                }
            }
            return found;
        }

        [Op]
        static bit parse(ReadOnlySpan<C> src, out T dst)
        {
            var token = default(T?);
            if(src.Length >= 2)
            {
                switch(skip(src,0))
                {
                    case c:
                    switch(skip(src,1))
                    {
                        case b:
                            token = T.cb;
                        break;

                        case w:
                            token = T.cw;
                        break;

                        case d:
                            token = T.cd;
                        break;

                        case p:
                            token = T.cp;
                        break;

                        case o:
                            token = T.co;
                        break;

                        case t:
                            token = T.cb;
                        break;
                    }
                    break;
                }
            }

            dst = token ?? 0;
            return token.HasValue;
        }
    }
}