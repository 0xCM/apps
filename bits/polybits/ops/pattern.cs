//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BfDatasets
    {
        [MethodImpl(Inline), Op]
        public static BpSpec spec(in BpInfo src)
        {
            var dst = BpSpec.Empty;
            dst.Origin = src.Origin.Format();
            dst.Content = src.Content;
            dst.DataType = src.DataType.DisplayName();
            dst.Descriptor = src.Descriptor;
            dst.MinSize = src.MinSize;
            dst.Name = src.Name;
            dst.DataWidth = src.DataWidth;
            return dst;
        }

        public static BpInfo pattern<O>(in asci32 name, in asci64 data)
            => pattern(origin<O>(), name, data);

        public static BpInfo pattern(BfOrigin origin, in asci32 name, in asci64 content)
        {
            return new BpInfo(
                BfDatasets.def(origin, name, content),
                BfDatasets.datawidth(content),
                BfDatasets.datatype(content),
                BfDatasets.minsize(content),
                BfDatasets.segs(content),
                descriptor(content)
            );
        }

        public static string descriptor(in asci64 src)
            => text.intersperse(BfDatasets.segs(src).Reverse().Select(x => x.Format()), Chars.Space);

        /// <summary>
        /// Creates a bitfield render pattern predicated on a sequence of segment widths
        /// </summary>
        /// <param name="widths"></param>
        [Op]
        public static string pattern(Index<byte> widths, char sep = Chars.Space)
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
        public static string pattern<F,T>(BfDataset<F,T> src)
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