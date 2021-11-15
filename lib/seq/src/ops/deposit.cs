//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    partial struct seq
    {
        [MethodImpl(Inline), Closures(Closure)]
        public static void deposit<T>(ReadOnlySpan<T> src, HashSet<T> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                dst.Add(skip(src,i));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void deposit<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, HashSet<T> dst)
        {
            var kA = a.Length;
            for(var i=0; i<kA; i++)
                dst.Add(skip(a,i));

            var kB = b.Length;
            for(var i=0; i<kB; i++)
                dst.Add(skip(b,i));
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