//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        [MethodImpl(Inline), Op]
        public static BitfieldInterval interval(uint offset, byte width)
            => new BitfieldInterval(offset,width);

        /// <summary>
        /// Computes a <see cref='BitfieldInterval'/> sequence given a paired offset/width seqence
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        public static Index<BitfieldInterval> intervals(Index<uint> offsets, Index<byte> widths)
            => mapi(offsets, (i,o)=> interval(o, widths[i]));

        public static Index<BitfieldInterval<F>> intervals<F>(BitfieldDataset<F> src)
            where F : unmanaged, Enum
                => map(src.Fields, field => new BitfieldInterval<F>(src.Offset(field), src.Width(field),field));

        public static Index<BitfieldInterval<F>> intervals<F,T>(BitfieldDataset<F,T> src)
            where F : unmanaged, Enum
            where T : unmanaged
                => map(src.Fields, field => new BitfieldInterval<F>(src.Offset(field), src.Width(field), field));
    }
}