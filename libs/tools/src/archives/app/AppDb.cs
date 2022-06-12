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

        public IDbTargets Targets()
            => new DbTargets(Archives.Path(S.Targets).Location);

        public IDbSources Sources()
            => new DbSources(Archives.Path(S.Sources).Location);

        public IDbSources Control()
            => new DbSources(Archives.Path(S.Control).Location);

        public IDbSources Sources(string scope)
            => Sources().Sources(scope);

        public FS.FilePath Table<T>(ProjectId id)
            where T : struct
                => ProjectData(id).Table<T>(id);

        public IDbTargets Projects(string scope)
            => Targets().Targets(scope);

        public IDbTargets ProjectTargets(ProjectId id)
            => Targets().Targets(id);

        public IDbTargets ProjectData(ProjectId id)
            => new DbTargets(Targets().Targets("projects"), id);

        public IDbTargets CodeGen()
            => new DbTargets(Archives.Path(S.CodeGen).Location);

        public IDbTargets CgTargets(CgTarget dst)
            => AppData.CgProjects.Targets($"codegen/{Symbols.format(dst)}/src");

        public IDbTargets CgTargets(CgTarget dst, string scope)
            => CgTargets(dst).Targets(scope);

        public IDbSources ProjectSources(ProjectId id)
            => Sources().Sources(id);

        public IDbTargets Targets(string scope)
            => Targets().Targets(scope);

        public IDbTargets Logs()
            => Targets("logs");

        public IDbTargets Logs(string scope)
            => Targets($"logs/{scope}");

        public IDbTargets RuntimeLogs()
            => Logs("runtime");

        public IDbTargets ApiTargets()
            => Targets().Targets("api");

        public IDbTargets ApiTargets(string scope)
            => Targets($"api/{scope}");

        public IDbTargets ProjectDb(ProjectId project, string scope)
            => new DbTargets(ProjectData(project), scope);

        public IDbTargets DbTargets(IProjectWs ws)
            => Targets($"projects/{ws.Project}");

        public IDbTargets DbTargets(ProjectId ws)
            => Targets($"projects/{ws}");

        public IDbTargets AsmTargets(ProjectId ws)
            => DbTargets(ws).Targets("asm.code");

        public IDbTargets HexTargets(ProjectId ws)
            => DbTargets(ws).Targets("obj.hex");

        public IDbTargets XedTargets(ProjectId ws)
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