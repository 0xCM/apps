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
        const string TableId = "llvm.objdump";

        public const string BlockStartMarker = "<blockstart>";

        [Render(ColWidths.Seq)]
        public uint Seq;

        [Render(ColWidths.DocSeq)]
        public uint DocSeq;

        [Render(ColWidths.OriginId)]
        public Hex32 OriginId;

        [Render(ColWidths.EncodingId)]
        public EncodingId EncodingId;

        [Render(ColWidths.InstructionId)]
        public InstructionId InstructionId;

        [Render(ColWidths.SectionName)]
        public TextBlock Section;

        [Render(ColWidths.BlockAddress)]
        public MemoryAddress BlockAddress;

        [Render(ColWidths.BlockName)]
        public TextBlock BlockName;

        [Render(ColWidths.IP)]
        public Address32 IP;

        [Render(ColWidths.Size)]
        public byte Size;

        [Render(ColWidths.Encoded)]
        public AsmHexCode Encoded;

        [Render(ColWidths.AsmExpr)]
        public AsmExpr Asm;

        [Render(ColWidths.SyntaxComment)]
        public AsmInlineComment Comment;

        [Render(1)]
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
    }
}