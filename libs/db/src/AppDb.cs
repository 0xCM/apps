//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Settings;

    using EN = EnvNames;
    using T = ApiGranules;

    public class AppDb : IAppDb
    {
        public static ref readonly AppDb Service => ref Instance;

        static Settings settings(FS.FilePath src)
        {
            var dst = Z0.Settings.Empty;
            try
            {
                dst = Z0.Settings.load(src);
            }
            catch(Exception e)
            {
                term.error(e);
            }
            return dst;
        }

        static FS.FilePath SettingsPath(Assembly src, FileKind kind)
            => FS.path(src.Location).FolderPath + FS.file("app.settings", kind.Ext());

        static WsArchives archives(Settings src)
            => new WsArchives(src);

        readonly WsArchives Archives;

        public ref readonly Settings Settings()
            => ref _Settings;

        public IDbTargets DbOut()
            => new DbTargets(setting(Archives.Path(EN.DbTargets), FS.dir));

        public IDbTargets DbOut(string scope)
            => DbOut().Targets(scope);

        public IDbSources DbIn()
            => new DbSources(setting(Archives.Path(EN.DbSources), FS.dir));

        public IDbSources DbCapture()
            => new DbSources(setting(Archives.Path(EN.DbCapture), FS.dir));

        public IDbSources Env()
            => new DbSources(setting(Archives.Path(EN.EnvConfig), FS.dir));

        public IDbSources DbIn(string scope)
            => DbIn().Sources(scope);

        public IDbTargets Logs()
            => DbOut("logs");

        public IDbTargets Logs(string scope)
            => DbOut($"logs/{scope}");

        public FS.FilePath DbTable<T>(string scope)
            where T : struct
                => DbOut(scope).Table<T>();

        public IDbSources Control()
            => new DbSources(setting(Archives.Path(EN.Control), FS.dir));

        public IDbSources Toolbase()
            => new DbSources(setting(Archives.Path(EN.Toolbase), FS.dir));

        public IDbSources DevRoot()
            => new DbSources(setting(Archives.Path(EN.DevRoot), FS.dir));

        public WsCatalog Catalog(IWsProject src)
            => WsCatalog.load(src);

        public IWsProjects DevProjects()
            => new WsProjects(DevRoot().Root, "dev");

        public IWsProjects DevProjects(string scope)
            => DevProjects().Projects(scope);

        public IDbTargets CgRoot()
            => new DbTargets(setting(Archives.Path(EN.CgRoot), FS.dir));

        public IDbTargets Capture()
            => new DbTargets(setting(Archives.Path(EN.DbCapture), FS.dir));

        public IDbSources EnvConfig()
            => new DbSources(setting(Archives.Path(EN.EnvConfig), FS.dir));

        public IWsProject DevProject(ProjectId src)
            => new WsProject(DevProjects().Sources(src).Root, src);

        public IWsProject DevProject(string scope, ProjectId src)
            => new WsProject(DevProjects(scope).Root, src);

        public IWsProject LlvmModel(ProjectId src)
            => new WsProject(DevProjects("llvm.models"), src);


        public IDbTargets DbProjects(ProjectId src)
            => new DbTargets(setting(Archives.Path(EN.DbProjects),FS.dir), src.Format());

        public IDbTargets DbProjects(IWsProject src)
            => new DbTargets(setting(Archives.Path(EN.DbProjects),FS.dir), src.Name);

        public IDbTargets CgStage()
            => DbOut("cgstage");

        public IDbTargets CgStage(string scope)
            => DbOut("cgstage").Targets(scope);

        public FS.FilePath ProjectTable<T>(ProjectId project)
            where T : struct
                => DbProjects(project).Table<T>(project);

        public IDbTargets RuntimeLogs()
            => Logs("runtime");

        public IDbTargets ApiTargets()
            => DbOut().Targets("api");

        public IDbTargets ApiTargets(string scope)
            => DbOut($"api/{scope}");

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

        Settings _Settings;

        AppDb()
        {
            _Settings = settings(SettingsPath(Assembly.GetEntryAssembly(), FileKind.Csv));
            Archives = archives(_Settings);
        }

        static AppDb Instance;

        static AppDb()
        {
            Instance = new();
        }
    }
}