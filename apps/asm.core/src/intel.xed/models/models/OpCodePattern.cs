//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [Record(TableId)]
        public struct OcMapKind
        {
            public const string TableId = "xed.opcode.kind";

            public const byte FieldCount = 6;

            public byte Index;

            public OpCodeClass Class;

            public text15 Name;

            public byte Number;

            public OpCodeKind Identity;

            public text15 Pattern;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,12,16,12,16,1};
        }
    }
}