//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    partial interface IEnvPaths
    {
        FS.FolderPath DevRoot(string id)
            => Env.DevRoot + FS.folder(id);

        FS.FolderPath PartSrcDir(string id)
            => DevRoot(z0) + FS.folder(src) + FS.folder(id);

        FS.FolderPath PartSrcDir(PartId id)
            => DevRoot(z0) + FS.folder(src) + FS.folder(id.Format());

        FS.FilePath PartSrcFile(PartId id, FS.FileName name)
            => PartSrcDir(id) + FS.folder(src) + name;
    }
}