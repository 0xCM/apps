//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public SortedLookup<InstClass,InstGroup> CalcInstGroups()
            => CalcInstGroups(CalcInstPatterns());

        public SortedLookup<InstClass,InstGroup> CalcInstGroups(Index<InstPattern> src)
            => Data(nameof(CalcInstGroups),() => XedPatterns.groups(src));
    }
}