//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(PackedWidth,NativeWidth)]
        public readonly record struct Coordinate : IComparable<Coordinate>
        {
            [MethodImpl(Inline)]
            public static uint pack(Coordinate src)
            {
                var result = 0u;
                result |= ((uint)src.Kind << KindOffset);
                result |= ((uint)src.Logic << LogicOffset);
                result |= ((uint)src.Table << TableOffset);
                result |= ((uint)src.Row << RowOffset);
                result |= ((uint)src.Col << ColOffset);
                return result;
            }

            [MethodImpl(Inline)]
            public static Coordinate unpack(uint src)
            {
                var kind = (RuleTableKind)((src & KindMask) >> KindOffset);
                var logic = (LogicKind)((src & LogicMask) >> LogicOffset);
                var table = (ushort)((src & TableMask) >> TableOffset);
                var row = (ushort)((src & RowMask) >> RowOffset);
                var col = (byte)((src & ColMask) >> ColOffset);
                return new Coordinate(kind, logic, table,row,col);
            }

            public const byte PackedWidth = KindWidth + LogicWidth + TableWidth + RowWidth + ColWidth;

            public const byte NativeWidth = num2.NativeWidth + LogicClass.NativeWidth + num9.NativeWidth + num8.NativeWidth + num4.NativeWidth;

            public static DataSize DataSize => (PackedWidth,NativeWidth);

            const byte KindWidth = num2.PackedWidth;

            const byte KindOffset = 0;

            const uint KindMask = (uint)num2.MaxValue << KindOffset;

            const byte LogicWidth = LogicClass.PackedWidth;

            const byte LogicOffset = KindOffset + KindWidth;

            const uint LogicMask = num2.MaxValue << LogicOffset;

            const byte TableWidth = num9.PackedWidth;

            const byte TableOffset = LogicOffset + LogicWidth;

            const uint TableMask = (uint)num9.MaxValue << TableOffset;

            const byte RowWidth = num8.PackedWidth;

            const byte RowOffset = TableOffset + TableWidth;

            const uint RowMask = (uint)num8.MaxValue << RowOffset;

            const byte ColWidth = num4.PackedWidth;

            const byte ColOffset = RowOffset + RowWidth;

            const uint ColMask = (uint)num4.MaxValue << ColOffset;

            public readonly RuleTableKind Kind;

            public readonly LogicClass Logic;

            public readonly ushort Table;

            public readonly byte Row;

            public readonly byte Col;

            [MethodImpl(Inline)]
            public Coordinate(RuleTableKind kind, LogicClass logic, ushort table, ushort row, byte col)
            {
                Kind = kind;
                Logic = logic;
                Table = table;
                Row = (byte)row;
                Col = col;
            }

            [MethodImpl(Inline)]
            public bool Equals(Coordinate src)
                => pack(this) == pack(src);

            public override int GetHashCode()
                => (int)pack(this);

            [MethodImpl(Inline)]
            public int CompareTo(Coordinate src)
            {
                var result = cmp(Kind,src.Kind);
                if(result == 0)
                {
                    result = Table.CompareTo(src.Table);
                    if(result==0)
                    {
                        result = Row.CompareTo(src.Row);
                        if(result == 0)
                            result = Col.CompareTo(src.Col);
                    }

                }
                return result;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static explicit operator Coordinate(uint src)
                => unpack(src);

            [MethodImpl(Inline)]
            public static explicit operator uint(Coordinate src)
                => pack(src);

            public static Coordinate Empty => default;
        }
    }
}