//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BfDatasets
    {
        public static BfDataset<F,T> create<F,W,T>(asci64 name)
            where F : unmanaged, Enum
            where W : unmanaged, Enum
            where T : unmanaged
                => new BfDataset<F,T>(name, Symbols.index<F>().Kinds.ToArray(), indices<F>(), BfDatasets.widths<W>());

        public static BfDataset<F,T> create<F,T>(asci64 name, params byte[] widths)
            where F : unmanaged, Enum
            where T : unmanaged
                => new BfDataset<F,T>(name, Symbols.index<F>().Kinds.ToArray(), indices<F>(), widths);

        public static BfDataset<F> create<F>(asci64 name, params byte[] widths)
            where F : unmanaged,Enum
                => new BfDataset<F>(name, Symbols.kinds<F>().ToArray(), indices<F>(), widths);

        public static BfDataset<F> create<F>(asci64 name, ReadOnlySpan<byte> widths)
            where F : unmanaged,Enum
                => new BfDataset<F>(name, Symbols.kinds<F>().ToArray(), indices<F>(), widths.ToArray());

        public static BfDataset create(asci64 name, Index<string> fields, Index<byte> widths)
            => new BfDataset(name, fields, core.mapi(fields, (i,x) => (x,(uint)i)).ToDictionary(), widths);
    }
}