//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    partial class XTend
    {
        /// <summary>
        /// Determines whether a set is empty
        /// </summary>
        /// <typeparam name="T">The type of element that may be contained in the set</typeparam>
        /// <param name="set">The set under examination</param>
        [MethodImpl(Inline)]
        public static bool IsEmpty<T>(this ISet<T> set)
            => set.Count == 0;

        /// <summary>
        /// Determines whether a set is nonempty
        /// </summary>
        /// <typeparam name="T">The type of element that may be contained in the set</typeparam>
        /// <param name="set">The set under examination</param>
        [MethodImpl(Inline)]
        public static bool IsNonEmpty<T>(this ISet<T> set)
            => set.Count != 0;

        /// <summary>
        /// Determines whether a collection contains any elements
        /// </summary>
        /// <typeparam name="T">The type of item contained by the collection</typeparam>
        /// <param name="src">The collection to examine</param>
        [MethodImpl(Inline)]
        public static bool IsEmpty<T>(this IReadOnlyCollection<T> src)
             => src.Count == 0;
    }
}