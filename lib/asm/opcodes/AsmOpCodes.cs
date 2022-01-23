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

    [ApiHost]
    public class AsmOpCodes : AppService<AsmOpCodes>
    {
        readonly AsmOcDatasets _Datasets;

        readonly AsmOcParser Parser;
        public AsmOpCodes()
        {
            _Datasets = AsmOcDatasets.load();
            Parser = new AsmOcParser();
        }

        public Outcome Parse(string src, out AsmOcSpec dst)
            => Parser.Parse(src, out dst);
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

        public string Format(in AsmOcSpec src)
        {
            var dst = text.buffer();
            var count = src.TokenCount;
            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Space);
                dst.Append(Expression(src[i]));
            }
            return dst.Emit();
        }

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<AsmOcToken> Tokens()
            => _Datasets.Tokens;

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<AsmOcTokenKind> TokenKinds()
            => _Datasets.TokenKindSymbols.Kinds;

        public string Expression(AsmOcToken src)
            => _Datasets.TokenExpressions[src];

        public bool Token(string src, out AsmOcToken dst)
            => _Datasets.TokensByExpression.Find(src, out dst);

        public ReadOnlySpan<string> Expressions()
            => _Datasets.TokenExpressions.Values;

        public ReadOnlySpan<AsmOcToken> Tokens(AsmOcTokenKind kind)
            => _Datasets.TokensByKind[kind];
   }
}