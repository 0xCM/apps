//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct Coordinate
        {
            public readonly ushort Table;

            public readonly ushort Row;

            public readonly byte Col;

            [MethodImpl(Inline)]
            public Coordinate(ushort table, ushort row, byte col)
            {
                Table = table;
                Row = row;
                Col = col;
            }

            [MethodImpl(Inline)]
            public int CompareTo(Coordinate src)
            {
                var result = Table.CompareTo(src.Table);
                if(result==0)
                {
                    result = Row.CompareTo(src.Row);

                    if(result == 0)
                        result = Col.CompareTo(src.Col);
                }
                return result;
            }

            const string RenderPattern = "{0,-6} | {0, -6} | {0, -6}";

            public string Format()
                => string.Format(RenderPattern, Table, Row, Col);

            public override string ToString()
                => Format();
        }
    }
}