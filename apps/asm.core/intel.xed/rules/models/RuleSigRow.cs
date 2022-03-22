//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [Record(TableId)]
        public struct RuleSigRow
        {
            public const string TableId = "xed.rules.tables.sigs";

            public const byte FieldCount = 4;

            public uint Seq;

            public RuleTableKind TableKind;

            public Identifier TableName;

            public FS.FileUri TableDef;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,12,32,1};
        }
    }
}