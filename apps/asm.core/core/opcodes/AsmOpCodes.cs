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
        readonly AsmOcDatasets _Datasets;

        readonly AsmOcParser Parser;

        public AsmOpCodes()
        {
            _Datasets = AsmOcDatasets.load();
            Parser = new AsmOcParser();
        }

        public Outcome Parse(string src, out AsmOpCode dst)
            => Parser.Parse(src, out dst);

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