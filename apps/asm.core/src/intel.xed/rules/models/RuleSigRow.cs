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
            public const string TableId = "rules.tables.sigs";

            public const byte FieldCount = 5;

            public uint Seq;

            public RuleTableKind TableKind;

            public RuleClass RuleClass;

            public Identifier TableName;

            public FS.FileUri TableDef;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,12,16,32,1};
        }
    }
}