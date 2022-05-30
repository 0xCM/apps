//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static AsmOcTokens;

    partial class AsmOpCodes
    {
        public static Outcome parse(ReadOnlySpan<char> src, out AsmOpCode dst)
            => parse(text.format(src), out dst);

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
                        tokens.Add(TokenSymbols.Dot);

                    tokens.Add(skip(dotted, m));
                }

                for(var m = 0; m<spaced.Length; m++)
                {
                    tokens.Add(TokenSymbols.Sep);
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
                        tokens.Add(TokenSymbols.Sep);

                    tokens.Add(skip(comps,m));
                }

                parts = tokens.ToArray();
            }

            var count = (byte)min(parts.Length, AsmOpCode.TokenCapacity);
            dst.TokenCount = count;
            for(var i=0; i<count; i++)
            {
                var expr = skip(parts,i);
                if(AsmTokens.opcode(expr, out var t))
                    dst[i] = t;
                else
                {
                    result = (false, string.Format("A token matching the expression '{0}' was not found", expr));
                    break;
                }
            }
            return result;
        }
    }
}