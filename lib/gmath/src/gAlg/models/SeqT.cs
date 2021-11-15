//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a data structure for sparse/partial sequence representation
    /// </summary>
    public readonly struct Seq<T>
    {
        readonly Index<SeqTerm<T>> Terms;

        [MethodImpl(Inline)]
        public Seq(params SeqTerm<T>[] src)
        {
            if(src.Length != 0)
                Terms = src;
            else
                Terms = Empty.Terms;
        }

        public ReadOnlySpan<SeqTerm<T>> TermView
        {
            [MethodImpl(Inline)]
            get => Terms.View;
        }

        public Span<SeqTerm<T>> TermEdit
        {
            [MethodImpl(Inline)]
            get => Terms.Edit;
        }

        /// <summary>
        /// The number of terms in the sequence
        /// </summary>
        public int Length
        {
            [MethodImpl(Inline)]
            get => Terms.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Terms.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Terms.IsNonEmpty;
        }

        /// <summary>
        /// Returns a reference to an index-identified term
        /// </summary>
        public ref SeqTerm<T> this[long idx]
        {
            [MethodImpl(Inline)]
            get => ref Terms[idx];
        }

        /// <summary>
        /// Returns a reference to an index-identified term
        /// </summary>
        public ref SeqTerm<T> this[ulong idx]
        {
            [MethodImpl(Inline)]
            get => ref Terms[idx];
        }

        /// <summary>
        /// Returns a reference to the first term of the sequence
        /// </summary>
        public ref SeqTerm<T> First
        {
            [MethodImpl(Inline)]
            get => ref this[0];
        }

        public ref SeqTerm<T> Last
        {
            [MethodImpl(Inline)]
            get => ref this[Length - 1];
        }

        public static Seq<T> Empty
            => new Seq<T>(SeqTerm<T>.Empty);
    }
}