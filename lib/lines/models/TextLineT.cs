//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TextLine<T> : ITextLine<T>
        where T : ITextBlock<T>
    {
        public uint LineNumber {get;}

        public T Content {get;}

        [MethodImpl(Inline)]
        public TextLine(uint number, T content)
        {
            LineNumber = number;
            Content = content;
        }
        public string Format()
            => Content.Format();

        public override string ToString()
            => Format();

        public static implicit operator TextBlock<T>(TextLine<T> src)
            => src.Content;
    }
}