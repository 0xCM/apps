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
            public const string RecordId = "xed.rules.cells";

            public const byte FieldCount = 13;

            public uint Seq;

            public ushort Lix;

            public ushort TableId;

            public RuleTableKind Kind;

            public RuleName Name;

            public asci32 Expression;

            public EnumFormat<RuleCellKind> Type;

            public ushort Row;

            public byte Col;

            public LogicClass Logic;

            public EmptyZero<FieldKind> Field;

            public RuleOperator Op;

            public dynamic Value;

            public CellKey Key
                => new CellKey(new(Name,Kind), TableId, Row, Logic, Col);

            public int CompareTo(KeyedCellRecord src)
                => Key.CompareTo(src.Key);

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,8,6,32,32,6,6,6,6,24,4,1};

            public static KeyedCellRecord Empty => default;
        }
    }
}