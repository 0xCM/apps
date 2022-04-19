//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct FileDescription
    {
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