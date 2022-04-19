//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly struct AbsoluteLink : IMarkdownElement<AbsoluteLink>
        {
            public readonly string Label;

            public readonly FS.FileUri Target;

            public readonly bool Bare;

            [MethodImpl(Inline)]
            public AbsoluteLink(string label, FS.FileUri target, bool bare)
            {
                Label = label;
                Target = target;
                Bare = bare;
            }

            public string Format()
                => Bare ? string.Format("<{0}>", Target) : string.Format("[{0}]({1})", Label, Target);

            public override string ToString()
                => Format();
        }
    }
}