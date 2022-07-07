//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Settings;

    using Names = SettingNames;

    public class AppDb : IAppDb
    {
        public static AppDb Service => Instance;

        readonly WsArchives WsArchives;

        public IDbSources Archives()
            => new DbSources(setting(WsArchives.Path(Names.Archives), FS.dir));

        public IDbSources LlvmRoot()
            => new DbSources(setting(WsArchives.Path(Names.LlvmRoot), FS.dir));

        public IDbSources LlvmDist()
            => new DbSources(setting(WsArchives.Path(Names.LlvmDist), FS.dir));

        public IDbTargets DbOut()
            => new DbTargets(setting(WsArchives.Path(Names.DbTargets), FS.dir));

        public EnvVars<string> LoadEnv(string name)
            => AsciLines.env(WsArchives.EnvPath(name));

        public IDbTargets DbOut(string scope)
            => DbOut().Targets(scope);

        public IDbTargets Apps()
            => DbRoot().Targets("apps");

        public IDbTargets App(PartId part)
            => Apps().Targets(part.Format());

        public IDbTargets App()
            => Apps().Targets(ExecutingPart.Id.Format());

        public IDbTargets App(string scope)
            => App().Targets(scope);

        public IDbTargets App(PartId part, string scope)
            => App(part).Targets(scope);

        public IDbSources DbIn()
            => new DbSources(setting(WsArchives.Path(Names.DbSources), FS.dir));

        public IDbSources DbCapture()
            => new DbSources(setting(WsArchives.Path(Names.DbCapture), FS.dir));

        public IDbSources DbIn(string scope)
            => DbIn().Sources(scope);

        public IDbTargets Logs()
            => DbOut("logs");

        public IDbSources DbRoot()
            => new DbSources(setting(WsArchives.Path(Names.DbRoot), FS.dir));

        public IDbTargets Logs(string scope)
            => DbOut($"logs/{scope}");

        public FS.FilePath DbTable<T>(string scope)
            where T : struct
                => DbOut(scope).Table<T>();

        public IDbSources Control()
            => new DbSources(setting(WsArchives.Path(Names.Control), FS.dir));

        public IDbSources Toolbase()
            => new DbSources(setting(WsArchives.Path(Names.Toolbase), FS.dir));

        public IDbSources DevRoot()
            => new DbSources(setting(WsArchives.Path(Names.DevRoot), FS.dir));

        public IWsProjects DevProjects()
            => WsProjects.load(DevRoot());

        public IWsProjects DevProject(string name)
            => new WsProjects(DevProjects().Sources(name).Root);

        public IDbTargets CgRoot()
            => new DbTargets(setting(WsArchives.Path(Names.CgRoot), FS.dir));

        public IDbTargets Capture()
            => new DbTargets(setting(WsArchives.Path(Names.DbCapture), FS.dir));

        public IDbSources EnvConfig()
            => new DbSources(setting(WsArchives.Path(Names.EnvConfig), FS.dir));

        public IWsProject LlvmModel(ProjectId src)
            => WsProject.load(DevProject("llvm.models"), src);

        public IDbTargets DbProjects(ProjectId src)
            => new DbTargets(setting(WsArchives.Path(Names.DbProjects),FS.dir), src.Format());

        public IDbTargets DbProjects(IWsProject src)
        {
            var path = WsArchives.Path(Names.DbProjects);
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

        AppDb()
        {
            WsArchives = WsArchives.load();
        }

        static AppDb Instance;

        static AppDb()
        {
            Instance = new();
        }
    }
}