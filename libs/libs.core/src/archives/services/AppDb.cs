//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppDb : IAppDb
    {
        public static AppDb Service => GlobalSvc.Instance.AppDb;


        public ref readonly EnvData Env
            => ref AppData.AppEnv;

        public DbTargets Targets()
            => AppData.ProjectDb;

        public DbTargets Projects()
            => AppData.Projects;

        public static FS.FilePath table<T>(ProjectId od)
            where T : struct
                => AppData.ProjectData(od).Table<T>(od);

        public FS.FilePath Table<T>(ProjectId id)
            where T : struct
                => table<T>(id);

        public DbTargets Projects(string scope)
            => Projects().Targets(scope);

        public DbTargets Project(ProjectId od)
            => Projects().Targets(od);

        public DbTargets ProjectData(ProjectId id)
            => AppData.ProjectData(id);

        public DbTargets CgTargets(CgTarget dst)
            => AppData.CgProjects.Targets($"codegen/{Symbols.format(dst)}/src");

        public DbTargets CgTargets(CgTarget dst, string scope)
            => CgTargets(dst).Targets(scope);

        public DbTargets Targets(string scope)
            => Targets().Targets(scope);

        public DbSources Sources(string scope)
            => AppData.ProjectDb.Sources("sources").Sources(scope);

        public DbTargets Logs()
            => Targets("logs");

        public DbTargets Logs(string scope)
            => Targets($"logs/{scope}");

        public DbTargets RuntimeLogs()
            => Logs("runtime");

        public DbTargets ApiTargets()
            => AppData.ApiTargets;

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

        public FileCatalog Files(IProjectWs ws)
            => FileCatalog.load(ws);

        public FileCatalog Files(ProjectId project)
            => FileCatalog.load(project);

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