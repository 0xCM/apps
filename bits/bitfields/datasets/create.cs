//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BfDatasets
    {
        public static BitfieldDataset<F,T> create<F,W,T>()
            where F : unmanaged, Enum
            where W : unmanaged, Enum
            where T : unmanaged
                => new BitfieldDataset<F,T>(Symbols.index<F>().Kinds.ToArray(), BfDatasets.widths<W>());

        public static BitfieldDataset create(params byte[] widths)
            => new BitfieldDataset(widths, Chars.Space);

        public static BitfieldDataset<F> create<F>(params byte[] widths)
            where F : unmanaged,Enum
                => new BitfieldDataset<F>(Symbols.kinds<F>().ToArray(), widths, Chars.Space);
    }
}