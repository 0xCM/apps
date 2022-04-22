//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/patterns")]
        Outcome EmitPatterns(CmdArgs args)
        {
            var patterns = Xed.Rules.CalcPatterns();
            Xed.Rules.EmitPatterns(patterns);
            return true;
        }

        [CmdOp("xed/emit/rules")]
        Outcome EmitRuleTables(CmdArgs args)
        {
            var rules = Xed.Rules.CalcRules();
            Write("Emitting rules");
            Xed.Rules.EmitRules(rules);
            return true;
        }

        [CmdOp("xed/emit/cells")]
        Outcome EmitRuleCells(CmdArgs args)
        {
            var rules = Xed.Rules.CalcRules();
            Xed.Rules.EmitRuleCells(rules);
            return true;
        }

        [CmdOp("xed/emit/docs")]
        Outcome EmitDocs(CmdArgs args)
        {
            XedDocs.EmitDocs(Xed.Rules.CalcRules(), Xed.Rules.CalcInstPatterns());
            return true;
        }

        [CmdOp("xed/emit/attribs")]
        Outcome CheckOps(CmdArgs args)
        {
            Xed.Rules.EmitInstAttribs(Xed.Rules.CalcInstPatterns());
            return true;
        }

        [CmdOp("xed/emit/groups")]
        Outcome EmitInstGroups(CmdArgs args)
        {
            var patterns = Xed.Rules.CalcInstPatterns();
            var groups = Xed.Rules.CalcInstGroups(patterns);
            Xed.Rules.Emit(groups);
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