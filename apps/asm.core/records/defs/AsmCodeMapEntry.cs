//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct AsmCodeMapEntry : IComparable<AsmCodeMapEntry>
    {
        public const string TableId = "asm.codemap";

        public const byte FieldCount = 13;

        public uint Seq;

        public EncodingId EncodingId;

        public Hex32 OriginId;

        public InstructionId InstructionId;

        public Label OriginName;

        public Label BlockName;

        public uint BlockNumber;

        public MemoryAddress BlockAddress;

        public ByteSize BlockSize;

        public MemoryAddress IP;

        public byte EncodingSize;

        public AsmHexRef Encoded;

        public SourceText Asm;

        public int CompareTo(AsmCodeMapEntry src)
        {
            var result = OriginName.CompareTo(src.OriginName);
            if(result == 0)
            {
                result = IP.CompareTo(src.IP);
            }
            return result;
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,18,12,30,42,42,12,16,16,16,12,42,1};
    }
}