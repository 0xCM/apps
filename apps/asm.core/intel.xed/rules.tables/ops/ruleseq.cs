//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        partial struct TableCalcs
        {
            public static Index<RuleSeq> ruleseq()
                => XedParsers.ruleseq(XedPaths.Service.DocSource(XedDocKind.RuleSeq));
        }

    }
}