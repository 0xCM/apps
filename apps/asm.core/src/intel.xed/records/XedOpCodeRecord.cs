//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    using Asm;
    [Record(TableId)]
    public struct XedOpCodeRecord
    {
        public const string TableId = "xed.opcode";

        public const byte FieldCount = 6;

        public uint Seq;

        public IClass Class;

        public OpCodeKind Kind;

        public byte ClassSeq;

        public AsmOcValue Value;

        public TextBlock Source;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,24,16,8,12,1};
    }
}