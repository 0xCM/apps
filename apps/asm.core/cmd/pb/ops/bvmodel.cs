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
        public static BfModel bvmodel(BfOrigin origin, string name, ReadOnlySpan<ListItem> src)
        {
            var count = src.Length;
            var segs = alloc<BfSegModel>(count);
            for(var i=0u; i<count; i++)
                seek(segs,i) = Bitfields.segmodel(skip(src,i).Value.Format(), i, i, i >= 64 ? BitMask.one(63) : BitMask.one((byte)i));
            return Bitfields.model(origin, name, segs);
        }
    }
}