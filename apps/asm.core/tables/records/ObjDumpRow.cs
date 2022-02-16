//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct ObjDumpRow : IAsmBlockSegment
    {
        public const string TableId = "llvm.objdump";

        public const byte FieldCount = 12;

        public const string BlockStartMarker = "<blockstart>";

        public uint Seq;

        public uint DocId;

        public uint DocSeq;

        public TextBlock Section;

        public MemoryAddress BlockAddress;

        public TextBlock BlockName;

        public Address32 IP;

        public byte Size;

        public AsmHexCode HexCode;

        public AsmExpr Asm;

        public AsmInlineComment Comment;

        public FS.FileUri Source;

        public CorrelationToken CT
        {
            [MethodImpl(Inline)]
            get => AsmRecords.token(DocId, (Address32)IP);
        }

        public static ObjDumpRow Empty()
        {
            var dst = new ObjDumpRow();
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

        public static ObjDumpRow Init(in FileRef src)
        {
            var dst = Empty();
            dst.DocId = src.DocId;
            return dst;
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

        AsmHexCode IAsmEncoding.Code
            => HexCode;

        MemoryAddress IAsmEncoding.IP
            => IP;

        Identifier IAsmBlockSegment.BlockName
            => BlockName.Text;

        MemoryAddress IAsmBlockSegment.BlockAddress
            => BlockAddress;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{8,8,8,12,16,32,12,8,42,90,90,1};
    }
}