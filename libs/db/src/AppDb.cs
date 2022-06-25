//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Settings;

    using EN = EnvNames;
    using T = ApiGranules;

    public class AppDb : IAppDb
    {
        public static ref readonly AppDb Service => ref Instance;

        readonly WsArchives Archives;

        public IDbSources LlvmRoot()
            => new DbSources(setting(Archives.Path(EN.LlvmRoot), FS.dir));

        public IDbSources LlvmDist()
            => new DbSources(setting(Archives.Path(EN.LlvmDist), FS.dir));

        public IDbTargets DbOut()
            => new DbTargets(setting(Archives.Path(EN.DbTargets), FS.dir));

        public EnvVars<string> LoadEnv(string name)
            => AsciLines.vars(Archives.EnvPath(name), Chars.Eq);

        public IDbTargets DbOut(string scope)
            => DbOut().Targets(scope);

        public IDbSources DbIn()
            => new DbSources(setting(Archives.Path(EN.DbSources), FS.dir));

        public IDbSources DbCapture()
            => new DbSources(setting(Archives.Path(EN.DbCapture), FS.dir));

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
        {
            var path = Archives.Path(EN.DbProjects);
            term.inform(Events.status(GetType(), $"Loading {src.Project} from {path}"));
            var home = setting(path, FS.dir);
            return new DbTargets(home, src.Name);
        }

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

        AppDb()
        {
            Archives = WsArchives.load();
        }

        static AppDb Instance;

        static AppDb()
        {
            Instance = new();
        }
    }
}