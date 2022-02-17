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

        public const byte FieldCount = 8;

        public Label Origin;

        public Hex64 Id;

        public Label BlockName;

        public MemoryAddress BlockBase;

        public MemoryAddress IP;

        public AsmHexRef Encoded;

        public byte Size;

        public SourceText Asm;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{42,18,24,16,8,42,8,1};
    }
}