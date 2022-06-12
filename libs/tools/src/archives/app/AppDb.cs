//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = ArchiveNames;

    public class AppDb : IAppDb
    {
        WsArchives Archives;

        public AppDb()
        {
            Archives = AppData.WsPaths;
        }

        public ref readonly EnvData Env
            => ref AppData.AppEnv;

        EnvData IEnvProvider.Env
            => AppData.AppEnv;

        public ITargetArchive Targets()
            => new DbTargets(Archives.Path(S.Targets).Location);

        public ISourceArchive Sources()
            => new DbSources(Archives.Path(S.Sources).Location);

        public ISourceArchive Control()
            => new DbSources(Archives.Path(S.Control).Location);

        public ISourceArchive Sources(string scope)
            => Sources().Sources(scope);

        public FS.FilePath Table<T>(ProjectId id)
            where T : struct
                => ProjectData(id).Table<T>(id);

        public ITargetArchive Projects(string scope)
            => Targets().Targets(scope);

        public ITargetArchive ProjectTargets(ProjectId id)
            => Targets().Targets(id);

        public ITargetArchive ProjectData(ProjectId id)
            => new DbTargets(Targets().Targets("projects"), id);

        public ITargetArchive CodeGen()
            => new DbTargets(Archives.Path(S.CodeGen).Location);

        public ITargetArchive CgTargets(CgTarget dst)
            => AppData.CgProjects.Targets($"codegen/{Symbols.format(dst)}/src");

        public ITargetArchive CgTargets(CgTarget dst, string scope)
            => CgTargets(dst).Targets(scope);

        public ISourceArchive ProjectSources(ProjectId id)
            => Sources().Sources(id);

        public ITargetArchive Targets(string scope)
            => Targets().Targets(scope);

        public ITargetArchive Logs()
            => Targets("logs");

        public ITargetArchive Logs(string scope)
            => Targets($"logs/{scope}");

        public ITargetArchive RuntimeLogs()
            => Logs("runtime");

        public ITargetArchive ApiTargets()
            => Targets().Targets("api");

        public ITargetArchive ApiTargets(string scope)
            => Targets($"api/{scope}");

        public ITargetArchive ProjectDb(ProjectId project, string scope)
            => new DbTargets(ProjectData(project), scope);

        public ITargetArchive DbTargets(IProjectWs ws)
            => Targets($"projects/{ws.Project}");

        public ITargetArchive DbTargets(ProjectId ws)
            => Targets($"projects/{ws}");

        public ITargetArchive AsmTargets(ProjectId ws)
            => DbTargets(ws).Targets("asm.code");

        public ITargetArchive HexTargets(ProjectId ws)
            => DbTargets(ws).Targets("obj.hex");

        public ITargetArchive XedTargets(ProjectId ws)
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