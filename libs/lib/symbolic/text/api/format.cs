//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    partial class text
    {
        [Op]
        public static string format(ReadOnlySpan<AsciCode> src)
            => format(src, core.span<char>(src.Length));

        [Op]
        public static string format(ReadOnlySpan<char> src, uint length)
            => new string(core.slice(src,0, length));

        [Op]
        public static string format(ReadOnlySpan<AsciCode> src, Span<char> buffer)
        {
            var count = AsciSymbols.decode(src, buffer);
            return new string(core.slice(buffer,0, count));
        }

        /// <summary>
        /// Creates a string from a span, via a specified encoding
        /// </summary>
        /// <param name="src">The data source</param>
        [Op]
        public static unsafe string format(ReadOnlySpan<byte> src, Encoding encoding)
        {
            if(src.IsEmpty)
                return EmptyString;

            fixed(byte* pSrc = src)
                return encoding.GetString(pSrc, src.Length);
        }

        [MethodImpl(Inline), Op]
        public static string format(ReadOnlySpan<char> src)
            => new string(src);

        [MethodImpl(Inline), Op]
        public static string format(ReadOnlySpan<char> src, bool trim)
            => new string(trim ? src.Trim() : src);

        [MethodImpl(Inline), Op]
        public static string format(char[] src)
            => new string(src);
   }
}