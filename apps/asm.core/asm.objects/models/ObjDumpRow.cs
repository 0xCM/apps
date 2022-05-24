//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct ObjDumpRow : IComparable<ObjDumpRow>
    {
        public const string TableId = "llvm.objdump";

        public const byte FieldCount = 14;

        public const string BlockStartMarker = "<blockstart>";

        public uint Seq;

        public uint DocSeq;

        public Hex32 OriginId;

        public EncodingId EncodingId;

        public InstructionId InstructionId;

        public TextBlock Section;

        public MemoryAddress BlockAddress;

        public TextBlock BlockName;

        public Address32 IP;

        public byte Size;

        public AsmHexCode Encoded;

        public AsmExpr Asm;

        public AsmInlineComment Comment;

        public FS.FileUri Source;

        public string DocName
            => Source.Path.FileName.Format();

        public AsmRowKey RowKey
        {
            [MethodImpl(Inline)]
            get => (Seq,DocSeq,OriginId);
        }

        public static ObjDumpRow Empty()
        {
            var dst = new ObjDumpRow();
            dst.Section = TextBlock.Empty;
            dst.BlockAddress = 0;
            dst.BlockName = TextBlock.Empty;
            dst.IP = 0;
            dst.Encoded = BinaryCode.Empty;
            dst.Asm = EmptyString;
            dst.Source = FS.FilePath.Empty;
            dst.Comment = AsmInlineComment.Empty;
            return dst;
        }

        public int CompareTo(ObjDumpRow src)
        {
            var result = DocName.CompareTo(src.DocName);
            if(result==0)
                result = IP.CompareTo(src.IP);
            return result;
        }

        public static ObjDumpRow Init(in FileRef src)
        {
            var dst = Empty();
            dst.OriginId = src.DocId;
            return dst;
        }

        public bool IsBlockStart
        {
            [MethodImpl(Inline)]
            get => text.contains(Asm.Format(), BlockStartMarker);
        }

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{
                ColWidths.Seq,
                ColWidths.DocSeq,
                ColWidths.OriginId,
                ColWidths.EncodingId,
                ColWidths.InstructionId,
                12,
                16,
                ColWidths.BlockName,
                ColWidths.IP,
                ColWidths.Size,
                ColWidths.Encoded,
                ColWidths.AsmExpr,
                90,
                1};
    }
}