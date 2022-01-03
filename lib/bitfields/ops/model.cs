//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
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
            for(var i=0u; i<count; i++)
            {
                ref readonly var item = ref skip(src,i);
                seek(segs,i) = segmodel(item.Value.Format(), i, i, i);
            }

            return model(name, segs);
        }
    }
}