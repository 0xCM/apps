//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct seq
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static IndexedSeq<I,T> concat<I,T>(IndexedSeq<I,T> head, IndexedSeq<I,T> tail)
            where I : unmanaged
                => new IndexedSeq<I,T>(array(head.Storage.Concat(tail.Storage)));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static IndexedSeq<T> concat<T>(IndexedSeq<T> head, IndexedSeq<T> tail)
            => new IndexedSeq<T>(array(head.Storage.Concat(tail.Storage)));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static MutableSeq<T> concat<T>(MutableSeq<T> head, MutableSeq<T> tail)
            => new MutableSeq<T>(array(head.Storage.Concat(tail.Storage)));

        /// <summary>
        /// Concatenates the source streams to create a unified stream
        /// </summary>
        /// <param name="head">The first part of the sequence</param>
        /// <param name="tail">The last part of the sequence</param>
        /// <typeparam name="T">The streamed element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Deferred<T> concat<T>(Deferred<T> head, Deferred<T> tail)
            => head.Concat(tail);

        /// <summary>
        /// Concatenates the source streams to create a unified stream
        /// </summary>
        /// <param name="s1">The leading segment</param>
        /// <param name="s2">The second segment</param>
        /// <param name="s3">The terminal segment</param>
        /// <typeparam name="T">The streamed element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Deferred<T> concat<T>(Deferred<T> s1, Deferred<T> s2, Deferred<T> s3)
            => s1.Concat(s2).Concat(s3);
    }
}