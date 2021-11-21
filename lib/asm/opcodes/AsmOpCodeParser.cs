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
    using static AsmOpCodeTokens;

    using SQ = SymbolicQuery;

    [ApiHost]
    public class AsmOpCodeParser
    {
        [Op]
        static bool match(ReadOnlySpan<char> src, uint i, out DispToken dst)
        {
            ref readonly var c0 = ref skip(src,i);
            ref readonly var c1 = ref skip(src,i + 1);
            var result = false;
            dst = default;
            switch(c0)
            {
                case 'c':
                    switch(c1)
                    {
                        case 'b':
                            dst = DispToken.cb;
                            result = true;
                        break;
                        case 'd':
                            dst = DispToken.cd;
                            result = true;
                        break;
                        case 'p':
                            dst = DispToken.cp;
                            result = true;
                        break;
                        case 'o':
                            dst = DispToken.co;
                            result = true;
                        break;
                        case 't':
                            dst = DispToken.ct;
                            result = true;
                        break;
                        case 'w':
                            dst = DispToken.cw;
                            result = true;
                        break;
                    }
                break;
            }
            return result;
        }

        /// <summary>
        /// Attempts to parse a <see cref='DispToken'/> from the input
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        [Op]
        public static bool disp(ReadOnlySpan<char> src, out DispToken dst)
        {
            const byte MatchLength = 2;
            dst = default;
            var result = false;
            var limit = src.Length - MatchLength + 1;
            for(var i=0u; i<limit; i++)
            {
                if(SQ.whitespace(skip(src,i)))
                    continue;

                result = match(src, i, out dst);
                break;
            }
            return result;
        }
    }
}