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
        public static readonly Timestamp Ts = core.now();

        public static ReadOnlySeq<IApiPack> apipacks()
        {
            var src = Service.Capture().Root.SubDirs(false);
            var dst = Lists.list<IApiPack>();
            var counter = 0u;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var source = ref src[i];
                if(ApiPack.parse(source, out ApiPack pack))
                {
                    dst.Add(pack);
                    counter++;
                }
            }

            return slice(@readonly(dst.Seal()),0,counter).ToArray();
        }

        public static IApiPack apipack(Timestamp ts, string label = EmptyString)
            => new ApiPack(Service.Capture().Targets(ts.Format()).Root, ts, label);

        public static IApiPack apipack(string label = EmptyString)
            => new ApiPack(Service.Capture().Targets(AppDb.Ts.Format()).Root, AppDb.Ts, label);

        public static AppDb Service => Instance;

        readonly WsArchives WsArchives;

        public IDbSources Configs()
            => new DbSources(DbRoot().Root + FS.folder("settings"));

        public IDbSources Configs(string scope)
            => Configs().Sources(scope);

        public FS.FilePath ConfigPath<S>()
            => Configs().Path(Z0.Settings.name<S>(), FileKind.Config);

        public FS.FilePath ConfigPath<S>(string prefix)
            => Configs().Path($"{prefix}.{Z0.Settings.name<S>()}", FileKind.Config);

        public IDbSources Archives()
            => new DbSources(setting(WsArchives.Path(Names.Archives), FS.dir));

        public IDbSources LlvmRoot()
            => new DbSources(setting(WsArchives.Path(Names.LlvmRoot), FS.dir));

        public IDbSources LlvmDist()
            => new DbSources(setting(WsArchives.Path(Names.LlvmDist), FS.dir));

        public IDbTargets DbOut()
            => new DbTargets(setting(WsArchives.Path(Names.DbTargets), FS.dir));

        public IDbSources Repos()
            => new DbSources(setting(WsArchives.Path(Names.Repos), FS.dir));


        public IDbSources Repos(string scope)
            => Repos().Sources(scope);

        public IDbSources Repo(string scope, string name)
            => Repos(scope).Sources(name);

        public EnvVars<string> LoadEnv(string name)
            => AsciLines.env(WsArchives.EnvPath(name));

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

        public IWsProject Project(ProjectId src)
            => WsProject.load(DevProject($"llvm.models/{src}"), src);

        public IDbTargets BuildTargets(ProjectId src)
            => new DbTargets(Project(src).Home(), ".out");

        public IDbTargets EtlTargets(ProjectId src)
            => new DbTargets(DbOut($"projects/{src}").Root);

        public FS.FilePath EtlTable<T>(ProjectId project)
            where T : struct
                => EtlTargets(project).Table<T>();

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
            WsArchives = WsArchives.load();
        }

        static AppDb Instance;

        static AppDb()
        {
            Instance = new();
        }
    }
}