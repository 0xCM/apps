//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a file system repository
    /// </summary>
    [Free]
    public interface IFileArchive : ITextual, ITablePaths
    {
        FS.FolderPath Root {get;}

        FS.FolderPath Subdir(string scope)
            => Root + FS.folder(scope);

        string ITextual.Format()
            => Root.Format();

        FS.FilePath TablePath<T>(string scope)
            where T : struct
                => Subdir(scope) + TableFile<T>();
    }
}