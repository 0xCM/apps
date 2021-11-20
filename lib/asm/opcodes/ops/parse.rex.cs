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

    using T = AsmOpCodeTokens.RexToken;
    using C = AsciCharSym;

    partial struct AsmOpCodes
    {
        [MethodImpl(Inline), Op]
        public static bit rex(ReadOnlySpan<char> src)
            => rex(src, out T _);

        /// <summary>
        /// Attempts to match one of ['REX', 'REX.W', 'REX.R', 'REX.X', 'REX.B']
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        [MethodImpl(Inline), Op]
        public static bit rex(ReadOnlySpan<char> src, out T dst)
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
            dst = default;
            var token = default(T?);
            var length = src.Length;
            if(length < 3)
                return false;

            var rex = skip(src,0) == R && skip(src,1) == E && skip(src,2) == X;
            if(!rex)
                return false;

            if(length == 3)
            {
                token = T.Rex;
            }
            else
            {
                switch(skip(src,3))
                {
                    case C.Space:
                        token = T.Rex;
                    break;

                    case Dot:
                        if(length > 4)
                        {
                            switch(skip(src,4))
                            {
                                case W:
                                    token = T.RexW;
                                break;
                            }
                        }
                    break;
                }
            }

            dst = token ?? 0;
            return token.HasValue;
        }
    }
}