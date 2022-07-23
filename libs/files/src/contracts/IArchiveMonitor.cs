//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FileChangeKind;

    [Free]
    public delegate void FileChangeHandler(FileChange change);

    [Free]
    public delegate void FileChanged(FileChange description);

    [Flags, SymSource("files")]
    public enum FileChangeKind : byte
    {
        None = 0,

        [Symbol("+")]
        Created = 1,

        [Symbol("-")]
        Deleted = 2,

        [Symbol("M")]
        Modified = 4,

        [Symbol("R")]
        Renamed = 8,
    }

    public interface IMonitor : IDisposable
    {
        void Start();

        void Stop();
    }

    public interface IMonitor<T> : IMonitor
    {
        T Target {get;}
    }
    [Free]
    public interface IArchiveMonitor : IMonitor<IDbSources>
    {

    }

    [Record(TableId)]
    public readonly record struct FileChange
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

        public readonly FS.FileUri File;

        public readonly FileChangeKind ChangeKind;

        public FileChange(FS.FilePath path, FileChangeKind kind)
        {
            ChangeKind = kind;
            File = path;
        }

        public string Format()
            => string.Format("[{0}] {1}", symbol(ChangeKind),File);

        public override string ToString()
            => Format();
    }
}