//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ITextBlock : IDataType
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
    public interface ITextBlock<T> : ITextBlock, IDataType<T>
        where T : ITextual
    {
        new T Content {get;}

        string ITextBlock.Content
            => Content.Format();
    }
}