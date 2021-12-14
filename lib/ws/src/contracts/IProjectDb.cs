//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IProjectDb : IProjectWs
    {
        ProjectId IProjectWs.Project
            => "db";

        FS.FolderPath IProjectWs.Home()
            => Root;

        FS.FolderPath Api()
            => Home() + FS.folder("api");

        FS.FolderPath ProjectData()
            => Home() + FS.folder("projects");

        FS.FolderPath Sources()
            => Home() + FS.folder("sources");

        FS.FolderPath Sources(string scope)
            => Sources() + FS.folder(scope);

        FS.FilePath Source(string id, FS.FileExt ext)
            => Sources() + FS.file(id,ext);

        FS.Files SourcePaths(string scope)
            => Sources(scope).AllFiles;

        FS.FilePath Source(string scope, string id, FS.FileExt ext)
            => Sources(scope) + FS.file(id, ext);
    }
}