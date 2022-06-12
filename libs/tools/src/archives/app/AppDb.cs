//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = ArchiveNames;
    using T = ApiGranules;

    public class AppDb : IAppDb
    {
        WsArchives Archives;

        public AppDb()
        {
            Archives = AppData.WsPaths;
        }

        EnvData IEnvProvider.Env
            => AppData.AppEnv;

        public IDbTargets DbTargets()
            => new DbTargets(Archives.Path(S.DbTargets).Location);

        public FS.FilePath DbTable<T>(string scope)
            where T : struct
                => DbTargets(scope).Table<T>();

        public FS.FilePath DbTable<T>(string scope, string prefix)
            where T : struct
                => DbTargets(scope).Table<T>(prefix);

        public IDbSources DbSources()
            => new DbSources(Archives.Path(S.DbSources).Location);

        public IDbSources ProjectSrc()
            => new DbSources(Archives.Path(S.ProjectSrc).Location);

        public IDbSources Control()
            => new DbSources(Archives.Path(S.Control).Location);

        public IDbSources EnvConfig()
            => new DbSources(Archives.Path(S.EnvConfig).Location);

        public IDbTargets ProjectEtl(ProjectId project)
            => new DbTargets(Archives.Path(S.ProjectEtl).Location, project.Format());

        public FS.FilePath EtlTable<T>(ProjectId project)
            where T : struct
                => ProjectEtl(project).Table<T>(project);

        public FS.FilePath DbSource<T>(string scope)
            where T : struct
                => DbSources(scope).Table<T>();

        public IDbSources DbSources(string scope)
            => DbSources().Sources(scope);

        public IDbTargets DbTargets(string scope)
            => DbTargets().Targets(scope);

        public FS.FilePath DbSource(string name, FileKind kind)
            => DbSources().Path(name, kind);

        public FS.FilePath DbDource(string scope, string name, FileKind kind)
            => DbSources(scope).Path(name, kind);

        public IDbTargets Logs()
            => DbTargets("logs");

        public IDbTargets Logs(string scope)
            => DbTargets($"logs/{scope}");

        public IDbTargets RuntimeLogs()
            => Logs("runtime");

        public IDbTargets ApiTargets()
            => DbTargets().Targets("api");

        public IDbTargets ApiTargets(string scope)
            => DbTargets($"api/{scope}");

        public IDbTargets EtlTargets(ProjectId id, string scope)
            => ProjectEtl(id).Targets(scope);

        public IDbTargets AsmCsv(ProjectId id)
            => EtlTargets(id, T.asmcsv);

        public IDbTargets ObjHex(ProjectId id)
            => EtlTargets(id, T.objhex);

        public IDbTargets XedDisasm(ProjectId id)
            => EtlTargets(id, T.xeddisasm);

        public IDbTargets AsmSrc(ProjectId id)
            => EtlTargets(id, T.asmsrc);

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