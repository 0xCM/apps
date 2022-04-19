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
        public static PageTitle title(string content)
            => content;

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
            => new AbsoluteLink(label, dst, false);

        [MethodImpl(Inline), Op]
        public static AbsoluteLink link(string label, FS.FileUri dst)
            => new AbsoluteLink(label, dst, false);

        [MethodImpl(Inline), Op]
        public static AbsoluteLink link(FS.FilePath dst, bool bare = true)
            => new AbsoluteLink(dst.FileName.WithoutExtension.Format(), dst, bare);

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
    }
}