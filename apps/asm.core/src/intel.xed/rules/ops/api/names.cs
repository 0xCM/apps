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
        public static Index<string> names(Index<RuleTable> src)
            => src.Select(x => x.Name.Format()).Where(nonempty).Distinct().Sort();
    }
}