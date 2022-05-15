//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        public static Index<BfInterval<F>> intervals<F>(BfdDataset<F> src)
            where F : unmanaged, Enum
                => map(src.Fields, field => new BfInterval<F>(field, src.Offset(field), src.Width(field)));

        public static Index<BfInterval<F>> intervals<F,T>(BfDataset<F,T> src)
            where F : unmanaged, Enum
            where T : unmanaged
                => map(src.Fields, field => new BfInterval<F>(field, src.Offset(field), src.Width(field)));
    }
}