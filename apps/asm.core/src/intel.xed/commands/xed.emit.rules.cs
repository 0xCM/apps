//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/rules")]
        Outcome EmitXedRules(CmdArgs args)
        {
            Xed.Rules.EmitCatalog();
            EmitRuleTables();
            return true;
        }

        void EmitRuleTables()
        {
            AppDb.Xed("rules.tables").Clear();
            iter(Xed.Rules.CalcTables().Values, t => EmitRuleTable(rows(t)));
        }

        void EmitRuleTable(in RuleTableRows src)
        {
            TableEmit(src.Data.View, RuleTableRow.RenderWidths, AppDb.XedTable<RuleTableRow>("rules.tables", src.TableName));
        }

    }
}