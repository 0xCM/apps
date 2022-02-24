//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct ObjDumpRow : IAsmBlockSegment, IComparable<ObjDumpRow>, IOriginated
    {
        public const string TableId = "llvm.objdump";

        public const byte FieldCount = 13;

        public const string BlockStartMarker = "<blockstart>";

        public uint Seq;

        public EncodingId Id;

        public Hex32 OriginId;

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

        public string DocName
            => Source.Path.FileName.Format();

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

        Hex64 IAsmEncodingRecord.Id
            => Id;

        Hex32 IOriginated.OriginId
            => OriginId;

        uint ISequential.Seq
            => Seq;

        AsmExpr IAsmEncodingRecord.Asm
            => Asm;

        AsmHexCode IAsmEncodingRecord.Encoded
            => HexCode;

        MemoryAddress IAsmEncodingRecord.IP
            => IP;

        Identifier IAsmBlockSegment.BlockName
            => BlockName.Text;

        MemoryAddress IAsmBlockSegment.BlockAddress
            => BlockAddress;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{8,18,12,8,12,16,32,12,8,42,90,90,1};

    }
}