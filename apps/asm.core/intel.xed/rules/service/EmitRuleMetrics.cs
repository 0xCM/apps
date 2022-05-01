//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public void EmitRuleMetrics(RuleCells src)
        {
            var dst = text.emitter();
            for(var i=0; i<src.TableCount; i++)
                dst.AppendLine(CalcTableMetrics(src[i]));
            FileEmit(dst.Emit(), src.TableCount, XedPaths.RuleTargets() + FS.file("xed.rules.metrics", FS.Txt));
        }
    }
}