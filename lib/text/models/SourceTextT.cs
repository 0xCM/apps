//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class SourceText<T> : ISourceText
        where T : SourceText<T>
    {
        public TextBlock Content {get;}

        [MethodImpl(Inline)]
        protected SourceText(TextBlock src)
        {
            Content = src;
        }
    }
}