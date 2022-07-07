//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using EN = SettingNames;

    public class WsArchives
    {
        public static WsArchives load()
            => load(ConfigSets.app());

        public static WsArchives load(Settings src)
            => new WsArchives(src);

        readonly Settings Data;

        internal WsArchives(Settings src)
        {
            Data = src;
        }

        public FS.FolderPath EnvSource()
            => Settings.setting(Path(EN.EnvConfig), FS.dir);

        public FS.FilePath EnvPath(string name)
            => EnvSource() + FS.file(name, FileKind.Env);

        public Setting Path(string name)
        {
            var dst = Setting.Empty;
            var result = Data.Find(name, out dst);
            if(result)
                return dst;
            else
                return Setting.Empty;
        }

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();
    }
}