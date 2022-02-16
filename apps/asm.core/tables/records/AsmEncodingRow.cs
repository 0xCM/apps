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

        public uint DocId;

        public uint DocSeq;

        public Address32 IP;

        public byte Size;

        public AsmHexCode HexCode;

        public AsmExpr Asm;

        public CorrelationToken CT;

        public FS.FileUri Source;

        uint ISequential.Seq
            => Seq;

        AsmExpr IAsmEncoding.Asm
            => Asm;

        AsmHexCode IAsmEncoding.Code
            => HexCode;

        MemoryAddress IAsmEncoding.IP
            => IP;

        CorrelationToken ICorrelated.CT
            => CT;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,8,12,8,38,84,12,1};

        public static AsmEncodingRow Empty => default;
    }
}