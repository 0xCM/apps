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
    public struct FileIndexRow : IComparable<FileIndexRow>
    {
        public const string TableId = "files.index";

        public const byte FieldCount = 3;

        public uint Seq;

        public Hash32 Hash;

        public FS.FilePath Path;

        [MethodImpl(Inline)]
        public FileIndexRow(uint seq, Hash32 hash, FS.FilePath path)
        {
            Seq = seq;
            Path = path;
            Hash = hash;
        }

        public int CompareTo(FileIndexRow src)
            => Seq.CompareTo(src.Seq);

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,12,1};
    }
}