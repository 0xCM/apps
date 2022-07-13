//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Presents a mutable span as a readonly span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> ReadOnly<T>(this Span<T> src)
            => src;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Invert<T>(this Span<T> src)
        {
            src.Reverse();
            return src;
        }

        /// <summary>
        /// Linq where operator specialized for arrays
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="f"></param>
        /// <typeparam name="T">The array element type</typeparam>
        [MethodImpl(Inline)]
        public static T[] Where<T>(this T[] src, Func<T,bool> f)
            => Spans.where(src,f).ToArray();
    }
}