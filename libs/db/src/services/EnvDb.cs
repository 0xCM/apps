//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static ApiGranules;

    public class EnvDb
    {
        static AppDb AppDb => AppDb.Service;

        public static EnvVars<string> vars(string name = null)
            => AppDb.LoadEnv(text.ifempty(name, Environment.MachineName.ToLower()));

        public static Settings config(FS.FolderPath src)
            => AsciLines.config(src + FS.file("tools", FS.ext("env")));

        public static ToolEnv tools(Settings src)
            => new ToolEnv(src);
    }
}