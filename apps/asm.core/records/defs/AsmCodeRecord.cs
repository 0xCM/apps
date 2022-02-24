//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct AsmCodeRecord
    {
        public const string TableId = "asm.code";

        public const byte FieldCount = 9;

        public EncodingId EncodingId;

        public Hex32 OriginId;

        public Label OriginName;

        public Label BlockName;

        public MemoryAddress BlockBase;

        public MemoryAddress IP;

        public AsmHexRef Encoded;

        public byte Size;

        public SourceText Asm;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{18,12,42,42,16,8,48,8,82};
    }
}