//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly partial struct Markdown
    {
        [MethodImpl(Inline), Op]
        public static SectionHeader header(byte depth, string name)
            => new (depth,name);

        [MethodImpl(Inline), Op]
        public static SectionLink link(string label, string dst)
            => new SectionLink(label, dst);

        [MethodImpl(Inline), Op]
        public static SectionLink link(string dst)
            => new SectionLink(dst, dst);

        public static Index<RelativeLink> links(FS.FolderPath @base, FS.Files files)
        {
            var relative = files.Map(f => f.Relative(@base));
            var count = relative.Length;
            var dst = alloc<RelativeLink>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = Markdown.link(skip(relative,i));
            return dst;
        }

        public static Index<AbsoluteLink> links(FS.Files files)
            => files.Map(f => link(f.FileName.WithoutExtension.Format(),f));

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

        public readonly struct RelativeLink
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

        public readonly struct SectionLink
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

        public readonly struct SectionHeader
        {
            public readonly byte Depth;

            public readonly string Name;

            [MethodImpl(Inline)]
            public SectionHeader(byte depth, string name)
            {
                Depth = depth;
                Name = name;
            }

            public string Format()
                => string.Format("{0} {1}", new string(Chars.Hash,Depth), Name);

            public override string ToString()
                => Format();
        }

        public readonly struct AbsoluteLink
        {
            public readonly string Label;

            public readonly string Target;

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

        public readonly struct ListItem
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

        public readonly struct List
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

        public enum ListStyle : byte
        {
            None = 0,

            Bullet = 1,
        }
    }
}