//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [Record(TableName), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct MacroAssignment
        {
            public const byte FieldCount = 8;

            public const string TableName = "xed.rules.macros";

            public uint Seq;

            public RuleMacroKind MacroName;

            public byte Assigned;

            public FieldAssignment A0;

            public FieldAssignment A1;

            public FieldAssignment A2;

            public FieldAssignment A3;

            public FieldAssignment A4;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,24,8,26,26,26,26,26};

            public static MacroAssignment Empty => default;
        }
    }
}