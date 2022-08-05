//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRootedArchive : IExistential, ILocatable<FS.FolderPath>
    {
        FS.FolderPath Root {get;}

        DbArchive DbFiles => Root;

        bool INullity.IsEmpty
            => Root.IsEmpty;

        bool INullity.IsNonEmpty
            => Root.IsNonEmpty;

        FS.FolderPath ILocatable<FS.FolderPath>.Location
            => Root;

        bool IExistential.Exists
            => Root.Exists;

        IDbTargets Logs()
            => Targets("logs");

        FS.FilePath Log(string name, FileKind kind)
            => Logs().Path(name,kind);

        IDbSources Sources()
            => DbFiles.Sources();

        IDbTargets Targets()
            => DbFiles.Targets();

        IDbSources Sources(string scope)
            => DbFiles.Sources(scope);

        IDbTargets Targets(string scope)
            => DbFiles.Targets(scope);

        FS.FilePath Table<T>()
            where T : struct
                => DbFiles.Table<T>();

        FS.FilePath Table<T>(ProjectId id)
            where T : struct
                => DbFiles.Table<T>(id);

        FS.FilePath PrefixedTable<T>(string prefix)
            where T : struct
                => DbFiles.PrefixedTable<T>(prefix);

        FS.Files Files()
            => DbFiles.Files(true);

        FS.Files Files(bool recurse)
            => DbFiles.Files(recurse);

        FS.Files Files(FS.FileExt ext)
            => DbFiles.Files(ext);

        FolderPaths Folders(bool recurse = false)
            => Root.Folders(recurse);

        FS.FolderPath Folder(string match)
            => Root.Folder(match);

        FS.Files Files(FileKind kind)
            => DbFiles.Files(kind, true);

        FS.Files Files(FileKind kind, bool recurse)
            => DbFiles.Files(kind, recurse);

        FS.Files Files(params FileKind[] kinds)
            => DbFiles.Files(true, kinds);

        FS.Files Files(string scope, params FileKind[] kinds)
            => DbFiles.Files(scope, true, kinds);

        FS.FileName File(string name, FileKind kind)
            => DbFiles.File(name, kind);

        FS.FilePath Path(string name, FileKind kind)
            => DbFiles.Path(name, kind);

        FS.FilePath Path(FS.FileName file)
            => DbFiles.Path(file);

        FS.FilePath Path(string @class, string name, FileKind kind)
            => DbFiles.Path(@class, name, kind);

        string IExpr.Format()
            => DbFiles.Format();

        Deferred<FS.FileUri> Enumerate()
            => from f in DbFiles.Enumerate(true) select f.ToUri();
    }
}