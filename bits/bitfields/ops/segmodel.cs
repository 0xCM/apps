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
        static ref asci64 segname(string src, out asci64 dst)
        {
            Demand.lteq(src.Length, asci64.Size);
            dst = src;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static BfSegModel segmodel(string name, uint i0, uint i1, BitMask mask)
            => new BfSegModel(segname(name, out _), i0, i1, mask);

        [MethodImpl(Inline), Op]
        public static BfSegModel<K> segmodel<K>(K segid, uint i0, uint i1, BitMask mask)
            where K : unmanaged
                => new BfSegModel<K>(segname(segid.ToString(), out _), i0, i1, mask);

        public static Index<BfSegModel> segmodels<F,T>(BfDataset<F,T> src)
            where F : unmanaged, Enum
            where T : unmanaged
        {
            var count = src.FieldCount;
            var dst = alloc<BfSegModel>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref src.Field(i);
                ref readonly var width = ref src.Width(field);
                ref readonly var offset = ref src.Offset(field);
                ref readonly var mask = ref src.Mask(field);
                ref readonly var interval = ref src.Interval(field);
                seek(dst,i) = segmodel(field, offset, offset + width -1, mask);
            }
            return dst;
        }
    }
}