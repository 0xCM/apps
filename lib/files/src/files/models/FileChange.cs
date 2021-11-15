//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct FileChange : IRecord<FileChange>
    {
        public const string TableId = "fs.change";

        public FS.FilePath File;

        public FS.ChangeKind ChangeKind;

        public FileChange(FS.FilePath path, FS.ChangeKind kind)
        {
            ChangeKind = kind;
            File = path;
        }

        public string Format()
            => string.Format("[{0}] {1}", FS.symbol(ChangeKind), File.ToUri());


        public override string ToString()
            => Format();

    }
}