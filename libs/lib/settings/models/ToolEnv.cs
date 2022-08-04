//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ToolEnv
    {
        readonly SettingLookup Data;

        readonly Dictionary<string,Setting> Lookup;

        public static ToolEnv load(SettingLookup src)
            => new ToolEnv(src);

        public ToolEnv(SettingLookup src)
        {
            Data = src;
            Lookup = new();
            foreach(var setting in src)
                Lookup[setting.Name] = setting;
        }

        public FolderPaths HeaderIncludes()
        {
            if(Lookup.TryGetValue("INCLUDE", out var setting))
                if(FS.parse(setting.Value.ToString(), out FolderPaths paths))
                    return paths;
            return FolderPaths.Empty;
        }

        public FolderPaths LibIncludes()
        {
            if(Lookup.TryGetValue("LIB", out var setting))
                if(FS.parse(setting.Value.ToString(), out FolderPaths paths))
                    return paths;
            return FolderPaths.Empty;
        }
    }
}