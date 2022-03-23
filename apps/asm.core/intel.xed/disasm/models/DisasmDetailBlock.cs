//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasm
    {
        public readonly struct DisasmDetailBlock : IComparable<DisasmDetailBlock>
        {
            public readonly DisasmDetail Detail;

            public readonly DisasmBlock Block;

            [MethodImpl(Inline)]
            public DisasmDetailBlock(DisasmDetail detail, DisasmBlock block)
            {
                Detail = detail;
                Block = block;
            }

            public int CompareTo(DisasmDetailBlock src)
                => Detail.CompareTo(src.Detail);
        }
    }
}