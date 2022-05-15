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
                => new BfDataset<F,T>(Symbols.index<F>().Kinds.ToArray(), indices<F>(), BfDatasets.widths<W>());

        public static BfdDataset<F> create<F>(asci64 name, params byte[] widths)
            where F : unmanaged,Enum
                => new BfdDataset<F>(Symbols.kinds<F>().ToArray(), indices<F>(), widths);

        public static BfDataset create(asci64 name, Index<string> fields, Index<byte> widths)
            => new BfDataset(name, fields, core.mapi(fields, (i,x) => (x,(uint)i)).ToDictionary(), widths);
    }
}