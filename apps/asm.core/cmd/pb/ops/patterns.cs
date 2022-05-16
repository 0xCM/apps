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
            var define = BitPatterns.originated(src);
            var count = strings.Count + define.Count;
            Index<BitPattern> dst = alloc<BitPattern>(count);

            var k=0u;
            for(var i=0; i<strings.Length; i++,k++)
            {
                ref readonly var res = ref strings[i];
                dst[k] = BitPatterns.infer(Bitfields.origin(res.Source), res.Source.Name, res.Value);
            }

            for(var i=0; i<define.Count; i++, k++)
                dst[k] = define[i];

            return dst;
        }
   }
}