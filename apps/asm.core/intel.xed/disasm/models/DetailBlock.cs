//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasm
    {
        public readonly struct DetailBlock : IComparable<DetailBlock>
        {
            public readonly DisasmDetail Detail;

            public readonly DisasmBlock Block;

            [MethodImpl(Inline)]
            public DetailBlock(DisasmDetail detail, DisasmBlock block)
            {
                Detail = detail;
                Block = block;
            }

            public int CompareTo(DetailBlock src)
                => Detail.CompareTo(src.Detail);
        }
    }
}