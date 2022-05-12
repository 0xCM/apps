//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedGrids;
    using static Markdown;
    using static core;


    partial class AsmCoreCmd
    {
        [CmdOp("xed/gen")]
        Outcome CheckRules(CmdArgs args)
        {
            // var rules = CalcRules();
            // var dst = CsLang.emitter();
            // var indent = 4u;
            // var src = Rules.CalcSpecExpr(rules.Specs());
            // for(var i=0; i<src.Count; i++)
            // {
            //     ref readonly var expr = ref src[i];
            //     dst.LineComment(indent, string.Format("{0} {1:D2} {2}", expr.Sig, expr.Row, expr.Body));
            // }

            // var lines = dst.Emit();
            // var path = AppDb.CgStage("xed") + FS.file("rules.tables", FileKind.Cs.Ext());
            // AppSvc.FileEmit(lines, path);
            Gen();
            return true;
        }


        void Gen()
        {
            var dst = CsLang.emitter();
            var src = RuleExpr;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var e = ref src[i];
            }

        }

    }
}