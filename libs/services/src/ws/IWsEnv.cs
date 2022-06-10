//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;

    public interface IWsEnv
    {
        EnvData Env {get;}

        DbSources EnvCache()
            => new DbSources(Env.CacheRoot);

        DbSources EnvLibs()
            => new DbSources(Env.Libs);

        DbSources EnvPackages()
            => new DbSources(Env.Packages);

        FS.FolderPath EnvCmd()
            => new DbSources(Env.Control, cmd);
    }
}