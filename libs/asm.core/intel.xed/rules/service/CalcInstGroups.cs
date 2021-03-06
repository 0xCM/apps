//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public Index<InstGroup> CalcInstGroups(Index<InstPattern> src)
            => Data(nameof(CalcInstGroups),() => XedPatterns.groups(src).Values.ToArray().Sort());
    }
}