//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRootedArchive
    {
        FS.FolderPath Root {get;}

        // IDbSources Ancestor()
        //     => new DbArchive(Root.)

        DbArchive DbFiles => Root;

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

        FS.FileName HostFile(ApiHostUri host, FileKind kind)
            => FS.file(string.Format("{0}.{1}", host.Part.Format(), host.HostName), kind);

        FS.FilePath Table<T>()
            where T : struct
                => DbFiles.Table<T>();

        FS.FilePath Table<T>(ProjectId id)
            where T : struct
                => DbFiles.Table<T>(id);

        FS.FilePath PrefixedTable<T>(string prefix)
            where T : struct
                => DbFiles.PrefixedTable<T>(prefix);

        FS.FileName SuffixedTable<T>(string suffix)
            where T : struct
                => FS.file(string.Format("{0}.{1}", DbFiles.Table<T>(), suffix), FileKind.Csv);

        FS.FileName TableFile<T>(string prefix, string suffix)
            where T : struct
                => FS.file(string.Format("{0}.{1}.{2}",prefix, DbFiles.Table<T>(), suffix), FileKind.Csv);

        FS.Files Files()
            => DbFiles.Files(true);

        FS.Files Files(FS.FileExt ext)
            => DbFiles.Files(ext);

        FS.Files Files(FileKind kind)
            => DbFiles.Files(kind, true);

        FS.Files Files(string scope)
            => DbFiles.Files(scope, true);

        FS.Files Files(string scope, FileKind kind)
            => DbFiles.Files(scope, true, kind);

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

        ListedFiles List()
            => DbFiles.List();

        ListedFiles List(string pattern, bool recurse = true)
            => DbArchive.list(Root,pattern,recurse);

        string Format()
            => DbFiles.Format();

        Deferred<FS.FilePath> Enumerate()
            => DbFiles.Enumerate(true);
    }
}