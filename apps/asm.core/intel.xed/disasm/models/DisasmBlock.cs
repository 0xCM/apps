//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
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