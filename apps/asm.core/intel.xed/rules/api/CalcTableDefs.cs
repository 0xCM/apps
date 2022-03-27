//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public static Index<RuleTable> CalcTableDefs(RuleTableKind kind)
            => XedRules.reify(XedRules.CalcTableSpecs(XedPaths.Service.RuleSource(kind)));
    }
}