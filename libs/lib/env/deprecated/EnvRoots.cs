//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    partial interface IEnvPaths
    {
        ICilPaths CilPaths
            => new CilPaths(Env);

        FS.FolderPath ProcessContextRoot()
            => Env.CacheRoot + FS.folder(context);

        FS.FolderPath PackageRoot()
            => Env.Packages;

        FS.FolderPath JobRoot()
            => Env.Db + FS.folder(jobs);

        FS.FolderPath IndexRoot()
            => Env.Db + FS.folder(tables) + FS.folder(indices);

        FS.FolderPath AppLogRoot()
            => Env.Db + FS.folder(logs) + FS.folder(apps) + FS.folder(AppName);

        FS.FolderPath CmdLogRoot()
            => Env.Db + FS.folder(logs) + FS.folder(commands);

        FS.FolderPath CilDataRoot()
            => Env.Db + FS.folder(capture) + FS.folder(cildata);
    }
}