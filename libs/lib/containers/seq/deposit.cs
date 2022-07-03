//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Seq
    {
        [MethodImpl(Inline), Closures(Closure)]
        public static void deposit<T>(ReadOnlySpan<T> src, HashSet<T> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                dst.Add(Spans.skip(src,i));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void deposit<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, HashSet<T> dst)
        {
            var kA = a.Length;
            for(var i=0; i<kA; i++)
                dst.Add(Spans.skip(a,i));

            var kB = b.Length;
            for(var i=0; i<kB; i++)
                dst.Add(Spans.skip(b,i));
        }

        /// <summary>
        /// Deposits a <see cref='ReadOnlySpan{T}'/> into a <see cref='HashSet<T>'/>
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [Op, Closures(Closure)]
        public static HashSet<T> set<T>(ReadOnlySpan<T> src)
        {
            var dst = new HashSet<T>(src.Length);
            deposit(src,dst);
            return dst;
        }

        [Op, Closures(Closure)]
        public static HashSet<T> set<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b)
        {
            var dst = new HashSet<T>(a.Length + b.Length);
            deposit(a,b,dst);
            return dst;
        }
    }
}