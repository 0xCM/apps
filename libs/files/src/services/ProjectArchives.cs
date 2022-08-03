//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using EN = SettingNames;

    public class ProjectArchives
    {
        public static ProjectArchives load()
            => load(ConfigSets.app());

        public static ProjectArchives load(SettingLookup src)
            => new ProjectArchives(src);

        readonly SettingLookup Data;

        internal ProjectArchives(SettingLookup src)
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