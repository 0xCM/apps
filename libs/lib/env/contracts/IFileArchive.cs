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

        Deferred<FS.FilePath> Files(FileKind k1, FileKind k2, FileKind k3, bool recurse = true)
            => Root.EnumerateFiles(recurse).Where(path => path.Is(k1) || path.Is(k2) || path.Is(k3));

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
    }
}