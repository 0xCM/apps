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

        FS.FolderPath IProjectWs.Logs()
            => Home() + FS.folder("logs");

        FS.FolderPath Api()
            => Home() + FS.folder("api");

        FS.FolderPath ProjectData()
            => Home() + FS.folder("projects");

        FS.FolderPath Sources()
            => Home() + FS.folder("sources");

        FS.FolderPath Sources(string scope)
            => Sources() + FS.folder(scope);

        FS.FilePath Source(string name, FS.FileExt ext)
            => Sources() + FS.file(name,ext);

        FS.Files SourcePaths(string scope)
            => Sources(scope).AllFiles;

        FS.FilePath Source(string scope, string name, FS.FileExt ext)
            => Sources(scope) + FS.file(name, ext);

        FS.FilePath ApiTablePath<T>()
            where T : struct
                => TablePath<T>("api");

        FS.FilePath ApiTablePath<T>(string scope)
            where T : struct
                => Api() + FS.folder(scope) + TableFile<T>();

        FS.FilePath ApiTablePath<T>(string scope, string suffix)
            where T : struct
                => Api() + FS.folder(scope) + TableFile<T>(suffix);

    }
}