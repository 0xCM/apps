//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDisasm
    {
        public struct DisasmBlock : IComparable<DisasmBlock>
        {
            public DisasmLineBlock Lines;

            public AsmDisasmSummary Summary;

            [MethodImpl(Inline)]
            public DisasmBlock(DisasmLineBlock lines, AsmDisasmSummary summary)
            {
                Lines = lines;
                Summary = summary;
            }

            public int CompareTo(DisasmBlock src)
                => Summary.CompareTo(src.Summary);
        }
    }
}