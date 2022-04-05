//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static RuleGridCell cell(bool premise, RuleSig sig, byte index, in RuleCriterion criterion)
            => new RuleGridCell(premise, index, sig.TableKind, criterion);
    }
}