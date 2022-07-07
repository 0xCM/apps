//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    /// <summary>
    /// Characterizes a file system repository
    /// </summary>
    [Free]
    public interface IFileArchive : ITextual, ITablePaths
    {
        FS.FolderPath Root {get;}

        FS.FolderPath Subdir(string scope)
            => Root + FS.folder(scope);

        FS.FilePath Path(string id, FS.FileExt ext)
            => Root + FS.file(id,ext);

        string ITextual.Format()
            => Root.Format();

        FS.Files Files()
            => Root.EnumerateFiles(true).Array();

        FS.FolderPath Datasets()
            => Root + FS.folder(datasets);

        FS.FolderPath Datasets(string scope)
            => Datasets() + FS.folder(scope);

        FS.FilePath TablePath<T>(string scope)
            where T : struct
                => Subdir(scope) + TableFile<T>();

        FS.FilePath TablePath<T>(string scope, string suffix)
            where T : struct
                => Subdir(scope) + TableFile<T>(suffix);

        FS.FilePath TablePath<T>(string scope, string prefix, string suffix)
            where T : struct
                => Subdir(scope) + TableFile<T>(prefix,suffix);
    }
}