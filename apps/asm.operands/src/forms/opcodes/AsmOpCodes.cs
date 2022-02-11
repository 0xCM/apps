//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static AsmOcTokens;

    [ApiHost]
    public class AsmOpCodes : AppService<AsmOpCodes>
    {
        public AsmOpCodes()
        {
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

        public static Outcome parse(string src, out AsmOpCode dst)
        {
            var result = Outcome.Success;
            dst = AsmOpCode.Empty;
            var parts = sys.empty<string>();
            var input = text.trim(text.despace(src));
            if(evex(input) || vex(input))
            {
                var tokens = list<string>();
                var i = text.index(input, Chars.Space);
                var dotted = text.trim(text.split(text.left(input,i), Chars.Dot));
                var spaced = text.trim(text.split(text.right(input, i), Chars.Space));
                for(var m = 0; m<dotted.Length; m++)
                {
                    if(m != 0)
                        tokens.Add(OpCodeText.Dot);

                    tokens.Add(skip(dotted, m));
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
                var comps = text.trim(text.split(input,Chars.Space));
                for(var m=0; m <comps.Length; m++)
                {
                    if(m != 0)
                        tokens.Add(OpCodeText.Sep);

                    tokens.Add(skip(comps,m));
                }

                parts = tokens.ToArray();
            }

            var count = (byte)min(parts.Length, AsmOpCode.TokenCapacity);
            dst.TokenCount = count;
            for(var i=0; i<count; i++)
            {
                var expr = skip(parts,i);
                if(octoken(expr, out var token))
                    dst[i] = token;
                else
                {
                    result = (false, string.Format("A token matching the expression '{0}' was not found", expr));
                    break;
                }
            }
            return result;
        }

        public static bool octoken(string src, out AsmOcToken dst)
            => Datasets.TokensByExpression.Find(src, out dst);

        public Outcome Parse(string src, out AsmOpCode dst)
            => parse(src, out dst);

        public static AsmOcTokenSet tokens()
            => Datasets.TokenSet;

        public static AsmOcDatasets datasets()
            => Datasets;
        public static string format(AsmOcToken src)
            => Datasets.TokenExpressions[src];

        public static string format(in AsmOpCode src)
        {
            var dst = text.buffer();
            var count = src.TokenCount;
            for(var i=0; i<count; i++)
                dst.Append(expression(src[i]));
            return dst.Emit();
        }

        static string expression(AsmOcToken src)
            => Datasets.TokenExpressions[src];

        [Op]
        public static AsmOpCode define(ReadOnlySpan<AsmOcToken> src)
        {
            var storage = @as<AsmOcToken,Cell512>(src);
            var tokens = recover<AsmOcToken>(storage.Bytes);
            var counter = z8;
            for(var i=0; i<AsmOpCode.TokenCapacity; i++)
            {
                if(skip(tokens,i) != 0)
                    counter++;
                else
                    break;
            }

            storage.Cell8(31) = counter;
            return new AsmOpCode(storage);
        }

        public string Format(in AsmOpCode src)
        {
            var dst = text.buffer();
            var count = src.TokenCount;
            for(var i=0; i<count; i++)
                dst.Append(Expression(src[i]));
            return dst.Emit();
        }

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<AsmOcTokenKind> TokenKinds()
            => Datasets.TokenKindSymbols.Kinds;

        public string Expression(AsmOcToken src)
            => Datasets.TokenExpressions[src];

        public bool Token(string src, out AsmOcToken dst)
            => Datasets.TokensByExpression.Find(src, out dst);

        public ReadOnlySpan<string> Expressions()
            => Datasets.TokenExpressions.Values;

        public ReadOnlySpan<AsmOcToken> Tokens(AsmOcTokenKind kind)
            => Datasets.TokensByKind[kind];


        readonly static AsmOcDatasets Datasets;

        static AsmOpCodes()
        {
            Datasets = AsmOcDatasets.load();
        }
   }
}