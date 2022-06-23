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

        ToolWs _ToolWs;

        static FS.FilePath SettingsPath(Assembly src, FileKind kind)
            => FS.path(src.Location).FolderPath + FS.file("app.settings", kind.Ext());

        readonly WsArchives Archives;

        public ref readonly Settings Settings()
            => ref _Settings;

        public FS.FilePath EnvPath(string name)
            => Env().Path(FS.file(name, FileKind.Env));

        public IDbTargets DbOut()
            => new DbTargets(setting(Archives.Path(EN.DbTargets), FS.dir));

        public EnvVars<string> LoadEnv(string name)
            => vars(EnvPath(name), Chars.Eq);

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

        Settings _Settings;

        AppDb()
        {
            _Settings = Z0.Settings.load(SettingsPath(Assembly.GetEntryAssembly(), FileKind.Csv));
            Archives = WsArchives.load(_Settings);
            _ToolWs = new ToolWs(FS.dir(Archives.Path(EN.Toolbase).ValueText));
        }

        static AppDb Instance;

        static AppDb()
        {
            Instance = new();
        }

        public static Settings config(FS.FilePath src, char sep = Chars.Colon)
        {
            var dst = list<Setting>();
            var line = AsciLine.Empty;
            using var reader = src.AsciLineReader();
            while(reader.Next(out line))
            {
                var content = line.Codes;
                var length = content.Length;
                if(length != 0)
                {
                    if(SQ.hash(first(content)))
                        continue;

                    var i = SQ.index(content, sep);
                    if(i > 0)
                    {
                        var name = text.format(SQ.left(content,i));
                        var value = text.format(SQ.right(content,i));
                        dst.Add(new Setting(name,value));
                    }
                }
            }
            return new Settings(dst.ToArray());
        }

        public static EnvVars<string> vars(FS.FilePath src, char sep)
        {
            var k = z16;
            var dst = list<EnvVar<string>>();
            var line = AsciLine.Empty;
            var buffer = alloc<char>(1024*4);
            using var reader = src.AsciLineReader();
            while(reader.Next(out line))
            {
                var content = line.Codes;
                var i = SQ.index(content, sep);
                if(i == NotFound)
                    continue;

                var _name = text.format(SQ.left(content,i), buffer);
                var _value = text.format(SQ.right(content,i), buffer);
                dst.Add(new (_name, _value));
            }
            return dst.ToArray().Sort();
        }
    }
}