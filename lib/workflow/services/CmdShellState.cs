//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiComplete]
    public class CmdShellState
    {
        FS.FolderPath _CurrentDir;

        ProjectId _ProjectId;

        FS.Files _Files;

        ApiPath _Api;

        IWorkspace _Workspace;

        IProjectWs _Project;

        Index<Assembly> _ApiComponents;

        protected DevWs Ws;

        protected IWfRuntime Wf;

        public CmdShellState()
        {
            _CurrentDir = FS.FolderPath.Empty;
            _Files = array<FS.FilePath>();
            _Api = ApiPath.Empty;
            _ApiComponents = array<Assembly>();
        }

        public void Init(IWfRuntime wf, DevWs ws)
        {
            Ws = ws;
            Wf = wf;
            _Workspace = ws;
            _CurrentDir = ws.Root;
        }

        [MethodImpl(Inline)]
        public IWorkspace Workspace()
            => _Workspace;

        [MethodImpl(Inline)]
        public ApiPath Api()
            => _Api;

        [MethodImpl(Inline)]
        public ApiPath Api(ApiPath src)
        {
            _Api = src;
            return Api();
        }

        [MethodImpl(Inline)]
        public ProjectId ProjectId()
            => _ProjectId;

        [MethodImpl(Inline)]
        public IProjectWs Project()
            => _Project;

        [MethodImpl(Inline)]
        public IProjectWs Project(ProjectId id)
        {
            _ProjectId = id;
            _Project = Ws.Project(id);
            return Project();
        }

        [MethodImpl(Inline)]
        public IProjectWs Project(IProjectWs ws)
        {
            _ProjectId = ws.Project;
            _Project = ws;
            return Project();
        }

        [MethodImpl(Inline)]
        public FS.FolderPath CurrentDir()
            => _CurrentDir;

        [MethodImpl(Inline)]
        public FS.FolderPath CurrentDir(FS.FolderPath value)
        {
            _CurrentDir = value;
            return CurrentDir();
        }

        [MethodImpl(Inline)]
        public FS.Files Files()
            => _Files;

        public FS.Files Files(FS.FileExt ext)
            => Files().Where(f => f.Is(ext));

        public FS.Files Files(FS.FileExt a, FS.FileExt b)
            => Files().Where(f => f.Is(a) || f.Is(b));

        public FS.Files Files(FS.FileExt a, FS.FileExt b, FS.FileExt c)
            => Files().Where(f => f.Is(a) || f.Is(b) || f.Is(c));

        public FS.Files Files(FS.FileExt a, FS.FileExt b, FS.FileExt c, FS.FileExt d)
            => Files().Where(f => f.Is(a) || f.Is(b) || f.Is(c) || f.Is(d));

        [MethodImpl(Inline)]
        public FS.Files Files(FS.Files src)
        {
            _Files = src;
            return Files();
        }

        public ReadOnlySpan<Assembly> ApiComponents(bool justParts, bool libonly)
        {
            if(_ApiComponents.IsEmpty)
                _ApiComponents = ApiRuntimeLoader.assemblies(justParts, libonly);
            return _ApiComponents;
        }
    }
}