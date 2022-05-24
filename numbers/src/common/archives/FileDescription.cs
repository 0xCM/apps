//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    [Record(TableId)]
    public struct FileDescription
    {
        [Op]
        public static FileDescription describe(FS.FilePath src)
        {
            var dst = new FileDescription();
            var info = new FileInfo(src.Name);
            dst.Path = src;
            dst.Attributes = info.Attributes;
            dst.CreateTS = info.CreationTime;
            dst.UpdateTS = info.LastWriteTime;
            dst.Size = info.Length;
            return dst;
        }

        public const string TableId = "fs.info";

        public FS.FilePath Path;

        public ByteSize Size;

        public Timestamp CreateTS;

        public Timestamp UpdateTS;

        public FileAttributeSet Attributes;

        public string Format()
            => string.Format("{0,-12}{1}", Size.Kb, Path.ToUri());

        public override string ToString()
            => Format();
    }
}