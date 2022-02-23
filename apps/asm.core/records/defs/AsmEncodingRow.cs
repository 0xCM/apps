//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmEncodingRow : IAsmEncodingRecord
    {
        public const string TableId = "asm.encoding";

        public const byte FieldCount = 9;

        public uint Seq;

        public EncodingId Id;

        public Hex32 DocId;

        public uint DocSeq;

        public MemoryAddress IP;

        public AsmHexCode Encoded;

        public byte Size;

        public AsmExpr Asm;

        public FS.FileUri Source;

        Hex64 IAsmEncodingRecord.Id
            => Id;

        uint ISequential.Seq
            => Seq;

        AsmExpr IAsmEncodingRecord.Asm
            => Asm;

        AsmHexCode IAsmEncodingRecord.Encoded
            => Encoded;

        MemoryAddress IAsmEncodingRecord.IP
            => IP;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,18,12,8,12,38,8,84,1};

        public static AsmEncodingRow Empty => default;
    }
}