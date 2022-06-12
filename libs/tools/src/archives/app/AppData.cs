//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppData
    {
        public static ref readonly EnvData AppEnv => ref Instance._AppEnv;

        /// <summary>
        /// $(ZDev)/codegen
        /// </summary>
        public static ref readonly DbTargets CgProjects => ref Instance._CgProjects;

        public static ref readonly DbSources ToolBase => ref Instance._Toolbase;

        /// <summary>
        /// Settings read from a file collocated with the entry assembly
        /// </summary>
        public static ref readonly Settings GlobalSettings => ref Instance._GlobalSettings;

        public static ref readonly StorePaths StorePaths => ref Instance._StorePaths;

        [MethodImpl(Inline)]
        public static AppData get() => Instance;

        [MethodImpl(Inline)]
        public bool PllExec() => _PllExec;

        bool _PllExec;

        EnvData _AppEnv;

        DbTargets _CgProjects;

        DbSources _Toolbase;

        Settings _GlobalSettings;

        StorePaths _StorePaths;

        static Settings settings(FS.FilePath src)
        {
            var dst = Settings.Empty;
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

        AppData()
        {
        }

        static AppData()
        {
            var control = Assembly.GetEntryAssembly();
            var env = EnvData.load();
            var dst = new AppData();
            var path = FS.path(control.Location).FolderPath + FS.file(string.Format("{0}.settings", control.GetSimpleName()), FS.Csv);
            var _settings = settings(path);
            dst._GlobalSettings = _settings;
            dst._StorePaths = Z0.StorePaths.load(_settings);
            dst._AppEnv = env;
            dst._PllExec = true;
            dst._CgProjects = new DbTargets(env.ZDev,"codegen");
            dst._Toolbase = new DbSources(env.Toolbase);
            Instance = dst;
        }

        static AppData Instance;
    }
}