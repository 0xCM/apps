//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using Asm;

    using static Root;

    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct ObjDumpRow : IAsmStatementEncoding
    {
        public const string TableId = "llvm.objdump";

        public const byte FieldCount = 10;

        public const string BlockStartMarker = "<blockstart>";

        public uint Seq;

        public LineNumber Line;

        public TextBlock Section;

        public MemoryAddress BlockAddress;

        public TextBlock BlockName;

        public MemoryAddress IP;

        public BinaryCode Encoding;

        public TextBlock Statement;

        public AsmInlineComment Comment;

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
            dst.Statement = EmptyString;
            dst.Source = FS.FilePath.Empty;
            dst.Comment = AsmInlineComment.Empty;
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
            get => text.contains(Statement.Format(), BlockStartMarker);
        }

        AsmExpr IAsmStatementEncoding.Asm
            => Statement.Text;

        AsmHexCode IAsmStatementEncoding.Encoding
            => Encoding;

        MemoryAddress IAsmStatementEncoding.Offset
            => IP;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{8,12,12,16,52,12,42,90,90,1};
    }
}