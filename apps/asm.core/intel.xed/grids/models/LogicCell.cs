//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedGrids
    {
        public readonly record struct LogicCell
        {
            public readonly CellKey Key;

            public readonly RuleOperator Operator;

            public readonly LogicValue Value;

            [MethodImpl(Inline)]
            public LogicCell(CellKey key, RuleOperator op, LogicValue value)
            {
                Key = key;
                Operator = op;
                Value = value;
            }

            public uint Index
            {
                [MethodImpl(Inline)]
                get => Key.Index;
            }

            public Coordinate Location
            {
                [MethodImpl(Inline)]
                get => Key.Location;
            }
        }
    }
}