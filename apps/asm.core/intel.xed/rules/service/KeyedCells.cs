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
            public static KeyedCells create(ConcurrentDictionary<RuleSig,Index<KeyedCell>> src, string desc)
                => new KeyedCells(src,desc);

            public static KeyedCells create(Dictionary<RuleSig,Index<KeyedCell>> src, string desc)
                => new KeyedCells(src.ToConcurrentDictionary(),desc);

            public readonly uint CellCount;

            public readonly string Description;

            public readonly uint TableCount;

            public KeyedCells(ConcurrentDictionary<RuleSig,Index<KeyedCell>> src, string desc)
                : base(src)
            {
                Description = desc;
                TableCount = (uint)src.Count;
                CellCount = src.Values.Map(x => x.Count).Sum();
            }

            public Index<KeyedCell> Flatten()
                => flatten(this);
        }
   }
}