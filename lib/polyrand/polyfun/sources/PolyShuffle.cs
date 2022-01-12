//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public static class PolyShuffle
    {
        const NumericKind Closure = AllNumeric;

        /// <summary>
        /// Shuffles span content in-place
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="target">The input/output span</param>
        /// <typeparam name="T">The primal type</typeparam>
        public static Span<T> Shuffle<T>(this IBoundSource src, Span<T> target)
            => shuffle(src,target);

        /// <summary>
        /// Replicates and shuffles a source span
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> Shuffle<T>(this IBoundSource random, ReadOnlySpan<T> src)
            => random.Shuffle(src.Replicate());

        // /// <summary>
        // /// Shuffles the permutation in-place using a provided random source.
        // /// </summary>
        // /// <param name="source">The random source</param>
        // [MethodImpl(Inline)]
        // public static ref readonly Perm<T> Shuffle<T>(this IBoundSource source, in Perm<T> src)
        //     where T : unmanaged
        // {
        //     shuffle(source, src.Terms);
        //     return ref src;
        // }

        /// <summary>
        /// Shuffles span content in-place
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The input/output span</param>
        /// <typeparam name="T">The primal type</typeparam>
        [Op, Closures(Closure)]
        public static Span<T> shuffle<T>(IBoundSource src, Span<T> dst)
        {
            for (var i = 0u; i<dst.Length; i++)
                Swaps.swap(ref core.seek(dst,i), ref core.seek(dst,(uint)(i + src.Next(0, dst.Length - i))));
            return dst;
        }
    }
}