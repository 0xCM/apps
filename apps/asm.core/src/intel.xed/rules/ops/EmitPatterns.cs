//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        void EmitPatterns()
        {
            EmitRulePatterns(CalcEncInstDefs(), CalcDecInstDefs());
        }

        Index<RulePatternInfo> EmitRulePatterns(Index<InstDef> enc, Index<InstDef> dec)
        {
            var patterns = CalcPatternInfo(enc);
            TableEmit(patterns.View, RulePatternInfo.RenderWidths, XedPaths.DocTarget(XedDocKind.EncRulePatterns));
            TableEmit(CalcPatternInfo(dec).View, RulePatternInfo.RenderWidths, XedPaths.DocTarget(XedDocKind.DecRulePatterns));
            return patterns;
        }
    }
}