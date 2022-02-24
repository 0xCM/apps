//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static AsmOcTokens;
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
        {
            if(Datasets.TokenExpressions.Find(src.Id, out var x))
            {
                return x;
            }
            else
                return RP.Error;
        }

        public bool Token(string src, out AsmOcToken dst)
            => Datasets.TokensByExpression.Find(src, out dst);

        public ReadOnlySpan<string> Expressions()
            => Datasets.TokenExpressions.Values;


        readonly static AsmOcDatasets Datasets;

        static AsmOpCodes()
        {
            Datasets = AsmOcDatasets.load();
        }
   }
}