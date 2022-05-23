//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct FileRef : IComparable<FileRef>
    {
        public const string TableId = "files.index";

        public const byte FieldCount = 4;

        public readonly uint Seq;

        public readonly Hex32 DocId;

        public readonly FileKind Kind;

        public readonly Timestamp Timestamp;

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

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,16,24,1};

        public static FileRef Empty => default;
    }
}