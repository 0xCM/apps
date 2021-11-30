//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public readonly struct RenderFunctions
    {
        public delegate void RenderCellText<T>(in T src, ITextBuffer dst);

        public delegate void RenderSeqText<T>(ReadOnlySpan<T> src, ITextBuffer dst);

        public delegate uint RenderSeq<S>(ReadOnlySpan<S> src, Span<char> dst);

        public delegate uint RenderCell<S,T>(in S src, Span<T> dst);

        public delegate uint RenderSeq<S,T>(ReadOnlySpan<S> src, Span<T> dst);
    }

}