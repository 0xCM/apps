//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public readonly struct List : IMarkdownElement<List>
        {
            [MethodImpl(Inline), Op]
            public static ListItem item(byte level, string content, ListStyle style)
                => new ListItem(level, content, style);

            public readonly Index<ListItem> Items;

            public readonly ListStyle Style;

            public List(Index<ListItem> items, ListStyle style)
            {
                Items = items;
                Style = style;
            }

            public string Format()
            {
                var dst = text.buffer();
                var count = Items.Count;
                for(var i=0; i<count; i++)
                {
                    dst.AppendLine(Items[i]);
                }
                return dst.Emit();
            }

            public override string ToString()
                => Format();
        }
    }
}