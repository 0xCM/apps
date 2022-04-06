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
        public readonly struct RuleColumn
        {
            public readonly byte Index;

            public readonly asci32 Name;

            public readonly CellType Type;

            [MethodImpl(Inline)]
            public RuleColumn(byte index, asci32 name, CellType type)
            {
                Index = index;
                Name = name;
                Type = type;
            }
        }
    }
}