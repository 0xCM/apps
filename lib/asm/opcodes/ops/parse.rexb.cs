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
    using T = AsmOpCodeTokens.RexBToken;

    partial struct AsmOpCodes
    {
        [MethodImpl(Inline), Op]
        public static bit rexB(ReadOnlySpan<char> src)
            => parse(src, out T _);

        /// <summary>
        /// Attempts to match one of ['+rb', '+rw', '+rd', '+ro', 'N.A.', 'N.E.']
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
            var length = src.Length;
            dst = default;
            if(length < 3)
                return false;

            ref readonly var c0 = ref skip(src,0);
            ref readonly var c1 = ref skip(src,1);
            ref readonly var c2 = ref skip(src,2);
            switch(c0)
            {
                case Plus:
                    switch(c1)
                    {
                        case r:
                            switch(c2)
                            {
                                case b:
                                    token = T.rb;
                                break;
                                case w:
                                    token = T.rw;
                                break;
                                case d:
                                    token = T.rd;
                                break;
                                case o:
                                    token = T.ro;
                                break;
                            }
                        break;
                    }
                break;
            }

            dst = token ?? 0;
            return token.HasValue;
        }
    }
}