//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        public static BitfieldModel model(text31 name, Index<BitfieldSegModel> segs)
            => new BitfieldModel(name, segs, Bitfields.totalwidth(segs));

        /// <summary>
        /// Defines a bitfield specification that represents a bitvector
        /// </summary>
        /// <param name="name">The bitvector name</param>
        /// <param name="src">The list items that correspond to bits in the vector</param>
        [Op]
        public static BitfieldModel bitvector(string name, ReadOnlySpan<ListItem> src)
        {
            var count = src.Length;
            var segs = alloc<BitfieldSegModel>(count);
            for(var i=z8; i<count; i++)
            {
                ref readonly var item = ref skip(src,i);
                seek(segs,i) = segmodel(item.Value.Format(), i, i);
            }

            return model(name, segs);
        }
    }
}