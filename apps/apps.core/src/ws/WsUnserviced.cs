//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct WsUnserviced
    {
        public static WsUnserviced create()
            => new (DevWs.create());

        [MethodImpl(Inline)]
        public static WsUnserviced create(DevWs ws)
            => new (ws);

        readonly DevWs Ws;

        readonly IProjectDb Db;

        [MethodImpl(Inline)]
        WsUnserviced(DevWs ws)
        {
            Ws = ws;
            Db = Ws.ProjectDb();
        }

        [MethodImpl(Inline)]
        public IProjectWs Project(ProjectId id)
            => Ws.Project(id);

        public FS.FolderPath ProjectData()
            => Db.Root;

        public IProjectWs Project(FS.FolderPath root, ProjectId id)
            => ProjectWs.create(root, id);

        public FS.FolderPath ProjectData(IProjectWs project)
            => Db.ProjectData() + FS.folder(project.Name.Format());

        public FS.FolderPath ProjectData(IProjectWs project, string scope)
            => ProjectData(project) + FS.folder(scope);

        public FS.FilePath ProjectDataFile(IProjectWs project, FileKind kind)
            => ProjectData(project) + FS.file(project.Name.Format(), kind.Ext());

        public FS.Files SourceFiles(IProjectWs ws, Subject? scope)
        {
            if(scope != null)
                return ws.SrcFiles(scope.Value.Format());
            else
                return ws.SrcFiles();
        }

        public FS.FilePath ScriptFlowPath(IProjectWs project, ScriptId scriptid)
            => ProjectData(project) + Tables.filename<ToolCmdFlow>(scriptid);

        public FS.FilePath Table<T>(IProjectWs project)
            where T : struct
                => Db.ProjectData() + FS.folder(project.Name.Format()) + FS.file(string.Format("{0}.{1}", project.Name, TableId.identify<T>()),FS.Csv);

        public FS.FolderPath XedDisasmDir(IProjectWs project)
            => ProjectData(project, "xed.disasm");
    }
}