//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;
    using static core;
    using static AsmOcTokens;

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
        public static Outcome parse(string src, out AsmOpCode dst)
        {
            var result = Outcome.Success;
            dst = AsmOpCode.Empty;
            dst.OcClass = classify(src);
            var parts = sys.empty<string>();
            var input = text.trim(text.despace(src));
            if(dst.OcClass == AsmOcClass.Vex || dst.OcClass == AsmOcClass.Evex)
            {
                var tokens = list<string>();
                var i = text.index(input, Chars.Space);
                var dotted = text.split(text.left(input,i), Chars.Dot);
                var spaced = text.split(text.right(input, i), Chars.Space);
                for(var m = 0; m<dotted.Length; m++)
                {
                    if(m != 0)
                        tokens.Add(OpCodeText.Dot);
                    tokens.Add(skip(dotted,m));
                }
                for(var m = 0; m<spaced.Length; m++)
                {
                    tokens.Add(OpCodeText.Sep);
                    tokens.Add(skip(spaced,m));
                }

                parts = tokens.ToArray();
            }
            else
            {
                var tokens = list<string>();
                var _parts = text.trim(text.split(input,Chars.Space));
                for(var m=0; m<_parts.Length; m++)
                {
                    if(m != 0)
                        tokens.Add(OpCodeText.Sep);
                    tokens.Add(skip(_parts,m));
                }

                parts = tokens.ToArray();
            }

            var count = (byte)min(parts.Length, AsmOpCode.TokenCapacity);
            dst.TokenCount = count;
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

        public Outcome Parse(string src, out AsmOpCode dst)
            => parse(src, out dst);

        static AsmOcParser()
        {
            _Datasets = AsmOcDatasets.load();
        }

        static AsmOcDatasets _Datasets;
    }
}