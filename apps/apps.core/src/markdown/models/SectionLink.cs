//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly struct SectionLink : IMarkdownElement<SectionLink>
        {
            public readonly string Label;

            public readonly string Target;

            [MethodImpl(Inline)]
            public SectionLink(string label, string dst)
            {
                Label = label;
                Target = dst;
            }

            public string Format()
                => string.Format("[{0}](#{1})", Label, Target);

            public override string ToString()
                => Format();
        }
    }
}