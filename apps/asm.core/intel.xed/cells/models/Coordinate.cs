//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(Width)]
        public readonly record struct Coordinate : IComparable<Coordinate>
        {
            [MethodImpl(Inline)]
            public static uint pack(Coordinate src)
            {
                var result = 0u;
                result |= ((uint)src.Kind << KindOffset);
                result |= ((uint)src.Table << TableOffset);
                result |= ((uint)src.Row << RowOffset);
                result |= ((uint)src.Col << ColOffset);
                return result;
            }

            [MethodImpl(Inline)]
            public static Coordinate unpack(uint src)
            {
                var kind = (RuleTableKind)((src & KindMask) >> KindOffset);
                var rule = (RuleName)((src & TableMask) >> TableOffset);
                var row = (ushort)((src & RowMask) >> RowOffset);
                var col = (byte)((src & ColMask) >> ColOffset);
                return new Coordinate(new RuleSig(kind,rule), row,col);
            }

            public const byte Width = KindWidth + TableWidth + RowWidth + ColWidth;

            public const uint Mask = KindMask | TableMask | RowMask | ColMask;

            public const string RenderPatern = "{0,-32} | ({1}, {2:X3}, {3:X2}, {4:X2})";

            const byte KindWidth = num2.Width;

            const byte KindOffset = 0;

            const uint KindMask = (uint)num2.MaxValue << KindOffset;

            const byte TableWidth = num9.Width;

            const byte TableOffset = KindOffset + KindWidth;

            const uint TableMask = (uint)num9.MaxValue << TableOffset;

            const byte RowWidth = num8.Width;

            const byte RowOffset = TableOffset + TableWidth;

            const uint RowMask = (uint)num8.MaxValue << RowOffset;

            const byte ColWidth = num4.Width;

            const byte ColOffset = RowOffset + RowWidth;

            const uint ColMask = (uint)num4.MaxValue << ColOffset;

            public readonly RuleTableKind Kind;

            public readonly RuleName Table;

            public readonly byte Row;

            public readonly byte Col;

            [MethodImpl(Inline)]
            public Coordinate(RuleSig rule, ushort row, byte col)
            {
                Kind = rule.TableKind;
                Table = rule.TableName;
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
                    result = XedRules.cmp(Table,src.Table);
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
             => string.Format(Coordinate.RenderPatern,
                XedRender.format(Table),
                XedRender.format(Kind),
                (ushort)Table,
                Row,
                Col
                );

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