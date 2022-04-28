//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Bitfields
    {
        public static string format<T>(BitfieldCell<T> src)
            where T : unmanaged
        {
            var dw = core.width<T>();
            var bits = EmptyString;
            var offset = dw - src.Interval.Width;
            if(dw == 8)
                bits = bw8(src.Value).FormatBits();
            if(dw == 16)
                bits = bw16(src.Value).FormatBits();
            else if(dw == 32)
                bits = bw32(src.Value).FormatBits();
            else if(dw == 64)
                bits = bw64(src.Value).FormatBits();

            return text.format(slice(span(bits), offset));
        }

        public static string format(BitfieldInterval src)
            => string.Format("[{0}:{1}]", src.Max, src.Min);

        [Op]
        public static string format(Bitfield8 src)
            => text.format(render(src));

        [Op]
        public static string format(Bitfield16 src)
            => text.format(render(src));

        [Op]
        public static string format(Bitfield32 src)
            => text.format(render(src));

        [Op]
        public static string format(Bitfield64 src)
            => text.format(render(src));

        /// <summary>
        /// Formats a field segments as {typeof(V):Name}:{TrimmedBits}
        /// </summary>
        /// <param name="value">The field value</param>
        /// <typeparam name="E">The field value type</typeparam>
        /// <typeparam name="T">The field data type</typeparam>
        public static string format<E,T>(E src, int? zpad = null)
            where E : unmanaged, Enum
            where T : unmanaged
                => format<E,T>(src, typeof(E).Name, zpad);

        /// <summary>
        /// Formats a field segments as {typeof(V):Name}:{TrimmedBits}
        /// </summary>
        /// <param name="value">The field value</param>
        /// <typeparam name="E">The field value type</typeparam>
        /// <typeparam name="T">The field data type</typeparam>
        public static string format<E,T>(E src, string name, int? zpad = null)
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var data = Enums.scalar<E,T>(src);
            var limit = gbits.effwidth(data);
            var config = BitFormat.limited(limit,zpad);
            var formatter = BitRender.formatter<T>(config);
            return string.Concat(name, Chars.Colon, formatter.Format(data));
        }

        public static string format(in BitfieldSegModel src)
        {
            if(src.SegWidth == 1)
            {
                return string.Format("{0}[{1}]:{2}",
                    src.SegName,
                    src.MinIndex,
                    src.SegWidth
                    );
            }
            else
                return string.Format("{0}[{1}:{2}]:{3}",
                    src.SegName,
                    Bitfields.endpos(src.MinIndex, src.SegWidth),
                    src.MinIndex,
                    src.SegWidth
                    );
        }

        public static string format(in BitfieldModel src)
        {
            static string typename(in BitfieldModel src)
                => src.IsBitvector ? "bitvector" : "bitfield";

            static string decl(in BitfieldModel src)
                => string.Format("{0} : {1}<{2}> " , src.Name, typename(src), src.TotalWidth);

            var dst = text.buffer();
            dst.AppendLine(decl(src) + Chars.LBrace);
            var indent = 2u;
            for(var i=0; i<src.SegCount; i++)
            {
                if(i != src.SegCount - 1)
                    dst.IndentLineFormat(indent, "{0},", format(skip(src.Segments,i)));
                else
                    dst.IndentLineFormat(indent, "{0}", format(skip(src.Segments,i)));
            }
            indent -= 2;
            dst.IndentLine(indent,Chars.RBrace);
            return dst.Emit();
        }

        public static string format<K>(in BitfieldSegModel<K> src)
            where K : unmanaged
        {
            var i = endpos(src.MinIndex,src.SegWidth);
            if(i == 0)
                return string.Format("{0}[{1}]", src.SegName, src.MinIndex);
            else
                return string.Format("{0}[{1}:{2}]", src.SegName, src.MinIndex, i);
        }
    }
}