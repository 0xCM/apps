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

        AppServices AppSvc => Service(Wf.AppServices);

        AppDb AppDb => Xed.AppDb;

        BitMaskServices ApiBitMasks => Service(Wf.ApiBitMasks);

        ApiComments ApiComments => Service(Wf.ApiComments);

        AsmDocs AsmDocs => Service(Wf.AsmDocs);

        AsmTables AsmTables => Service(Wf.AsmTables);

        [MethodImpl(Inline)]
        StringRef Ref(string src)
            => Xed.Allocator.String(src);

        [MethodImpl(Inline)]
        Label Label(string src)
            => Xed.Allocator.Label(src);

        public XedCmdProvider With(XedRuntime runtime)
        {
            Xed = runtime;
            return this;
        }

        ref readonly RuleTables RuleTables => ref Xed.Views.RuleTables;

        ref readonly Index<InstPattern> Patterns => ref Xed.Views.Patterns;

        ref readonly CellTables CellTables => ref Xed.Views.CellTables;

        ref readonly Index<RuleExpr> RuleExpr => ref Xed.Views.RuleExpr;

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