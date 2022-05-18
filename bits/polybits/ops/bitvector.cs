//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        public static Index<BfModel> bitvectors(DbSources sources, string filter)
            => bitvectors(sources.Files(FileKind.Csv).Where(f => f.FileName.StartsWith(filter)));

        [MethodImpl(Inline), Op]
        public static BfModel model(BfOrigin origin, string name, Index<BfSegModel> segs)
            => new BfModel(origin, name, segs, Bitfields.totalwidth(segs));

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
                seek(bitfields, i) = bitvector(origin(source.ToUri()), source.FileName.WithoutExtension.Format(), items);
            }

            return bitfields;
        }

        /// <summary>
        /// Defines a bitfield specification that represents a bitvector
        /// </summary>
        /// <param name="name">The bitvector name</param>
        /// <param name="src">The list items that correspond to bits in the vector</param>
        public static BfModel bitvector(BfOrigin origin, string name, ReadOnlySpan<ListItem> src)
        {
            var count = src.Length;
            var segs = alloc<BfSegModel>(count);
            for(var i=0u; i<count; i++)
                seek(segs,i) = seg(skip(src,i).Value.Format(), i, i, i >= 64 ? BitMask.one(64,63) : BitMask.one((byte)i,(byte)i));
            return model(origin, name, segs);
        }
    }
}