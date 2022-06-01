//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;

    public partial class AsmCoreCmd : WsCmdService<AsmCoreCmd>
    {
        static XedRuntime Xed;

        static AsmCmdRt CmdRt;

        static Index<ICmdProvider> Providers;

        static AsmCoreCmd Instance;

        public static AsmCoreCmd create(IWfRuntime wf, AsmCmdRt amsrt, ICmdProvider[] providers)
        {
            CmdRt = amsrt;
            Xed = amsrt.Xed;
            Providers = providers;
            Instance = create(wf);
            return Instance;
        }

        CoffServices Coff => Wf.CoffServices();

        XedDocs XedDocs => Xed.Docs;

        XedPaths XedPaths => Xed.Paths;

        XedRules Rules => Xed.Rules;

        XedDisasm Disasm2 => Xed.XedDisasm;

        XedDisasmSvc Disasm => CmdRt.XedDisasm;

        XedDb XedDb => Xed.XedDb;

        CsLang CsLang => Wf.CsLang();

        AsmDocs AsmDocs => Wf.AsmDocs();

        AsmCodeGen AsmCodeGen => Wf.AsmCodeGen();

        X86Dispatcher Jumps => Wf.X86Dispatcher();

        IntelSdm Sdm => Wf.IntelSdm();

        CheckRunner CheckRunner => Wf.CheckRunner();

        AsmRegSets Regs => Service(AsmRegSets.create);

        AsmOpCodes OpCodes => Wf.AsmOpCodes();


        protected override IWsCmdRunner CmdRunner
            => Xed.CmdRunner;

        IProjectWs Project()
            => CmdRunner.Project();

        [CmdOp("checks/run")]
        void ChecksExec()
            => CheckRunner.Run();

        [CmdOp("checks/list")]
        void ChecksList()
            => CheckRunner.ListChecks();

        ref readonly RuleTables RuleTables
            => ref Xed.Views.RuleTables;

        ref readonly Index<InstPattern> Patterns
            => ref Xed.Views.Patterns;

        ref readonly CellTables CellTables
            => ref Xed.Views.CellTables;

        ref readonly Index<RuleExpr> RuleExpr
            => ref Xed.Views.RuleExpr;

        protected override AppDb AppDb
            => Wf.AppDb();

        protected override void Initialized()
        {
            ProjectLoad("canonical");
        }

        protected override ICmdProvider[] CmdProviders(IWfRuntime wf)
            => Providers + core.array((ICmdProvider)this);
    }
}