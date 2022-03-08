//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public static RuleSig sig(in RuleTermTable src)
            => new RuleSig(src.Name, src.ReturnType.IsNonEmpty ? src.ReturnType.Text : "void");

        public static RuleSig sig(in RuleTable src)
            => new RuleSig(src.Name, src.ReturnType.IsNonEmpty ? src.ReturnType.Text : "void");
    }
}