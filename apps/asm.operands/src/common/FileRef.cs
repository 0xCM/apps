//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct FileRef : IComparable<FileRef>, ISequential
    {
        public const string TableId = "files.index";

        public const byte FieldCount = 4;

        public Hex32 DocId;

        public FileKind Kind;

        public Timestamp Timestamp;

        public FS.FilePath Path;

        [MethodImpl(Inline)]
        public FileRef(uint id, FileKind kind, FS.FilePath path)
        {
            DocId = id;
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

        public string OriginName
        {
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

        uint ISequential.Seq
            => DocId;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,16,24,1};

        public static FileRef Empty => default;
    }
}