//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedRuleTables
    {
        [MethodImpl(Inline), Op]
        public static RuleSig sig(RuleTableKind kind, string name)
            => new RuleSig(kind,name);
    }
}