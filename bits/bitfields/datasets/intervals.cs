//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        public static Index<BitfieldInterval<F>> intervals<F>(BitfieldDataset<F> src)
            where F : unmanaged, Enum
                => map(src.Fields, field => new BitfieldInterval<F>(src.Offset(field), src.Width(field),field));

        public static Index<BitfieldInterval<F>> intervals<F,T>(BitfieldDataset<F,T> src)
            where F : unmanaged, Enum
            where T : unmanaged
                => map(src.Fields, field => new BitfieldInterval<F>(src.Offset(field), src.Width(field), field));
    }
}