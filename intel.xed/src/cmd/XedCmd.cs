//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;
    using static XedRules;
    using static MemDb;

    public class XedCmd : WsCmdService<XedCmd>
    {
        public static IAppCmdService commands(IWfRuntime wf, bool start)
        {
            var cmd = create(wf);
            cmd.Xed = XedRuntime.create(wf);
            if(start)
                cmd.Xed.Start();
            return cmd;
        }

        XedRuntime Xed;

        protected override IWsCmdRunner CmdRunner
            => Xed.CmdRunner;

        XedPaths XedPaths => Wf.XedPaths();

        [CmdOp("xed/collect")]
        void XedCollect()
            => Xed.Disasm.Collect(Context());

        [CmdOp("xed/start")]
        void StartRuntime()
        {
            if(!Xed.Running)
                Xed.Start();
        }

        [CmdOp("xed/emit/types")]
        Outcome CheckXedDb(CmdArgs args)
        {
            var rows = Xed.Views.TypeTables.SelectMany(x => x.Rows).Sort().Resequence();
            AppSvc.TableEmit(rows, XedPaths.DbTable<TypeTableRow>());
            return true;
        }

        [CmdOp("xed/emit/sigs")]
        void EmitInstSig()
            => Xed.Rules.EmitInstSigs(Xed.Views.Patterns);

        [CmdOp("xed/import")]
        void RunImport()
            => Xed.Import.Run();

        [CmdOp("xed/import/check")]
        void CheckXedImports()
        {
            var blocks = Xed.Views.InstImports;
            ref readonly var lines = ref blocks.BlockLines;
            var forms = lines.Keys.Index().Sort();
            ref readonly var source = ref blocks.DataSource;
        }

        [CmdOp("xed/disasm/flow")]
        void RunDisasmFlow()
        {
            var context = Context();
            var flow = XedDisasm.flow(context);
            var targets = bag<ITarget>();
            var sources = XedDisasm.sources(context);
            iter(XedDisasm.sources(context), src => {
                var dst = Wf.DisasmAnalyser();
                flow.Run(src,dst);
                targets.Add(dst);
            }, true);
        }

        [CmdOp("xed/emit/seq")]
        void EmitSeq()
            => Xed.Rules.EmitSeq();

        [CmdOp("xed/emit/patterns")]
        void EmitPatterns()
            => Xed.Rules.EmitPatternData(Xed.Views.Patterns);

        [CmdOp("xed/emit/expr")]
        void EmitRuleExpr()
            => Xed.Rules.Emit(Xed.Views.RuleExpr);

        [CmdOp("xed/db/emit")]
        void DbEmit()
            => Xed.XedDb.EmitArtifacts();

        [CmdOp("xed/emit/rules/tables")]
        void EmitRuleTables()
            => Xed.Rules.EmitRuleData(Xed.Views.RuleTables);

        [CmdOp("xed/emit/rules/pages")]
        void EmitTableDefs()
            => Xed.Rules.EmitRulePages(Xed.Views.RuleTables);

        [CmdOp("xed/emit/rules/specs")]
        void EmitTableCells()
            => Xed.Rules.EmitTableSpecs(Xed.Views.RuleTables);

        [CmdOp("xed/emit/docs")]
        void EmitDocs()
            => Xed.Docs.Emit();

        [CmdOp("xed/emit/attribs")]
        void EmitInstAttribs()
            => Xed.Rules.EmitInstAttribs(Xed.Views.Patterns);

        [CmdOp("xed/emit/groups")]
        void EmitInstGroups()
            => Xed.Rules.EmitInstGroups(Xed.Rules.CalcInstGroups(Xed.Views.Patterns));

        [CmdOp("xed/emit/catalog")]
        void EmitXedCat()
            => Xed.EmitCatalog();
    }
}