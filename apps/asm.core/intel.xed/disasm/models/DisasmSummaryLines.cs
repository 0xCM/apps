//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDisasm
    {
        public readonly struct DisasmSummaryLines : IComparable<DisasmSummaryLines>
        {
            public readonly DisasmLineBlock Lines;

            public readonly DisasmSummary Summary;

            [MethodImpl(Inline)]
            public DisasmSummaryLines(DisasmLineBlock lines, DisasmSummary summary)
            {
                Lines = lines;
                Summary = summary;
            }

            public int CompareTo(DisasmSummaryLines src)
                => Summary.CompareTo(src.Summary);

            public static DisasmSummaryLines Empty => new (DisasmLineBlock.Empty, DisasmSummary.Empty);
        }
    }
}