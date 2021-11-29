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
    /// Covers an A-parametric sequence of asci sequences
    /// </summary>
    public readonly struct AsciSequence<A> : IAsciSeq, IByteSeq<A>
        where A : unmanaged, IByteSeq
    {
        public A Content {get;}

        [MethodImpl(Inline)]
        public AsciSequence(A src)
            => Content = src;

        public string Format()
            => Content.Format();

        public TextBlock Text
        {
            [MethodImpl(Inline)]
            get => Format();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator A(AsciSequence<A> src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator AsciSequence<A>(A src)
            => new AsciSequence<A>(src);
    }
}