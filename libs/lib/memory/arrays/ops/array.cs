//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial struct Arrays
    {
        /// <summary>
        /// Allocates an array of natural length
        /// </summary>
        /// <typeparam name="N">The number of cells in the constructed array</typeparam>
        /// <typeparam name="T">The call type</typeparam>
        public static Array<N,T> array<N,T>()
            where N : unmanaged, ITypeNat
                => new Array<N,T>();

        /// <summary>
        /// Adapts an existing array to a natural array provided the length of the source array agrees with the specified natural length
        /// </summary>
        /// <param name="n">A natural representative</param>
        /// <param name="src">The soruce array</param>
        /// <typeparam name="N">The number of cells in the constructed array</typeparam>
        /// <typeparam name="T">The call type</typeparam>
        public static Array<N,T> array<N,T>(N n, params T[] src)
            where N : unmanaged, ITypeNat
        {
            Require.equal(n.NatValue, (ulong)src.Length);
            return new Array<N,T>(src);
        }

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