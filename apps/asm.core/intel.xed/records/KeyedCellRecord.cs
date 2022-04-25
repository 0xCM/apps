//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), Record(RecordId)]
        public record struct KeyedCellRecord : IComparable<KeyedCellRecord>
        {
            public const string RecordId = "xed.rules.cells";

            public const byte FieldCount = 13;

            public uint Seq;

            public ushort Index;

            public ushort Table;

            public ushort Row;

            public byte Col;

            public LogicClass Logic;

            public CellClass Type;

            public RuleTableKind Kind;

            public Nonterminal Rule;

            public asci32 Expression;

            public EmptyZero<FieldKind> Field;

            public RuleOperator Op;

            public dynamic Value;

            public CellKey Key
                => new CellKey(Index, Table, Row, Col, Logic, Type, Kind, Rule, Field);

            public int CompareTo(KeyedCellRecord src)
                => Key.CompareTo(src.Key);

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,8,8,6,6,6,6,6,32,32,24,4,1};

            public static KeyedCellRecord Empty => default;
        }
    }
}