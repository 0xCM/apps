//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public readonly partial struct Markdown
    {
        [MethodImpl(Inline), Op]
        public static RelativeLink link(string label, FS.RelativeFilePath src)
            => new RelativeLink(label, src.Format());

        [MethodImpl(Inline), Op]
        public static RelativeLink link(FS.RelativeFilePath src)
            => new RelativeLink(src.File.Format(), src.Format());

        [MethodImpl(Inline), Op]
        public static AbsoluteLink link(string label, FS.FilePath dst)
            => new AbsoluteLink(label, dst.ToUri().Format());

        [MethodImpl(Inline), Op]
        public static AbsoluteLink link(FS.FilePath dst)
            => new AbsoluteLink(dst.FileName.WithoutExtension.Format(), dst.ToUri().Format());

        public static ListItem item<T>(byte level, T src, ListStyle style)
            where T : ITextual
                => List.item(level,src.Format(),style);

        public List list(string[] items, ListStyle style)
        {
            var count = items.Length;
            var buffer = new ListItem[count];
            for(var i=0; i<count; i++)
                seek(buffer,i) = List.item(0, skip(items,i), style);
            return new List(buffer,style);
        }

        public readonly struct RelativeLink : ITextual
        {
            public string Label {get;}

            public string Target {get;}

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

        public readonly struct AbsoluteLink : ITextual
        {
            public string Label {get;}

            public string Target {get;}

            [MethodImpl(Inline)]
            public AbsoluteLink(string label, string target)
            {
                Label = label;
                Target = target;
            }

            public string Format()
                => string.Format("[{0}]({1})", Label, Target);

            public override string ToString()
                => Format();
        }

        public readonly struct ListItem : ITextual
        {
            public byte Level {get;}

            public string Content {get;}

            public ListStyle Style {get;}

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

        public readonly struct List : ITextual
        {

            [MethodImpl(Inline), Op]
            public static ListItem item(byte level, string content, ListStyle style)
                => new ListItem(level, content, style);

            public Index<ListItem> Items {get;}

            public ListStyle Style {get;}

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

        public enum ListStyle : byte
        {
            None = 0,

            Bullet = 1,
        }
    }
}