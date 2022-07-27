//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FileChangeKind;

    [Record(TableId)]
    public readonly record struct FileChange
    {
        [Op]
        public static char symbol(FileChangeKind kind)
            => kind switch{
                Created => Chars.Plus,
                Deleted => Chars.Dash,
                Modified => 'M',
                Renamed => 'R',
                _ => Chars.Question
            };

        public const string TableId = "fs.change";

        public readonly FS.FileUri File;

        public readonly FileChangeKind Kind;

        public FileChange(FS.FilePath path, FileChangeKind kind)
        {
            Kind = kind;
            File = path;
        }

        public string Format()
            => string.Format("[{0}] {1}", symbol(Kind), File);

        public override string ToString()
            => Format();
    }
}