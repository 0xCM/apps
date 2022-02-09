//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [ApiHost]
    public class AsmOpCodes : AppService<AsmOpCodes>
    {
        readonly AsmOcParser Parser;

        public AsmOpCodes()
        {
            Parser = new AsmOcParser();
        }

        public Outcome Parse(string src, out AsmOpCode dst)
            => Parser.Parse(src, out dst);

        public static AsmOcTokenSet tokens()
            => Datasets.TokenSet;

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