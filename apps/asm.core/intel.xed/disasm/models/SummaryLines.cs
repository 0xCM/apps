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
            public readonly LineBlock Lines;

            public readonly SummaryRow Summary;

            [MethodImpl(Inline)]
            public SummaryLines(LineBlock lines, SummaryRow summary)
            {
                Lines = lines;
                Summary = summary;
            }

            public int CompareTo(SummaryLines src)
                => Summary.CompareTo(src.Summary);

            public static SummaryLines Empty => new (LineBlock.Empty, SummaryRow.Empty);
        }
    }
}