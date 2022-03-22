//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedFields;

    partial class XedPatterns
    {
        [Record(TableId)]
        public struct PatternOpCode
        {
            public const string TableId = "xed.opcodes";

            public const byte FieldCount = 12;

            public uint PatternId;

            public XedOpCode OpCode;

            public IClass Class;

            public EnumFormat<ModeKind> Mode;

            public EnumFormat<OSZ> OSZ;

            public EnumFormat<LockIndicator> LOCK;

            public EnumFormat<EOSZ> EOSZ;

            public ModKind MOD;

            public EnumFormat<VexClass> VEXVALID;

            public EnumFormat<VexKind> VEX_PREFIX;

            public TextBlock Fields;

            public TextBlock Layout;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{10,20,20,6,6,12,12,12,12,12,48,1};
        }
    }
}