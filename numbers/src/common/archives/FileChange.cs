//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FileChangeKind;

    [Free]
    public delegate void FileChangeHandler(FileChange change);

    [Record(TableId)]
    public struct FileChange : IRecord<FileChange>
    {
        [Op]
        public static char symbol(FileChangeKind change)
            => change switch{
                Created => Chars.Plus,
                Deleted => Chars.Dash,
                Modified => 'M',
                Renamed => 'R',
                _ => Chars.Question
            };

        public const string TableId = "fs.change";

        public FS.FilePath File;

        public FileChangeKind ChangeKind;

        public FileChange(FS.FilePath path, FileChangeKind kind)
        {
            ChangeKind = kind;
            File = path;
        }

        public string Format()
            => string.Format("[{0}] {1}", symbol(ChangeKind), File.ToUri());


        public override string ToString()
            => Format();
    }
}