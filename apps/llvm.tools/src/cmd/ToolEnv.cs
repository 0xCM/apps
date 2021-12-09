//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Collections.Generic;

    public class ToolEnv
    {
        public static ToolEnv load(Settings src)
            => new ToolEnv(src);

        readonly Settings Data;

        readonly Dictionary<string,Setting> Lookup;

        public ToolEnv(Settings src)
        {
            Data = src;
            Lookup = new();
            foreach(var setting in src)
                Lookup[setting.Name] = setting;
        }

        public FolderPaths HeaderIncludes()
        {
            if(Lookup.TryGetValue("INCLUDE", out var setting))
                if(FolderPaths.parse(setting.Value.ToString(), out FolderPaths paths))
                    return paths;
            return FolderPaths.Empty;
        }

        public FolderPaths LibIncludes()
        {
            if(Lookup.TryGetValue("LIB", out var setting))
                if(FolderPaths.parse(setting.Value.ToString(), out FolderPaths paths))
                    return paths;
            return FolderPaths.Empty;
        }
    }
}