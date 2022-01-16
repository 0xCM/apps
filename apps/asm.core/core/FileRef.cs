//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static Root;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct FileRef : IComparable<FileRef>, ISequential
    {
        public const string TableId = "files.index";

        public const byte FieldCount = 4;

        public uint DocId;

        public FileKind Kind;

        public Hash32 NameHash;

        public FS.FilePath Path;

        [MethodImpl(Inline)]
        public FileRef(uint id, FileKind kind, Hash32 hash, FS.FilePath path)
        {
            DocId = id;
            Kind = kind;
            Path = path;
            NameHash = hash;
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

        public int CompareTo(FileRef src)
            => DocId.CompareTo(src.DocId);

        uint ISequential.Seq
            => DocId;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,16,12,1};

        public static FileRef Empty => default;
    }
}