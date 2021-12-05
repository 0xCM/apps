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
    using static core;

    /// <summary>
    /// Captures a heterogenous pair sequence
    /// </summary>
    /// <typeparam name="T">The sequence element type</typeparam>
    public readonly ref struct Pairings<S,T>
    {
        /// <summary>
        /// The captured sequence
        /// </summary>
        readonly Span<Paired<S,T>> Data;

        [MethodImpl(Inline)]
        public Pairings(Span<Paired<S,T>> data)
            => Data = data;

        /// <summary>
        /// Returns a mutable reference to an index-identified sequence element
        /// </summary>
        /// <param name="index">The zero-based sequence index</param>
        public ref Paired<S,T> this[long index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Data, (uint)index);
        }

        /// <summary>
        /// Returns a mutable reference to an index-identified sequence element
        /// </summary>
        /// <param name="index">The zero-based sequence index</param>
        public ref Paired<S,T> this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Data,index);
        }

        /// <summary>
        /// Specifies the number of elements in the sequence
        /// </summary>
        public int Count
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        /// <summary>
        /// Lifts sequence content into the LINQ monad
        /// </summary>
        public IEnumerable<Paired<S,T>> Enumerate()
            => Data.ToEnumerable();

        [MethodImpl(Inline)]
        public static implicit operator Pairings<S,T>(Span<Paired<S,T>> src)
            => new Pairings<S,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Pairings<S,T>(Paired<S,T>[] src)
            => new Pairings<S,T>(src);
    }
}