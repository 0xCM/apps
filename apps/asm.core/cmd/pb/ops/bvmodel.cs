//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class PolyBits
    {
        /// <summary>
        /// Defines a bitfield specification that represents a bitvector
        /// </summary>
        /// <param name="name">The bitvector name</param>
        /// <param name="src">The list items that correspond to bits in the vector</param>
        public static BitfieldModel bvmodel(BfOrigin origin, string name, ReadOnlySpan<ListItem> src)
        {
            var count = src.Length;
            var segs = alloc<BitfieldSegModel>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var item = ref skip(src,i);
                seek(segs,i) = Bitfields.segmodel(item.Value.Format(), i, i);
            }

            return Bitfields.model(origin, name, segs);
        }
    }
}