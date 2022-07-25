//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FileRef : IFileRef, IComparable<FileRef>, ISequential<FileRef>
    {
        const string TableId = "files.index";

        [Render(8)]
        public uint Seq;

        [Render(12)]
        public readonly Hex32 DocId;

        [Render(12)]
        public readonly FileKind Kind;

        [Render(24)]
        public readonly Timestamp Timestamp;

        [Render(1)]
        public readonly FS.FilePath Path;

        [MethodImpl(Inline)]
        public FileRef(uint seq, uint docid, FileKind kind, FS.FilePath path)
        {
            Seq = seq;
            DocId = docid;
            Kind = kind;
            Timestamp = path.Timestamp;
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

        public string DocName
        {
            [MethodImpl(Inline)]
            get => Path.FileName.Format();
        }

        public int CompareTo(FileRef src)
            => DocId.CompareTo(src.DocId);

        public override int GetHashCode()
            => (int)DocId;

        public string Format()
            => Path.ToUri().Format();

        public override string ToString()
            => Format();

        public static FileRef Empty => default;

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = value;
        }

        FileKind IFileRef.Kind
            => Kind;

        FS.FilePath IFileRef.Path
            => Path;
    }
}