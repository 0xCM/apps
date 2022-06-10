//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppDb : IAppDb
    {
        readonly DbPaths Paths;

        readonly DbTargets _Targets;

        readonly DbSources _Sources;

        readonly DbSources _Control;

        public AppDb()
        {
            Paths = DbPaths.load();
            _Targets = new DbTargets(Paths.Targets);
            _Sources = new DbSources(Paths.Sources);
            _Control = new DbSources(Paths.Control);
        }

        public ref readonly EnvData Env
            => ref AppData.AppEnv;

        EnvData IEnvProvider.Env
            => AppData.AppEnv;

        public ref readonly DbTargets Targets()
            => ref _Targets;

        public ref readonly DbSources Sources()
            => ref _Sources;

        public ref readonly DbSources Control()
            => ref _Control;

        public DbSources Sources(string scope)
            => Sources().Sources(scope);

        public FS.FilePath Table<T>(ProjectId id)
            where T : struct
                => ProjectData(id).Table<T>(id);

        public DbTargets Projects(string scope)
            => Targets().Targets(scope);

        public DbTargets ProjectTargets(ProjectId id)
            => Targets().Targets(id);

        public DbTargets ProjectData(ProjectId id)
            => new DbTargets(Targets().Targets("projects"), id);

        public DbTargets CgTargets(CgTarget dst)
            => AppData.CgProjects.Targets($"codegen/{Symbols.format(dst)}/src");

        public DbTargets CgTargets(CgTarget dst, string scope)
            => CgTargets(dst).Targets(scope);

        public DbSources ProjectSources(ProjectId id)
            => Sources().Sources(id);

        public DbTargets Targets(string scope)
            => Targets().Targets(scope);

        public DbTargets Logs()
            => Targets("logs");

        public DbTargets Logs(string scope)
            => Targets($"logs/{scope}");

        public DbTargets RuntimeLogs()
            => Logs("runtime");

        public DbTargets ApiTargets()
            => Targets().Targets("api");

        public DbTargets ApiTargets(string scope)
            => Targets($"api/{scope}");

        public DbTargets ProjectDb(ProjectId project, string scope)
            => new DbTargets(ProjectData(project), scope);

        public DbTargets DbTargets(IProjectWs ws)
            => Targets($"projects/{ws.Project}");

        public DbTargets DbTargets(ProjectId ws)
            => Targets($"projects/{ws}");

        public DbTargets AsmTargets(ProjectId ws)
            => DbTargets(ws).Targets("asm.code");

        public DbTargets HexTargets(ProjectId ws)
            => DbTargets(ws).Targets("obj.hex");

        public DbTargets XedTargets(ProjectId ws)
            => DbTargets(ws).Targets("xed.disasm");

        static SortedDictionary<string,FileKind> FileKindLU;

        static Index<FileKind,Sym<FileKind>> _FileKindSyms;

        static AppDb()
        {
            var symbols = Symbols.index<FileKind>().View.ToArray();
            _FileKindSyms = symbols;
            FileKindLU = symbols.Map(s => ("." + s.Expr.Format().ToLower(), s.Kind)).ToSortedDictionary(TextLengthComparer.create(true));
        }
    }
}