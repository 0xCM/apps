//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public Index<InstLayout> CalcInstLayouts(Index<InstGroup> groups)
            => Data(nameof(CalcInstLayouts), () => XedPatterns.layouts(groups));

        public Index<InstLayout> CalcInstLayouts(Index<InstPattern> patterns)
            => CalcInstLayouts(CalcInstGroups(patterns));

        public Index<InstLayout> CalcInstLayouts()
            => CalcInstLayouts(CalcInstPatterns());
    }
}