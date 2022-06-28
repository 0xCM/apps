//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial struct Arrays
    {

        [MethodImpl(Inline)]
        public static T[] array<T>(IEnumerable<T> src)
            => src == null ? System.Array.Empty<T>() : src.ToArray();

        [MethodImpl(Inline)]
        public static T[] array<T>(List<T> src)
            => src.ToArray();

        [MethodImpl(Inline)]
        public static T[] array<T>(Span<T> src)
            => src.ToArray();

        /// <summary>
        /// Returns an empty array
        /// </summary>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] array<T>()
            => Array.Empty<T>();

        [MethodImpl(Inline)]
        public static T[] array<T>(params T[] src)
            => src;
    }
}