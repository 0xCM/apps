//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines an entry in list of files
    /// </summary>
    [Record(TableId)]
    public record struct ListedFile : IDataTypeExpr<ListedFile>, ISequential<ListedFile>
    {
        public const string TableId = "files";

        [Render(8)]
        public uint Seq;

        [Render(1)]
        public FS.FileUri Path;

        [MethodImpl(Inline)]
        public ListedFile(uint index, FS.FilePath path)
        {
            Seq = index;
            Path = path;
        }

        [MethodImpl(Inline)]
        public ListedFile(int index, FS.FilePath path)
        {
            Seq = (uint)index;
            Path = path;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Path.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Path.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Path.Hash;
        }

        uint ISequential.Seq
            { get => Seq; set => Seq = value; }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public string Format()
            => RpOps.format("{0,-10} | {1}", Seq, Path);

        public override string ToString()
            => Format();

        public int CompareTo(ListedFile src)
            => Path.CompareTo(src.Path);

        public bool Equals(ListedFile src)
            => Path == src.Path;

        [MethodImpl(Inline)]
        public static implicit operator ListedFile((uint index, FS.FilePath path) src)
            => new ListedFile(src.index, src.path);

        [MethodImpl(Inline)]
        public static implicit operator ListedFile((int index, FS.FilePath path) src)
            => new ListedFile(src.index, src.path);
    }
}