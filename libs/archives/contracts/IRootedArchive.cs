//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRootedArchive
    {
        FS.FolderPath Root {get;}

        DbFiles DbFiles => Root;

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

        FS.FilePath Table<T>(string prefix)
            where T : struct
                => DbFiles.Table<T>(prefix);

        FS.Files Files()
            => DbFiles.Files(true);

        FS.Files Files(FS.FileExt ext)
            => DbFiles.Files(ext);

        FS.Files Files(FileKind kind)
            => DbFiles.Files(kind, true);

        FS.FileName File(string name, FileKind kind)
            => DbFiles.File(name, kind);

        FS.FileName File(string @class, string name, FileKind kind)
            => DbFiles.File(@class, name, kind);

        FS.FilePath Path(string name, FileKind kind)
            => DbFiles.Path(name, kind);

        FS.FilePath Path(FS.FileName file)
            => DbFiles.Path(file);

        FS.FilePath Path(string @class, string name, FileKind kind)
            => DbFiles.Path(@class, name, kind);

        ListedFiles List()
            => DbFiles.List();

        string Format()
            => DbFiles.Format();

        Deferred<FS.FilePath> Enumerate()
            => DbFiles.Enumerate(true);
    }
}