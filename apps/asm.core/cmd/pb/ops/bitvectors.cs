//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class PolyBits
    {
        public static Index<BfModel> bitvectors(FS.Files src)
        {
            var items = sys.empty<ListItem>();
            var counter = 0u;
            var count = src.Count;
            var bitfields = alloc<BfModel>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var source = ref src[i];
                Tables.list(source, out items).Require();
                seek(bitfields, i) = bitvector(Bitfields.origin(source.ToUri()), source.FileName.WithoutExtension.Format(), items);
            }

            return bitfields;
        }
    }
}