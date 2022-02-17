//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct AsmCodeRecord
    {
        public const string TableId = "asm.code";

        public const byte FieldCount = 7;

        public text31 Origin;

        public MemoryAddress BlockAddress;

        public Label BlockName;

        public MemoryAddress IP;

        public byte Size;

        public AsmHexRef Encoded;

        public SourceText Asm;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{24,16,24,8,8,42,1};

    }
}