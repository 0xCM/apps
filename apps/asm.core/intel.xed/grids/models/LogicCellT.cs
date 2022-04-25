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
        public readonly record struct LogicCell<T> : IComparable<LogicCell<T>>
            where T : unmanaged,  ILogicValue<T>, IEquatable<T>, ILogicOperand<T>
        {
            public readonly CellKey Key;

            public readonly T Value;

            [MethodImpl(Inline)]
            public LogicCell(CellKey key, T value)
            {
                Key = key;
                Value = value;
            }

            public int CompareTo(LogicCell<T> src)
                => Key.CompareTo(src.Key);

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

            public static implicit operator LogicCell(LogicCell<T> src)
                => new LogicCell(src.Key, src.Value.Operator, LogicValue.untype(src.Value));
        }
    }
}