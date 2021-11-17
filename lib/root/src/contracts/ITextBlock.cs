//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ITextBlock : ITextual
    {
        string Content {get;}

        uint Length
            => (uint)Content.Length;

        ReadOnlySpan<char> Characters
            => Content;

        string ITextual.Format()
            => Content;
    }

    [Free]
    public interface ITextBlock<T> : ITextBlock
        where T : ITextual
    {
        new T Content {get;}

        string ITextBlock.Content
            => Content.Format();
    }
}