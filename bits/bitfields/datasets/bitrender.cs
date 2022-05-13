//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly partial struct BfDatasets
    {
        /// <summary>
        /// Creates a bitfield render pattern predicated on a sequence of segment widths
        /// </summary>
        /// <param name="widths"></param>
        public static string bitrender(Index<byte> widths, char sep = Chars.Space)
        {
            var dst = text.buffer();
            var count = widths.Count;
            for(var i=0u; i<count; i++)
            {
                var slot = RP.slot(i, math.negate((sbyte)widths[i]));
                dst.Append(slot);
                if(i != count - 1)
                    dst.Append(sep);
            }
            return dst.Emit();
        }

        /// <summary>
        /// Creates a bitfield render pattern predicated a dataset definition
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="F"></typeparam>
        /// <typeparam name="T"></typeparam>
        public static string bitrender<F,T>(BitfieldDataset<F,T> src)
            where F : unmanaged, Enum
            where T : unmanaged
        {
            var dst = text.buffer();
            var fields = src.Fields;
            for(var i=0u; i<src.FieldCount; i++)
            {
                ref readonly var field = ref src.Fields[i];
                ref readonly var w = ref src.Width(field);
                var slot = RP.slot(i, math.negate((sbyte)w));
                dst.Append(slot);
                if(i != src.FieldCount - 1)
                    dst.Append(Chars.Space);
            }
            return dst.Emit();
        }
    }
}