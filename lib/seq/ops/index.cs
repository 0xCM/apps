//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial struct Seq
    {
        /// <summary>
        /// Creates a <see cref='Index{I,T}'/> from an array
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        /// <typeparam name="I">The index type</typeparam>
        [MethodImpl(Inline)]
        public static Index<I,T> index<I,T>(T[] src)
            where I : unmanaged
                => new Index<I,T>(src);

        /// <summary>
        /// Creates an indexed sequence from a stream
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static IndexedSeq<T> index<T>(IEnumerable<T> src)
            => new IndexedSeq<T>(src.Array());

        /// <summary>
        /// Creates an indexed sequence from a stream
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static IndexedSeq<I,T> index<I,T>(IEnumerable<T> src)
            where I : unmanaged
                => new IndexedSeq<I,T>(src.ToArray());

        /// <summary>
        /// Creates an indexed sequence from a parameter array
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static IndexedSeq<T> index<T>(params T[] src)
            => new IndexedSeq<T>(src, true);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DelimitedIndex<object> index(char delimiter, int pad, params object[] src)
            => new DelimitedIndex<object>(src, delimiter, pad);
    }
}