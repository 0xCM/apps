//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppData
    {
        public static ref readonly EnvData AppEnv => ref Instance._AppEnv;

        public static ref readonly IDbSources ToolBase => ref Instance._Toolbase;

        public static ref readonly Settings GlobalSettings => ref Instance._GlobalSettings;

        public static ref readonly WsArchives WsPaths => ref Instance._WsPaths;

        [MethodImpl(Inline)]
        public static AppData get() => Instance;

        [MethodImpl(Inline)]
        public bool PllExec() => _PllExec;

        bool _PllExec;

        EnvData _AppEnv;

        IDbSources _Toolbase;

        Settings _GlobalSettings;

        WsArchives _WsPaths;

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
            var _settings = settings(control.SettingsPath(FileKind.Csv));
            dst._GlobalSettings = _settings;
            dst._WsPaths = WsArchives.load(_settings);
            dst._AppEnv = env;
            dst._PllExec = true;
            dst._Toolbase = new DbSources(env.Toolbase);
            Instance = dst;
        }

        static AppData Instance;
    }

    partial class XTend
    {
        public static FS.FilePath SettingsPath(this Assembly src, FileKind kind)
            => FS.path(src.Location).FolderPath + FS.file(string.Format("{0}.settings", src.GetSimpleName()), kind.Ext());
    }
}