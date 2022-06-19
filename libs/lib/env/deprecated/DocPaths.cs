//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    partial interface IEnvPaths
    {
        FS.FilePath List(string name, FS.FileExt ext)
            => Env.Db + FS.folder(lists) + FS.file(name, ext);

        FS.FilePath Doc(string name, FS.FileExt ext)
            => Env.Db + FS.folder(docs) + FS.file(name, ext);
    }
}