//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Bitfields
    {
        // public static Index<BitfieldModel> bvlists(FS.Files src)
        // {
        //     var items = sys.empty<ListItem>();
        //     var counter = 0u;
        //     var count = src.Count;
        //     var bitfields = alloc<BitfieldModel>(count);
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var source = ref src[i];
        //         Tables.list(source, out items).Require();
        //         seek(bitfields, i) = Bitfields.bitvector(Bitfields.origin(source.ToUri()), source.FileName.WithoutExtension.Format(), items);
        //     }

        //     return bitfields;
        // }

        // [Op]
        // public static BitfieldModel bitvector(BfOrigin origin, string name, ReadOnlySpan<ListItem> src)
        // {
        //     var count = src.Length;
        //     var segs = alloc<BitfieldSegModel>(count);
        //     for(var i=0u; i<count; i++)
        //     {
        //         ref readonly var item = ref skip(src,i);
        //         seek(segs,i) = Bitfields.segmodel(item.Value.Format(), i, i);
        //     }

        //     return Bitfields.model(origin, name, segs);
        // }
    }
}