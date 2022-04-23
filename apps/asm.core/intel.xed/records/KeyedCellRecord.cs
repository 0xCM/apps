//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), Record(RecordId)]
        public record struct KeyedCellRecord : IComparable<KeyedCellRecord>
        {
            public const string RecordId = "xed.rules.cells.keyed";

            public const byte FieldCount = 10;

            public uint Seq;

            public ushort TableId;

            public RuleName TableName;

            public RuleTableKind TableKind;

            public ushort RowIndex;

            public byte CellIndex;

            public LogicClass Logic;

            public EmptyZero<FieldKind> Field;

            public RuleOperator Op;

            public dynamic Value;

            public CellKey Key
                => new CellKey(new (TableName,TableKind), TableId, RowIndex, Logic, CellIndex);

            public int CompareTo(KeyedCellRecord src)
                => Key.CompareTo(src.Key);

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,12,32,12,12,12,12,24,4,1};

            public static KeyedCellRecord Empty => default;
        }
    }
}