//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDisasm
    {
        public readonly struct DisasmBlock : IComparable<DisasmBlock>
        {
            public readonly DisasmLineBlock Lines;

            public readonly DisasmSummary Summary;

            [MethodImpl(Inline)]
            public DisasmBlock(DisasmLineBlock lines, DisasmSummary summary)
            {
                Lines = lines;
                Summary = summary;
            }

            public int CompareTo(DisasmBlock src)
                => Summary.CompareTo(src.Summary);
        }
    }
}