//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class XedDb
    {
        public Index<LocatedField> CalcLocatedFields(RuleCells src)
            => Data(nameof(CalcLocatedFields), () => XedRules.CalcLocatedFields(src));
    }
}