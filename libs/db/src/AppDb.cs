//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = DbNames;
    using T = ApiGranules;

    public class AppDb : IAppDb
    {
        public static ref readonly AppDb Service => ref Instance;

        readonly WsArchives Archives;

        public readonly EnvData Env;

        public IDbTargets DbTargets()
            => new DbTargets(Archives.Path(S.DbTargets).Location);

        public FS.FilePath DbTable<T>(string scope)
            where T : struct
                => DbTargets(scope).Table<T>();

        public IDbSources DbSources()
            => new DbSources(Archives.Path(S.DbSources).Location);

        public IDbSources Control()
            => new DbSources(Archives.Path(S.Control).Location);

        public IDbSources Toolbase()
            => new DbSources(Archives.Path(S.Toolbase).Location);

        public IDbSources DevRoot()
            => new DbSources(Archives.Path(S.DevRoot).Location);

        public WsCatalog Catalog(IWsProject src)
            => WsCatalog.load(src);

        public IWsProjects DevProjects()
            => new WsProjects(DevRoot().Root, "dev");

        public IWsProjects DevProjects(string scope)
            => DevProjects().Projects(scope);

        public IDbTargets CgRoot()
            => new DbTargets(Archives.Path(S.CgRoot).Location);

        public IDbTargets Capture()
            => new DbTargets(Archives.Path(S.DbCapture).Location);

        public IDbSources EnvConfig()
            => new DbSources(Archives.Path(S.EnvConfig).Location);

        public IWsProject DevProject(ProjectId src)
            => new WsProject(DevProjects().Sources(src).Root + FS.folder(src.Format()), src);

        public IWsProject DevProject(string scope, ProjectId src)
            => new WsProject(DevProjects(scope).Sources(src).Root + FS.folder(src.Format()), src);

        public IWsProject LlvmModel(ProjectId src)
            => DevProject("llvm.models", src);

        public WsCatalog DevCatalog(ProjectId src)
            => Catalog(DevProject(src));

        public WsCatalog DevCatalog(string scope, ProjectId src)
            => Catalog(DevProject(scope, src));

        public IDbTargets DbProjects(ProjectId src)
            => new DbTargets(Archives.Path(S.DbProjects).Location, src.Format());

        public IDbTargets DbProjects(IWsProject src)
            => new DbTargets(Archives.Path(S.DbProjects).Location, src.Name);

        public IDbTargets CgStage()
            => DbTargets("cgstage");

        public IDbTargets CgStage(string scope)
            => DbTargets("cgstage").Targets(scope);

        public FS.FilePath ProjectTable<T>(ProjectId project)
            where T : struct
                => DbProjects(project).Table<T>(project);

        public IDbSources DbSources(string scope)
            => DbSources().Sources(scope);

        public IDbTargets DbTargets(string scope)
            => DbTargets().Targets(scope);

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
            => DbProjects(id).Targets(scope);

        public IDbTargets AsmCsv(ProjectId id)
            => EtlTargets(id, T.asmcsv);

        public IDbTargets ObjHex(ProjectId id)
            => EtlTargets(id, T.objhex);

        public IDbTargets XedDisasm(ProjectId id)
            => EtlTargets(id, T.xeddisasm);

        public IDbTargets AsmSrc(ProjectId id)
            => EtlTargets(id, T.asmsrc);

        AppDb()
        {
            Archives = WsArchives.load();
            Env = EnvData.load();
        }

        static AppDb Instance;

        EnvData IEnvProvider.Env
            => Env;

        static AppDb()
        {
            Instance = new();
        }
    }
}