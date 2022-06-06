//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppDb : AppService<AppDb>, IAppDb
    {
        FS.FolderPath WsRoot;

        FS.FolderPath ProjectRoot;

        FS.FolderPath ProjectDbRoot;

        protected override void Initialized()
        {
            WsRoot = Ws.Root;
            ProjectRoot = WsRoot + FS.folder("projects");
            ProjectDbRoot = ProjectRoot + FS.folder("db");
        }

        public DbTargets Projects()
            => new DbTargets(ProjectRoot,EmptyString);

        public WsDb WsDb(string name)
            => new WsDb(ProjectDbRoot + FS.folder(name));

        public DbTargets Projects(string scope)
            => new DbTargets(ProjectRoot, scope);

        public DbTargets Project(string name)
            => Projects().Targets(name);

        public new DbTargets ProjectDb(string name)
            => new DbTargets(ProjectDbRoot + FS.folder("projects"), name);

        public new DbTargets ProjectDb()
            => new DbTargets(ProjectDbRoot + FS.folder("projects"));

        public DbTargets CgTargets(CgTarget dst)
            => new DbTargets(Env.ZDev, $"codegen/{Symbols.format(dst)}/src");

        public DbTargets CgTargets(CgTarget dst, string scope)
            => CgTargets(dst).Targets(scope);

        [MethodImpl(Inline)]
        public DbTargets Targets()
            => new DbTargets(ProjectDbRoot, EmptyString);

        [MethodImpl(Inline)]
        public DbTargets Targets(string scope)
            => new DbTargets(ProjectDbRoot, scope);

        public DbSources Sources(string scope)
            => new DbSources(ProjectDbRoot + FS.folder("sources"), scope);

        public DbTargets Logs()
            => Targets("logs");

        public DbTargets Logs(string scope)
            => Targets($"logs/{scope}");

        public DbTargets ApiTargets()
            => Targets("api");

        public DbTargets ApiTargets(string scope)
            => Targets($"api/{scope}");

        public new DbTargets ProjectDb(IProjectWs project, string scope)
            => new DbTargets(ProjectDb(project.Name), scope);

        public DbTargets DbTargets(IProjectWs ws)
            => Targets($"projects/{ws.Project}");

        public DbTargets AsmTargets(IProjectWs ws)
            => DbTargets(ws).Targets("asm.code");

        public DbTargets HexTargets(IProjectWs ws)
            => DbTargets(ws).Targets("obj.hex");

        public DbTargets XedTargets(IProjectWs ws)
            => DbTargets(ws).Targets("xed.disasm");

        public FileCatalog Files(IProjectWs ws)
            => FileCatalog.load(ws);

        public FileCatalog Files(ProjectId project)
            => FileCatalog.load(project);
    }
}