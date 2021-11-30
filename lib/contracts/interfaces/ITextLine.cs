//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITextLine : ITextBlock
    {
        /// <summary>
        /// The line number of the data source from which the line was extracted
        /// </summary>
        uint LineNumber {get;}
    }

    public interface ITextLine<T> : ITextLine, ITextBlock<T>
        where T : ITextBlock<T>
    {
        new T Content {get;}

        string ITextBlock.Content
            => Content.Format();
    }
}