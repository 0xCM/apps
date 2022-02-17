//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmEncodingRow : IAsmEncoding
    {
        public const string TableId = "asm.encoding";

        public const byte FieldCount = 9;

        public uint Seq;

        public Hex64 Id;

        public uint DocId;

        public uint DocSeq;

        public MemoryAddress IP;

        public AsmHexCode Encoded;

        public byte Size;

        public AsmExpr Asm;

        public FS.FileUri Source;

        uint ISequential.Seq
            => Seq;

        AsmExpr IAsmEncoding.Asm
            => Asm;

        AsmHexCode IAsmEncoding.Encoded
            => Encoded;

        MemoryAddress IAsmEncoding.IP
            => IP;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,18,8,8,12,38,8,84,1};

        public static AsmEncodingRow Empty => default;
    }
}