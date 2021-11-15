//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct seq
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
        public static DelimitedIndex<T> index<T>(char delimiter, int pad, T[] src)
            where T : unmanaged
                => new DelimitedIndex<T>(src, unspaced, delimiter, pad);

        [Op, Closures(Closure)]
        static string unspaced<T>(ReadOnlySpan<T> src, char delimiter, int pad)
            => text.delimit(src, delimiter, pad, false);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DelimitedIndex<object> index(char delimiter, int pad, params object[] src)
            => new DelimitedIndex<object>(src, delimiter, pad);
    }
}