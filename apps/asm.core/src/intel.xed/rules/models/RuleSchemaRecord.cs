//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential), Record(TableId)]
        public struct RuleSchemaRecord
        {
            public const string TableId = "xed.rules.schemas";

            public const byte FieldCount = 6;

            public uint Seq;

            public RuleTableKind TableKind;

            public byte Index;

            public char ColKind;

            public Identifier TableName;

            public FieldKind TableField;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{10,10,8,8,36,1};

        }
    }
}