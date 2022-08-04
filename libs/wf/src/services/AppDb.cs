//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Settings;

    using Names = SettingNames;

    public class AppDb : IAppDb
    {
        public static readonly Timestamp Ts = Algs.timestamp();

        public static AppDb Service => Instance;

        readonly ProjectArchives WsArchives;

        public static FS.FileName hostfile(ApiHostUri host, FileKind kind)
            => FS.file(string.Format("{0}.{1}", host.Part.Format(), host.HostName), kind);

        public IDbSources Settings()
            => DbRoot().Sources("settings");

        public FS.FilePath Settings(string name, FileKind kind)
            => Settings().Path(name,kind);

        public IDbSources Jobs()
            => DbRoot().Sources("jobs");

        public FS.FilePath Settings<T>()
            where T : struct
                => Settings().Table<T>();

        public FS.FilePath SettingsPath(string name, FileKind kind)
            => Settings().Path(name,kind);

        public FS.FilePath SettingsPath<S>(FileKind kind)
            => Settings().Path(Z0.Settings.name<S>(), kind);

        public IDbArchive DbArchive(FS.FolderPath home) 
            => new DbArchive(home);

        public IDbArchive DbArchive(IRootedArchive home) 
            => new DbArchive(home);

        public IDbArchive Archives()
            => new DbArchive(setting(WsArchives.Path(Names.Archives), FS.dir));

        public IDbArchive Archive(string name)
            => new DbArchive(Archives().Sources(name).Root);

        public IDbSources LlvmRoot()
            => new DbArchive(setting(WsArchives.Path(Names.LlvmRoot), FS.dir));

        public IDbSources LlvmDist()
            => new DbArchive(setting(WsArchives.Path(Names.LlvmDist), FS.dir));

        public IDbTargets DbOut()
            => new DbTargets(setting(WsArchives.Path(Names.DbTargets), FS.dir));

        public IDbSources Repos()
            => new DbArchive(setting(WsArchives.Path(Names.Repos), FS.dir));

        public IDbArchive Symbols()
            => new DbArchive(setting(WsArchives.Path(Names.Repos), FS.dir));

        public IDbArchive Env()
            => new DbArchive(DbRoot().Targets("env"));

        public IDbSources Repos(string scope)
            => Repos().Sources(scope);

        public EnvVars<string> LoadEnv(string name)
            => Z0.Settings.env(WsArchives.EnvPath(name));

        public IDbTargets DbOut(string scope)
            => DbOut().Targets(scope);

        public IDbTargets Apps()
            => DbRoot().Targets("apps");

        public IDbTargets Commands()
            => DbRoot().Targets("commands");

        public IDbTargets Commands(string scope)
            => Commands().Targets(scope);

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
            => new DbTargets(setting(WsArchives.Path(Names.Logs), FS.dir));

        public IDbSources DbRoot()
            => new DbSources(setting(WsArchives.Path(Names.DbRoot), FS.dir));

        public IDbTargets Logs(string scope)
            => Logs().Targets(scope);

        public IDbArchive Control()
            => new DbArchive(setting(WsArchives.Path(Names.Control), FS.dir));

        public IDbArchive Control(string scope)
            => new DbArchive(Control().Sources(scope));

        public IDbSources Tools()
            => new DbSources(setting(WsArchives.Path(Names.Tools), FS.dir));        

        public IDbSources Tools(string scope)
            => Tools().Sources(scope);

        public IDbArchive Views()
            => new DbArchive(setting(WsArchives.Path(Names.Views), FS.dir));

        public IDbArchive Toolsets()
            => Views(toolsets);

        public IDbArchive Toolset(string name)
            => new DbArchive(Views(toolsets).Sources(name));

        public IDbArchive Views(string scope)
            => new DbArchive(Views().Sources(scope));

        public IDbArchive Toolbase()
            => Toolset(toolbase);

        public IDbArchive Toolbase(string scope)
            => new DbArchive(Toolbase().Sources(scope));
            
        public IDbSources Dev()
            => new DbSources(setting(WsArchives.Path(Names.DevRoot), FS.dir));

        public IDbSources Dev(string scope)
            => Dev().Sources(scope);

        public IDbTargets CgRoot()
            => new DbTargets(setting(WsArchives.Path(Names.CgRoot), FS.dir));

        public IDbTargets Capture()
            => new DbTargets(setting(WsArchives.Path(Names.DbCapture), FS.dir));

        public IDbSources EnvConfig()
            => new DbSources(setting(WsArchives.Path(Names.EnvConfig), FS.dir));

        public IProjectWorkspace EtlSource(ProjectId src)
            => ProjectWorkspace.load(Dev($"llvm.models/{src}"), src);

        public IDbTargets EtlTargets(ProjectId project)
            => DbOut().Targets("projects").Targets(project.Format());

        public FS.FilePath EtlTable<T>(ProjectId project)
            where T : struct
                => EtlTargets(project).Table<T>(project.Format());

        public FS.FilePath EtlTable(ProjectId project, string name)
            => EtlTargets(project).Path($"{project}.{name}", FileKind.Csv);

        public IDbTargets CgStage()
            => DbOut("cgstage");

        public IDbTargets CgStage(string scope)
            => DbOut("cgstage").Targets(scope);

        public IDbTargets ApiTargets()
            => DbOut().Targets("api");

        public IDbTargets ApiTargets(string scope)
            => DbOut($"api/{scope}");

        AppDb()
        {
            WsArchives = ProjectArchives.load();
        }

        static AppDb Instance;

        static AppDb()
        {
            Instance = new();
        }
    }
}