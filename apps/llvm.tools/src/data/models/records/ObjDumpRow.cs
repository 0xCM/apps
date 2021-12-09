//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct ObjDumpRow
    {
        public const string TableId = "objdump";

        public const byte FieldCount = 9;

        public const string BlockStartMarker = "<blockstart>";

        public uint Seq;

        public LineNumber Line;

        public TextBlock Section;

        public MemoryAddress BlockAddress;

        public TextBlock BlockName;

        public MemoryAddress IP;

        public BinaryCode Encoding;

        public TextBlock Asm;

        public FS.FileUri Source;

        public static ObjDumpRow Empty()
        {
            var dst = new ObjDumpRow();
            dst.Line = LineNumber.Empty;
            dst.Section = TextBlock.Empty;
            dst.BlockAddress = 0;
            dst.BlockName = TextBlock.Empty;
            dst.IP = 0;
            dst.Encoding = BinaryCode.Empty;
            dst.Asm = EmptyString;
            dst.Source = FS.FilePath.Empty;
            return dst;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Line.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Line.IsNonEmpty;
        }

        public bool IsBlockStart
        {
            get => text.contains(Asm.Format(), BlockStartMarker);
        }

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{8,12,12,16,40,16,42,90,1};
    }
}