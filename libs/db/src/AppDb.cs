//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = DbNames;
    using T = ApiGranules;
    using static Settings;

    using static core;

    public class AppDb : IAppDb
    {
        public static ref readonly AppDb Service => ref Instance;

        static Settings settings(FS.FilePath src)
        {
            var dst = Settings.Empty;
            try
            {
                dst = Settings.load(src);
            }
            catch(Exception e)
            {
                term.error(e);
            }
            return dst;
        }

        static FS.FilePath SettingsPath(Assembly src, FileKind kind)
            => FS.path(src.Location).FolderPath + FS.file(string.Format("{0}.settings", src.GetSimpleName()), kind.Ext());

        static WsArchives archives(Settings src)
            => new WsArchives(src);

        readonly WsArchives Archives;

        public readonly EnvData Env;

        // public static Setting<T> setting<T>(Setting src, Func<string,T> parser)
        //     => new Setting<T>(src.Name, parser(src.ValueText));

        public IDbTargets DbTargets()
            => new DbTargets(setting(Archives.Path(S.DbTargets), FS.dir));

        public FS.FilePath DbTable<T>(string scope)
            where T : struct
                => DbTargets(scope).Table<T>();

        public IDbSources DbSources()
            => new DbSources(setting(Archives.Path(S.DbSources), FS.dir));

        public IDbSources Control()
            => new DbSources(setting(Archives.Path(S.Control), FS.dir));

        public IDbSources Toolbase()
            => new DbSources(setting(Archives.Path(S.Toolbase), FS.dir));

        public IDbSources DevRoot()
            => new DbSources(setting(Archives.Path(S.DevRoot), FS.dir));

        public WsCatalog Catalog(IWsProject src)
            => WsCatalog.load(src);

        public IWsProjects DevProjects()
            => new WsProjects(DevRoot().Root, "dev");

        public IWsProjects DevProjects(string scope)
            => DevProjects().Projects(scope);

        public IDbTargets CgRoot()
            => new DbTargets(setting(Archives.Path(S.CgRoot), FS.dir));

        public IDbTargets Capture()
            => new DbTargets(setting(Archives.Path(S.DbCapture), FS.dir));

        public IDbSources EnvConfig()
            => new DbSources(setting(Archives.Path(S.EnvConfig), FS.dir));

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
            => new DbTargets(setting(Archives.Path(S.DbProjects),FS.dir), src.Format());

        public IDbTargets DbProjects(IWsProject src)
            => new DbTargets(setting(Archives.Path(S.DbProjects),FS.dir), src.Name);

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

        readonly ConstLookup<string, WsArchive> Lookup;

        AppDb()
        {
            var _settings = settings(SettingsPath(Assembly.GetEntryAssembly(), FileKind.Csv));
            Archives = archives(_settings);
            Env = EnvData.load();
            //Lookup = Archives.Select(x => (x.Name,x)).ToDictionary();

        }

        static AppDb Instance;

        // EnvData IEnvProvider.Env
        //     => Env;

        static AppDb()
        {
            Instance = new();
        }
    }
}