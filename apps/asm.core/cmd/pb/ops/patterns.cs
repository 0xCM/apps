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
        /// Creates pattern definitions predicated on tehe literal string fields in a specified type
        /// </summary>
        /// <param name="src">The defining type</param>
        public static Index<BitPattern> patterns(Type src)
        {
            var strings = Resources.strings(src);
            var props = src.Properties().Static().Where(x => x.PropertyType == typeof(BitPattern)).Index();
            var fields = src.Fields().Static().Where(x => x.FieldType == typeof(BitPattern)).Index();
            var count = strings.Count + props.Count + fields.Count;
            Index<BitPattern> dst = alloc<BitPattern>(count);

            var k=0u;
            for(var i=0; i<strings.Length; i++,k++)
            {
                ref readonly var res = ref strings[i];
                dst[k] = BitPatterns.infer(Bitfields.origin(res.Source), res.Value);
            }

            for(var i=0; i<props.Length; i++, k++)
                dst[k] = (BitPattern)props[i].GetValue(null);

            for(var i=0; i<fields.Length; i++, k++)
                dst[k] = (BitPattern)fields[i].GetValue(null);
            return dst;
        }
    }
}