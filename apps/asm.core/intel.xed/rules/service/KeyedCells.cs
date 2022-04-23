//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class KeyedCells : SortedLookup<RuleSig,Index<KeyedCell>>
        {
            public KeyedCells(Dictionary<RuleSig,Index<KeyedCell>> src)
                : base(src)
            {

            }

            public static implicit operator KeyedCells(Dictionary<RuleSig,Index<KeyedCell>> src)
                => new KeyedCells(src);
        }
   }
}