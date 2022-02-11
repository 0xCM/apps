//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [ApiHost]
    public partial class AsmOpCodes : AppService<AsmOpCodes>
    {
        const NumericKind Closure = UnsignedInts;

        public AsmOpCodes()
        {
        }

        public Outcome Parse(string src, out AsmOpCode dst)
            => parse(src, out dst);

        public static AsmOcDatasets datasets()
            => Datasets;

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