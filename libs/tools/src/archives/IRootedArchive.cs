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

        ISourceArchive Sources()
            => DbFiles.Sources();

        ISourceArchive Sources(string scope)
            => DbFiles.Sources(scope);

        ITargetArchive Targets()
            => new DbTargets(Root);

        ITargetArchive Targets(string scope)
            => DbFiles.Targets(scope);

        ITargetArchive ProjectData(ProjectId id)
            => DbFiles.ProjectData(id);

        FS.FilePath Table<T>(ProjectId id)
            where T : struct
                => DbFiles.Table<T>(id);

        FS.Files Files()
            => DbFiles.Files(true);

        FS.Files Files(FileKind kind)
            => DbFiles.Files(kind, true);

        FS.FileName File(string name, FileKind kind)
            => DbFiles.File(name, kind);

        FS.FileName File(string @class, string name, FileKind kind)
            => DbFiles.File(@class, name, kind);

        FS.FilePath Path(string name, FileKind kind)
            => DbFiles.Path(name,kind);

        FS.FilePath Path(FS.FileName file)
            => DbFiles.Path(file);

        FS.FilePath Path(string @class, string name, FileKind kind)
            => DbFiles.Path(@class, name, kind);

        FS.FilePath Table<T>()
            where T : struct
                => DbFiles.Table<T>();

        string Format()
            => DbFiles.Format();

        // /// <summary>
        // /// Returns all files provided by the source
        // /// </summary>
        // FS.Files Files()
        //     => Root.Files(true);

        // /// <summary>
        // /// Returns all source-provided files of specified kind
        // /// </summary>
        // /// <param name="kind">The kind</param>
        // FS.Files Files(FileKind kind)
        //     => Root.Files(kind.Ext(), true);

        // ListedFiles List()
        //     => new ListedFiles(Root.EnumerateFiles(true).Array().Mapi((i,x) => new ListedFile(i,x)));

        // Deferred<FS.FilePath> Enumerate()
        //     => Root.EnumerateFiles(true);

        // FS.FileName File(string name, FileKind kind)
        //     => FS.file(name, kind.Ext());

        // FS.FileName File(string @class, string name, FileKind kind)
        //     => FS.file(string.Format("{0}.{1}", @class, name), kind.Ext());

        // FS.FilePath Path(string name, FileKind kind)
        //     => Root + File(name, kind);

        // FS.FilePath Path(FS.FileName file)
        //     => Root + file;


        // FS.FilePath Table<T>(string prefix)
        //     where T : struct
        //         => Root + Tables.filename<T>(prefix);


        // DbSources Sources()
        //     => new DbSources(Root);

        // DbSources Sources(string scope)
        //     => new DbSources(Root, scope);
    }

    public interface IRootedArchive<T> : IRootedArchive
        where T : IRootedArchive<T>
    {

    }
}