//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    partial class XTend
    {
        public static ISet<T> Intersection<T>(this ISet<T> s1, ISet<T> s2)
        {
            var dst = new HashSet<T>(s1);
            dst.IntersectWith(s2);
            return dst;
        }

        /// <summary>
        /// Computes the intersection of a target set with source sets specified in a parameter array
        /// </summary>
        /// <param name="dst">The target set</param>
        /// <param name="src">The source sets</param>
        /// <typeparam name="T">The item type</typeparam>
        public static ISet<T> Intersect<T>(this ISet<T> dst, params ISet<T>[] src)
        {
            src.Iter(set => set.Iter(item => dst.Add(item)));
            return dst;
        }
    }
}