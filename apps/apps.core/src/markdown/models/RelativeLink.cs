//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly struct RelativeLink : IMarkdownElement<RelativeLink>
        {
            public readonly string Label;

            public readonly string Target;

            [MethodImpl(Inline)]
            public RelativeLink(string label, string target)
            {
                Label = label;
                Target = target;
            }

            public string Format()
                => string.Format("[{0}](./{1})", Label, Target);

            public override string ToString()
                => Format();
        }
    }
}