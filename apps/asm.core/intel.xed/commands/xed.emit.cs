//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/patterns")]
        Outcome EmitPatterns(CmdArgs args)
        {
            var patterns = Rules.CalcPatterns();
            Rules.Emit(patterns);
            return true;
        }

        [CmdOp("xed/db/emit")]
        Outcome EmitSchema(CmdArgs args)
        {
            XedDb.EmitArtifacts();
            return true;
        }

        [CmdOp("xed/emit/analysis")]
        Outcome EmitAnalysis(CmdArgs args)
        {
            var src = CalcRuleCells();
            var analyzer = new RuleAnalyzer(this, (data,count,path) => FileEmit(data, count,path, TextEncodingKind.Asci));
            analyzer.Run(src);
            return true;
        }

        [CmdOp("xed/emit/layouts")]
        Outcome EmitLayouts(CmdArgs args)
        {
            Rules.Emit(Rules.CalcInstLayouts(CalcPatterns()));
            return true;
        }

        [CmdOp("xed/emit/rulerecs")]
        Outcome EmitRuleRecords(CmdArgs args)
        {
            var cells = CalcRuleCells();
            TableEmit(cells.Tables.View, RuleCellRecord.RenderWidths, XedPaths.RuleTable<RuleCellRecord>());
            return true;
        }

        [CmdOp("xed/emit/rules")]
        Outcome EmitRuleTables(CmdArgs args)
        {
            var rules = CalcRules();
            Write("Emitting rules");
            Rules.Emit(rules);
            return true;
        }

        [CmdOp("xed/emit/tabledefs")]
        Outcome EmitTableDefs(CmdArgs args)
        {
            var rules = CalcRules();
            Rules.EmitTableDefs(rules);
            return true;
        }

        [CmdOp("xed/emit/cells")]
        Outcome EmitTableCells(CmdArgs args)
        {
            var rules = CalcRules();
            Rules.EmitTableDefReport(rules);
            return true;
        }

        [CmdOp("xed/emit/docs")]
        Outcome EmitDocs(CmdArgs args)
        {
            XedDocs.EmitDocs(CalcRules());
            XedDocs.EmitDocs(CalcPatterns());
            return true;
        }

        [CmdOp("xed/emit/attribs")]
        Outcome CheckOps(CmdArgs args)
        {
            Rules.EmitInstAttribs(CalcPatterns());
            return true;
        }

        [CmdOp("xed/emit/groups")]
        Outcome EmitInstGroups(CmdArgs args)
        {
            var patterns = CalcPatterns();
            var groups = Rules.CalcInstGroups(patterns);
            Rules.Emit(groups);
           return true;
        }

        [CmdOp("xed/emit/catalog")]
        Outcome EmitXedCat(CmdArgs args)
        {
            Xed.EmitCatalog();
            return true;
        }


        [CmdOp("xed/emit/isa")]
        Outcome XedIsa(CmdArgs args)
            => Xed.EmitIsaForms(arg(args,0).Value);
   }
}