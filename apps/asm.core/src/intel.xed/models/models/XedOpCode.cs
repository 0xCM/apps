//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [Record(TableId)]
        public struct XedOpCode
        {
            public const string TableId = "xed.opcode";

            public const byte FieldCount = 6;

            public uint Seq;

            public IClass Class;

            public OpCodeKind Kind;

            public byte ClassSeq;

            public ByteBlock4 Value;

            public TextBlock Source;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,24,16,8,12,1};
        }
    }
}