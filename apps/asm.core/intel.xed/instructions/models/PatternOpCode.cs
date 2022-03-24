//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedPatterns
    {
        [Record(TableId)]
        public struct PatternOpCode
        {
            public const string TableId = "xed.opcodes";

            public const byte FieldCount = 6;

            public uint PatternId;

            public XedOpCode OpCode;

            public InstClass InstClass;

            public EnumFormat<ModeKind> Mode;

            public TextBlock Layout;

            public TextBlock Pattern;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{10,20,20,12,80,1};
        }
    }
}