//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IMarkdownElement : ITextual
    {

    }

    public interface IMarkdownElement<T> : IMarkdownElement
        where T : IMarkdownElement<T>
    {


    }

}