//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RuleSchema : IComparable<RuleSchema>
        {
            public static RuleColumn col(byte index, string name, CellType type)
                => new (index,name,type);

            public uint Seq;

            public readonly Index<RuleColumn> Columns;

            public int CompareTo(RuleSchema src)
            {
                var result = 0;
                return result;
            }
        }
    }
}