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

        public static string expression(AsmOcToken src)
        {
            if(src.IsEmpty)
                return EmptyString;

            if(Datasets.Expressions.Find(src.Id, out var x))
                return x;

            return RP.Error;
        }

        [MethodImpl(Inline), Op]
        public static AsmOcToken specialize(in AsmToken src)
            => new AsmOcToken((AsmOcTokenKind)src.KindIndex, (byte)src.Value);

        public Outcome Parse(string src, out AsmOpCode dst)
            => parse(src, out dst);

        public bool Token(string src, out AsmOcToken dst)
            => Datasets.TokensByExpression.Find(src, out dst);

        readonly static AsmOcDatasets Datasets;

        static AsmOpCodes()
        {
            Datasets = AsmOcDatasets.Instance;
        }
   }
}