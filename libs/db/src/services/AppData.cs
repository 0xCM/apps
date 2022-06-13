//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppData
    {
        public static ref readonly EnvData AppEnv => ref Instance._AppEnv;

        public static ref readonly Settings Settings => ref Instance._Settings;

        public static ref readonly AppDb AppDb => ref Instance._AppDb;

        [MethodImpl(Inline)]
        public static AppData get() => Instance;

        [MethodImpl(Inline)]
        public bool PllExec() => _PllExec;

        bool _PllExec;

        EnvData _AppEnv;

        Settings _Settings;

        AppDb _AppDb;
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
            var settings = AppData.settings(control.SettingsPath(FileKind.Csv));
            dst._Settings = settings;
            dst._AppEnv = env;
            dst._PllExec = true;
            dst._AppDb = new AppDb(WsArchives.load(settings));
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