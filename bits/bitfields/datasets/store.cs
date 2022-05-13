//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        [MethodImpl(Inline)]
        public static Index<BitfieldCell<T>> store<T>(BitfieldDataset spec, in T src, Index<BitfieldCell<T>> dst)
            where T : unmanaged
        {
            for(var i=0; i<spec.FieldCount; i++)
                dst[i].Value = segment(src, spec.Offset(i), spec.Width(i));
            return dst;
        }

        [MethodImpl(Inline)]
        public static void store<F,T>(BitfieldDataset<F,T> spec, in T src, Index<F,BitfieldCell<T>> dst)
            where F : unmanaged, Enum
            where T : unmanaged
        {
            for(var i=0u; i<spec.FieldCount; i++)
                dst[@as<uint,F>(i)].Value = extract(spec, spec.Fields[i], src);
        }

        [MethodImpl(Inline)]
        public static Index<BitfieldCell<T>> store<T>(in T src, Index<uint> offsets, Index<byte> widths, Index<BitfieldCell<T>> dst)
            where T : unmanaged
        {
            var count = Require.equal(Require.equal(offsets.Count, widths.Count), dst.Count);
            for(var i=z8; i<count; i++)
                dst[i].Value = segment(src, offsets[i], widths[i]);
            return dst;
        }
    }
}