//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using System.Runtime.Intrinsics;

    using static Root;

    using api = perm;

    partial class XTend
    {
        /// <summary>
        /// Shuffles the permutation in-place using a provided random source.
        /// </summary>
        /// <param name="random">The random source</param>
        [MethodImpl(Inline)]
        static ref readonly perm shuffle(in perm src, IBoundSource random)
        {
            random.Shuffle(src.Terms);
            return ref src;
        }

        /// <summary>
        /// Shuffles the permutation in-place using a provided random source.
        /// </summary>
        /// <param name="random">The random source</param>
        static NatPerm<N> Shuffle22<N>(NatPerm<N> perm, IBoundSource random)
            where N : unmanaged, ITypeNat
        {
            shuffle(perm, random);
            return perm;
        }

        public static NatPerm<N4> ToNatural(this Perm4L src)
            => api.natural(src);

        public static NatPerm<N8> ToNatural(this Perm8L src)
            => api.natural(src);

        public static NatPerm<N16> ToNatural(this Perm16L src)
            => api.natural(src);

        /// <summary>
        /// Produces a stream of random permutation of natural length N
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="n">The length representative</param>
        /// <param name="rep">A primal type representative</param>
        /// <typeparam name="N">The length type</typeparam>
        /// <typeparam name="T">The primal symbol type</typeparam>
        public static IEnumerable<NatPerm<N>> Perms<N>(this IBoundSource random, N n = default)
            where N : unmanaged, ITypeNat
        {
            while(true)
                yield return random.Perm(n);
        }

        /// <summary>
        /// Produces a random permutation of natural length N
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="n">The length representative</param>
        /// <param name="rep">A primal type representative</param>
        /// <typeparam name="N">The length type</typeparam>
        /// <typeparam name="T">The primal symbol type</typeparam>
        [MethodImpl(Inline)]
        public static NatPerm<N> Perm<N>(this IBoundSource random, N n = default)
            where N : unmanaged, ITypeNat
                => Shuffle22(api.natural(n), random);

        public static Swap[] Unsized<N>(this NatSwap<N>[] src)
            where N : unmanaged, ITypeNat
        {
            var dst = new Swap[src.Length];
            for(var i=0; i<src.Length; i++)
                dst[i] = src[i];
            return dst;
        }

        public static Swap<T>[] Unsized<N,T>(this NatSwap<N,T>[] src)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var dst = new Swap<T>[src.Length];
            for(var i=0; i<src.Length; i++)
                dst[i] = src[i];
            return dst;
        }

        /// <summary>
        /// Shuffles span content as determined by a permutation
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="p">The permutation to apply</param>
        public static Span<T> Permute<T>(this ReadOnlySpan<T> src, perm p)
        {
            Span<T> dst = new T[src.Length];
            for(var i=0; i<p.Length; i++)
                dst[i] = src[p[i]];
            return dst;
        }

        /// <summary>
        /// Shuffles span content as determined by a permutation
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="p">The permutation to apply</param>
        [MethodImpl(Inline)]
        public static Span<T> Permute<T>(this Span<T> src, perm p)
            => src.ReadOnly().Permute(p);

        /// <summary>
        /// Applies a sequence of transpositions to source span elements
        /// </summary>
        /// <param name="src">The source and target span</param>
        /// <param name="i">The first index</param>
        /// <param name="j">The second index</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> Swap<T>(this Span<T> src, params Swap[] swaps)
            where T : unmanaged
        {
            api.apply(src, swaps);
            return src;
        }

        /// <summary>
        /// Formats the terms of a permutation
        /// </summary>
        /// <param name="terms">The permutation terms</param>
        /// <param name="colwidth">The width of each column</param>
        /// <typeparam name="T">The term type</typeparam>
        public static string FormatAsPerm<T>(this Span<T> terms,  int? colwidth = null)
            => terms.ReadOnly().FormatAsPerm(colwidth);

        /// <summary>
        /// Formats the terms of a permutation
        /// </summary>
        /// <param name="terms">The permutation terms</param>
        /// <param name="colwidth">The width of each column</param>
        /// <typeparam name="T">The term type</typeparam>
        public static string FormatAsPerm<T>(this ReadOnlySpan<T> terms,  int? colwidth = null)
        {
            var line1 = text.build();
            var line2 = text.build();
            var pad = colwidth ?? 3;
            var leftBoundary = $"{Chars.Pipe}";
            var rightBoundary = $"{Chars.Pipe}".PadLeft(2);

            line1.Append(leftBoundary);
            line2.Append(leftBoundary);
            for(var i=0; i < terms.Length; i++)
            {
                line1.Append($"{i}".PadLeft(pad));
                line2.Append($"{terms[i]}".PadLeft(pad));
            }
            line1.Append(rightBoundary);
            line2.Append(rightBoundary);

            return line1.ToString() + Eol + line2.ToString();
        }

        /// <summary>
        /// Formats a sequence of successive transpositions (a chain)
        /// </summary>
        /// <param name="src">The transpositions</param>
        [MethodImpl(Inline)]
        public static string Format(this Swap[] src)
            => string.Join(" -> ", src.Map(x => x.Format()));

        /// <summary>
        /// Applies a sequence of transpositions to a blocked container
        /// </summary>
        /// <param name="src">The source and target span</param>
        /// <param name="i">The first index</param>
        /// <param name="j">The second index</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static SpanBlock128<T> Swap<T>(this SpanBlock128<T> src, params Swap[] swaps)
            where T : unmanaged
        {
             if(swaps == null || swaps.Length == 0)
                return src;

             src.Storage.Swap(swaps);
             return src;
        }

        /// <summary>
        /// Applies a sequence of transpositions to a blocked container
        /// </summary>
        /// <param name="src">The source and target span</param>
        /// <param name="i">The first index</param>
        /// <param name="j">The second index</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static SpanBlock256<T> Swap<T>(this SpanBlock256<T> src, params Swap[] swaps)
            where T : unmanaged
        {
             if(swaps == null || swaps.Length == 0)
                return src;

             src.Storage.Swap(swaps);
             return src;
        }

        /// <summary>
        /// Constructs the canonical literal representation of a natural permutation on 4 symbols
        /// </summary>
        /// <param name="src">The natural permutation</param>
        [MethodImpl(Inline)]
        public static Perm4L ToLiteral(this NatPerm<N4> src)
            => api.pack(src);

        /// <summary>
        /// Constructs the canonical literal representation of a natural permutation on 8 symbols
        /// </summary>
        /// <param name="src">The natural permutation</param>
        [MethodImpl(Inline)]
        public static Perm8L ToLiteral(this NatPerm<N8> src)
            => api.pack(src);

        /// <summary>
        /// Constructs the canonical literal representation of a natural permutation on 16 symbols
        /// </summary>
        /// <param name="src">The natural permutation</param>
        [MethodImpl(Inline)]
        public static Perm16L ToLiteral(this NatPerm<N16> src)
            => api.pack(src);

        /// <summary>
        /// Defines a shuffle spec from a permutation
        /// </summary>
        /// <param name="src">The defining permutation</param>
        [MethodImpl(Inline)]
        public static Vector128<byte> ToShuffleSpec(this NatPerm<N16> src)
            => api.shuffles(src);
    }
}