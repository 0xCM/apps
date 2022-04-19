//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly struct PageTitle : IMarkdownElement<PageTitle>
        {
            public readonly string Content;

            [MethodImpl(Inline)]
            public PageTitle(string src)
            {
                Content = src;
            }

            [MethodImpl(Inline)]
            public static implicit operator PageTitle(string src)
                => new PageTitle(src);

            public string Format()
                => string.Format("# {0}", Content);

            public override string ToString()
                => Format();
        }
    }
}