//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static core;

    public partial class XedCmdProvider : AppCmdService<XedCmdProvider,CmdShellState>
    {
        XedRuntime Xed;

        IntelXed Main => Xed.Main;

        XedDocs XedDocs => Xed.Docs;

        XedPaths XedPaths => Xed.Paths;

        XedRules Rules => Xed.Rules;

        XedDisasmSvc Disasm => Xed.XedDisasm;

        XedDb XedDb => Xed.XedDb;

        AppServices AppServices => Xed.AppServices;

        AppDb AppDb => Xed.AppDb;

        BitMaskServices ApiBitMasks => Service(Wf.ApiBitMasks);

        ApiComments ApiComments => Service(Wf.ApiComments);

        AsmDocs AsmDocs => Service(Wf.AsmDocs);

        public XedCmdProvider With(XedRuntime runtime)
        {
            Xed = runtime;
            //runtime.Start();
            return this;
        }

        RuleTables CalcRules() => Rules.CalcRuleTables();

        Index<InstPattern> CalcPatterns() => Rules.CalcPatterns();

        RuleCells CalcRuleCells() => Rules.CalcRuleCells(CalcRules());

        AppCmdRunner _AppCmdRunner;

        IProjectProvider _ProjectProvider;

        WsProjects Projects => Xed.Projects;

        WsContext Context()
            => Projects.Context(_ProjectProvider);

        [CmdOp("project")]
        Outcome LoadProject(CmdArgs args)
            => _AppCmdRunner.LoadProject(args);

        void RunCmd(string name, CmdArgs args)
            => Dispatcher.Dispatch(name, args);

        void LoadProject(string name)
            => RunCmd("project", new CmdArg[]{new CmdArg(EmptyString, name)});

        protected override void Initialized()
        {
            _AppCmdRunner = AppCmdRunner.create(Wf);
            _ProjectProvider = _AppCmdRunner;
            LoadProject("canonical");
        }
    }
}