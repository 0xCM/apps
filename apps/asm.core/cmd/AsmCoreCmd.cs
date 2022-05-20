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

        IProjectWs _Project;

        XedDocs XedDocs => CmdRt.XedDocs;

        XedPaths XedPaths => CmdRt.XedPaths;

        XedRules Rules => CmdRt.XedRules;

        XedDisasmSvc Disasm => CmdRt.XedDisasm;

        XedImport XedImport => CmdRt.XedImport;

        XedDb XedDb => CmdRt.XedDb;

        CsLang CsLang => Service(Wf.CsLang);

        AsmDocs AsmDocs => Service(Wf.AsmDocs);

        AsmCodeGen AsmCodeGen => Service(Wf.AsmCodeGen);

        X86Dispatcher Jumps => Service(() => X86Dispatcher.create(Wf));

        IntelSdm Sdm => Service(Wf.IntelSdm);

        CheckRunner CheckRunner => Service(Wf.CheckRunner);

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

        protected override void ProjectSelected(IProjectWs ws)
        {
            _Project = Require.notnull(ws);
            Status($"Project {ws.Project} selected");
        }

        protected override AppDb AppDb
            => Xed.AppDb;

        protected override WsProjects Projects
            => Xed.Projects;

        protected override void Initialized()
        {
            ProjectLoad("canonical");
        }

        protected override ICmdProvider[] CmdProviders(IWfRuntime wf)
            => Providers + core.array((ICmdProvider)this);
    }
}