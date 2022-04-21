//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDisasm
    {
        public readonly record struct SummaryLines : IComparable<SummaryLines>
        {
            public readonly DisasmBlock Block;

            public readonly SummaryRow Row;

            [MethodImpl(Inline)]
            public SummaryLines(DisasmBlock lines, SummaryRow summary)
            {
                Block = lines;
                Row = summary;
            }

            public int CompareTo(SummaryLines src)
                => Row.CompareTo(src.Row);

            public static SummaryLines Empty => new (DisasmBlock.Empty, SummaryRow.Empty);
        }
    }
}