//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public partial class AsmSigs
    {
        static AsmSigDatasets Datasets;

        const NumericKind Closure = UnsignedInts;

        static AsmSigs()
        {
            Datasets = AsmSigDatasets.load();
        }

        public static AsmSigTokenSet tokens()
            => Datasets.TokenSet;
    }
}