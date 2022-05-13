//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Bitfields
    {
        public static BitfieldDataset<F,T> dataset<F,W,T>()
            where F : unmanaged, Enum
            where W : unmanaged, Enum
            where T : unmanaged
                => new BitfieldDataset<F,T>(Symbols.index<F>().Kinds.ToArray(), BfDatasets.widths<W>());

        public static BitfieldDataset dataset(params byte[] widths)
            => new BitfieldDataset(widths, Chars.Space);

        public static BitfieldDataset<F> dataset<F>(params byte[] widths)
            where F : unmanaged,Enum
                => new BitfieldDataset<F>(Symbols.kinds<F>().ToArray(), widths, Chars.Space);
    }
}