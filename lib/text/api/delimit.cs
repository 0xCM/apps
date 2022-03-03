//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class text
    {
        public static string delimit<T>(ReadOnlySpan<T> src, string sep, int pad = 0)
        {
            var dst = text.buffer();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(i!=0)
                    dst.Append(sep);
                dst.AppendFormat(RP.pad(pad), skip(src,i));
            }
            return dst.Emit();
        }

        public static string delimit<T>(T[] src, string sep, int pad = 0)
            => delimit(@readonly(src), sep, pad);

        public static string delimit<T>(Span<T> src,string sep, int pad = 0)
            => delimit(@readonly(src), sep, pad);

        public static string delimit<T>(Index<T> src,string sep, int pad = 0)
            => delimit(src.View, sep, pad);

        [Op, Closures(Closure)]
        public static string delimit<T>(T[] src, char sep)
            => delimit(@readonly(src), sep);

        [Op, Closures(Closure)]
        public static string delimit<T>(IEnumerable<T> src, char sep)
            => string.Join(sep, src);

        [Op, Closures(Closure)]
        public static string delimit<T>(ReadOnlySpan<T> src, char sep, int pad)
        {
            var dst = buffer();
            var count = src.Length;
            var slot = RP.pad(pad);
            var last = count - 1;
            for(var i=0; i<count; i++)
            {
                dst.AppendFormat(slot, skip(src,i));
                if(i != last)
                    dst.Append(sep);
            }
            return dst.Emit();
        }

        [Op, Closures(Closure)]
        public static string delimit<T>(ReadOnlySpan<T> src, char sep)
        {
            var dst = buffer();
            var count = src.Length;
            var last = count - 1;
            for(var i=0; i<count; i++)
            {
                dst.AppendItem(skip(src,i));
                if(i != last)
                    dst.Append(sep);

            }
            return dst.ToString();
        }

        [Op, Closures(Closure)]
        public static string delimit<T>(IEnumerable<T> src, char sep, int pad)
            => delimit(src.ToSpan().ReadOnly(), sep, pad);
    }
}