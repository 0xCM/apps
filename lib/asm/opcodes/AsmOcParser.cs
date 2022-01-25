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

    public class AsmOcParser
    {
        public static AsmOcClass classify(string src)
        {
            if(evex(src))
                return AsmOcClass.Evex;
            else if(vex(src))
                return AsmOcClass.Vex;
            else if(rex(src))
                return AsmOcClass.Rex;
            else
                return AsmOcClass.General;
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

        AsmOcDatasets Datasets;

        public AsmOcParser()
        {
            Datasets = AsmOcDatasets.load();
        }

        [Parser]
        public static Outcome parse(string src, out AsmOcSpec dst)
        {
            var result = Outcome.Success;
            var parts = text.trim(text.split(text.despace(src),Chars.Space));
            var count = (byte)min(parts.Length, 15);
            dst = AsmOcSpec.Empty;
            dst.TokenCount = count;
            dst.OcClass = classify(src);
            for(var i=0; i<count; i++)
            {
                ref readonly var expr = ref skip(parts,i);
                if(octoken(expr, out var token))
                {
                    dst[i] = token;
                }
                else
                {
                    result = (false, string.Format("A token matching the expression '{0}' was not found", expr));
                    break;
                }
            }
            return result;
        }

        static bool octoken(string src, out AsmOcToken dst)
            => _Datasets.TokensByExpression.Find(src, out dst);

        public bool Token(string src, out AsmOcToken dst)
            => Datasets.TokensByExpression.Find(src, out dst);

        public Outcome Parse(string src, out AsmOcSpec dst)
            => parse(src, out dst);

        // {
        //     var result = Outcome.Success;
        //     var parts = text.trim(text.split(text.despace(src),Chars.Space));
        //     var count = (byte)min(parts.Length, 15);
        //     dst = AsmOcSpec.Empty;
        //     dst.TokenCount = count;
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var expr = ref skip(parts,i);
        //         if(Token(expr, out var token))
        //         {
        //             dst[i] = token;
        //         }
        //         else
        //         {
        //             result = (false, string.Format("A token matching the expression '{0}' was not found", expr));
        //             break;
        //         }
        //     }
        //     return result;
        // }

        static AsmOcParser()
        {
            _Datasets = AsmOcDatasets.load();
        }

        static AsmOcDatasets _Datasets;
    }
}