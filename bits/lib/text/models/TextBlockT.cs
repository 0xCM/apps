//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TextBlock<T> : ITextBlock<T>
        where T : ITextual
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public TextBlock(T src)
            => Content = src;

        public string Format()
            => Content.Format();

        public override string ToString()
            => Format();

        public static implicit operator TextBlock<T>(T content)
            => new TextBlock<T>(content);

        public static implicit operator TextBlock(TextBlock<T> src)
            => new TextBlock(src.Format());
    }
}