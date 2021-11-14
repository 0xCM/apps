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
    using T = AsmOpCodeTokens.OpCodeExtension;

    partial struct AsmOpCodes
    {
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

        static bit parse(ReadOnlySpan<C> src, out T dst)
        {
            var count = src.Length;
            var token = default(T?);
            if(count >= 2)
            {
                if(skip(src,0) == C.FS)
                {
                    switch(skip(src,1))
                    {
                        case d0:
                            token = T.r0;
                            break;
                        case d1:
                            token = T.r1;
                            break;
                        case d2:
                            token = T.r2;
                            break;
                        case d3:
                            token = T.r3;
                            break;
                        case d4:
                            token = T.r4;
                            break;
                        case d5:
                            token = T.r5;
                            break;
                        case d6:
                            token = T.r6;
                            break;
                        case d7:
                            token = T.r7;
                            break;
                    }
                }
            }
            dst = token ?? 0;
            return token.HasValue;
        }
    }
}