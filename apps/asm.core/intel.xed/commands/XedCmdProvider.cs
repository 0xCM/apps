//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public partial class XedCmdProvider : AppCmdService<XedCmdProvider,CmdShellState>, IProjectConsumer<XedCmdProvider>
    {
        IntelXed Xed => Service(Wf.IntelXed);

        XedDisasmSvc Disasm => Service(Wf.XedDisasm);

        XedDocs XedDocs => Service(Wf.XedDocs);

        WsProjects Projects => Service(Wf.WsProjects);

        XedPaths XedPaths => Service(Wf.XedPaths);

        XedDisasmSvc XedDisasmSvc => Service(Wf.XedDisasm);

        XedLookups XedLookups => Service(() => XedLookups.Service);


        AppDb AppDb => Service(Wf.AppDb);

        AppCmdRunner _AppCmdRunner;

        IProjectWs _Project;

        IProjectProvider _ProjectProvider;

        [MethodImpl(Inline)]
        IProjectProvider ProjectProvider()
            => _ProjectProvider;

        public XedCmdProvider With(IProjectProvider provider)
        {
            _ProjectProvider = provider;
            return this;
        }

        IProjectWs Project()
            => ProjectProvider().Project();

        WsContext Context()
            => Projects.Context(ProjectProvider(), Project());

        [MethodImpl(Inline)]
        public IProjectWs Project(ProjectId id)
        {
            _Project = Ws.Project(id);
            return Project();
        }

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

        [CmdOp("project")]
        Outcome LoadProject(CmdArgs args)
            => _AppCmdRunner.LoadProject(args);
    }
}