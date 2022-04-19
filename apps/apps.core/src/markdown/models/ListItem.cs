//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly struct ListItem : IMarkdownElement<ListItem>
        {
            public readonly byte Level;

            public readonly string Content;

            public readonly ListStyle Style;

            public ListItem(byte level, string content, ListStyle style)
            {
                Level = level;
                Content = content;
                Style = style;
            }

            public string Format()
            {
                if(Style == ListStyle.Bullet)
                    return string.Format("{0} {1}", "*", Content);
                else
                    return string.Format("{0} {1}", "-", Content);
            }

            public override string ToString()
                => Format();
        }
    }
}