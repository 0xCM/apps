//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using Asm;

    using static Root;

    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct ObjDumpRow : IAsmEncoding
    {
        public const string TableId = "llvm.objdump";

        public const byte FieldCount = 11;

        public const string BlockStartMarker = "<blockstart>";

        public uint Seq;

        public uint DocSeq;

        public LineNumber Line;

        public TextBlock Section;

        public MemoryAddress BlockAddress;

        public TextBlock BlockName;

        public MemoryAddress IP;

        public AsmHexCode HexCode;

        public AsmExpr Asm;

        public AsmInlineComment Comment;

        public FS.FileUri Source;

        public CorrelationToken CT
        {
            [MethodImpl(Inline)]
            get => Seq;
        }

        public static ObjDumpRow Empty()
        {
            var dst = new ObjDumpRow();
            dst.Line = LineNumber.Empty;
            dst.Section = TextBlock.Empty;
            dst.BlockAddress = 0;
            dst.BlockName = TextBlock.Empty;
            dst.IP = 0;
            dst.HexCode = BinaryCode.Empty;
            dst.Asm = EmptyString;
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
            [MethodImpl(Inline)]
            get => text.contains(Asm.Format(), BlockStartMarker);
        }

        uint ISequential.Seq
            => Seq;

        AsmExpr IAsmEncoding.Asm
            => Asm;

        AsmHexCode IAsmEncoding.Encoding
            => HexCode;

        MemoryAddress IAsmEncoding.Offset
            => IP;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{8,8,12,12,16,52,12,42,90,90,1};
    }
}