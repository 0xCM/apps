//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedPatterns;

    partial class XedRules
    {
        public void EmitRuleTables(RuleTables tables, Index<InstPattern> patterns)
        {
            EmitPatternOps(tables, patterns);

            exec(PllExec,
                () => EmitTableDefs(tables),
                () => EmitTableSigs(tables.SigInfo),
                () => EmitTableSchemas(tables.Schema),
                () => EmitRuleSeq(),
                () => EmitTableSpecs(tables),
                () => EmitTableFiles(tables)
            );
        }

        void EmitRuleSeq()
        {
            var src = XedRules.CalcRuleSeq();
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            FileEmit(dst.Emit(), src.Count, XedPaths.Service.DocTarget(XedDocKind.RuleSeq), TextEncodingKind.Asci);
        }
    }
}