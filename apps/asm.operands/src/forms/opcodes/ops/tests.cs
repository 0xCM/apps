//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static AsmOcTokens;

    using K = AsmOcTokenKind;

    partial class AsmOpCodes
    {
        [MethodImpl(Inline), Op]
        public static bool rex(in AsmOpCode src)
        {
            var result = false;
            var count = min(src.TokenCount,(byte)4);

            for(var i=0; i<count; i++)
            {
                ref readonly var token = ref src[i];
                var kind = token.Kind;
                if(kind == K.Rex || kind == K.RexB)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        [MethodImpl(Inline), Op]
        public static bool evex(in AsmOpCode src)
        {
            var result = false;
            if(src.IsNonEmpty)
                result = src[0].Kind == K.Evex;
            return result;
        }

        [MethodImpl(Inline), Op]
        public static bool vex(in AsmOpCode src)
        {
            var result = false;
            if(src.IsNonEmpty)
                result = src[0].Kind == K.Vex;
            return result;
        }

        public static bool rex(string src)
            => text.index(src, OpCodeText.Rex) >=0;

        public static bool evex(string src)
            => text.index(src, OpCodeText.Evex) == 0;

        public static bool vex(string src)
            => !evex(src) && text.index(src, OpCodeText.Vex) >= 0;

        public static bool rexw(string src)
            => text.index(src, OpCodeText.RexW) ==0;

        public static bool np(string src)
            => text.index(src, OpCodeText.NP) == 0;

        public static bool x66(string src)
            => text.index(src, OpCodeText.x66) == 0;

        public static bool f2(string src)
            => text.index(src, OpCodeText.F2) == 0;

        public static bool f3(string src)
            => text.index(src, OpCodeText.F3) == 0;

        public static bool x0f(string src)
            => text.index(src, OpCodeText.x0F) >= 0;

        public static bool x660f(string src)
            => x66(src) && x0f(src);

        public static bool np0f(string src)
            => np(src) && x0f(src);
    }
}