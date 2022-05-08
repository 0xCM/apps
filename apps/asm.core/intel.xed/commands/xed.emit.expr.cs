//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/expr")]
        Outcome EmitRuleExpr(CmdArgs args)
        {
            const string Pattern = "{0,-28} | {1,-6} | {2,-6} | {3}";
            var rules = CalcRules();
            var dst = text.emitter();
            dst.AppendLineFormat(Pattern, "Rule", "Kind", "Row", "Expression");
            ref readonly var specs = ref rules.Specs();
            var sz = z8;
            for(var i=0; i<specs.EntryCount; i++)
            {
                ref readonly var table = ref specs[i];
                for(var j=0; j<table.RowCount; j++)
                {
                    ref readonly var row = ref table[j];

                    dst.AppendLineFormat(Pattern, table.Sig.TableName, table.Sig.TableKind, row.RowIndex, row.Format());
                }
            }

            FileEmit(dst.Emit(), 0, XedPaths.RuleTarget("expressions", FS.Csv));

            return true;
        }
    }
}