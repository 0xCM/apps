//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    public partial class XedDisasm
    {
        public struct DisasmSummaryBlock : IComparable<DisasmSummaryBlock>
        {
            public DisasmLineBlock Block;

            public AsmDisasmSummary Summary;

            [MethodImpl(Inline)]
            public DisasmSummaryBlock(DisasmLineBlock block, AsmDisasmSummary summary)
            {
                Block = block;
                Summary = summary;
            }

            public int CompareTo(DisasmSummaryBlock src)
                => Summary.CompareTo(src.Summary);
        }
    }
}