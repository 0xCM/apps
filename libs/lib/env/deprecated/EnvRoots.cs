//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    partial interface IEnvPaths
    {
        FS.FolderPath AppLogRoot()
            => Env.Db + FS.folder(logs) + FS.folder(apps) + FS.folder(AppName);

        FS.FolderPath CmdLogRoot()
            => Env.Db + FS.folder(logs) + FS.folder(commands);
    }
}