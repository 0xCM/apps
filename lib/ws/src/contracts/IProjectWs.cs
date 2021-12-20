//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static WsAtoms;

    public interface IProjectWs : IWorkspace
    {
        ProjectId Project {get;}

        Settings ProjectSettings {get;}

        FS.FolderPath Home()
            => Root + FS.folder(Project.Format());

        FS.FilePath IFileArchive.Path(string id, FS.FileExt ext)
            => Home() + FS.file(id,ext);

        FS.FolderPath IFileArchive.Subdir(string name)
            => Home() + FS.folder(name);

        FS.FilePath IFileArchive.Path(string scope, string id, FS.FileExt ext)
            => Subdir(scope) + FS.file(id,ext);

        FS.FolderPath IWorkspace.SrcDir()
            => Home() + FS.folder("src");

        FS.FolderPath IWorkspace.OutDir()
            => Out();

        FS.FolderPath IWorkspace.OutDir(string scope)
            => Out(scope);

        FS.FolderPath IWorkspace.ScriptDir()
            => Home() + FS.folder(scripts);

        FS.FilePath IFileArchive.TablePath<T>()
            where T : struct
                => Subdir("tables") + TableFile<T>();

        FS.FilePath IFileArchive.TablePath<T>(string scope)
            where T : struct
                => Subdir(scope) + TableFile<T>();

        FS.FilePath IFileArchive.TablePath<T>(string scope, string suffix)
            where T : struct
                => Subdir(scope) + TableFile<T>(scope, suffix);

        FS.FilePath TablePath<T>(string scope, FS.FileExt ext)
            where T : struct
                => Subdir(scope) + FS.file(string.Format("{0}.{1}", TableId<T>(), scope), ext);

        FS.FilePath TablePath<T>(string scope, string id, FS.FileExt ext)
            where T : struct
                => Subdir(scope) + FS.file(string.Format("{0}.{1}.{2}", TableId<T>(), scope, id), ext);

        FS.FilePath TablePath<T>(string scope, string subscope, string id, FS.FileExt ext)
            where T : struct
                => Subdir(scope) + FS.folder(subscope) + FS.file(string.Format("{0}.{1}", TableId<T>(), id), ext);

        FS.FilePath FilePath(string scope, string subscope, string id, FS.FileExt ext)
            => Subdir(scope) + FS.folder(subscope) + FS.file(id, ext);

        FS.FolderPath Out()
            => Home() + FS.folder(output);

        FS.FolderPath Out(string scope)
            => Out() + FS.folder(scope);

        FS.Files OutFiles()
            => Out().Files(true);

        FS.FolderPath Tables()
            => Home() + FS.folder(tables);

        FS.FolderPath Tables(string scope)
            => Tables() + FS.folder(scope);

        FS.FolderPath TablesOut()
            => Out(tables);

        FS.FilePath TableOut<T>()
            where T : struct
                => TablesOut() + FS.file(Z0.TableId.identify<T>().Format(), FS.Csv);

        FS.FilePath TableOut<T>(string subject)
            where T : struct
                => TablesOut() + FS.file(string.Format("{0}.{1}", subject, Z0.TableId.identify<T>().Format()), FS.Csv);

        FS.FilePath Table<T>()
            where T : struct
                => Tables() + FS.file(Z0.TableId.identify<T>().Format(), FS.Csv);

        FS.FilePath Table<T>(string subject)
            where T : struct
                => Tables() + FS.file(string.Format("{0}.{1}", subject, Z0.TableId.identify<T>().Format()), FS.Csv);

        FS.Files OutFiles(FS.FileExt ext)
            => Out().Files(ext, true);

        FS.Files OutFiles(params FileKind[] kinds)
            => Out().Files(true, kinds.Select(FileTypes.ext));

        FS.Files OutFiles(FS.FolderName subdir)
            => (Out() + subdir).Files(true);

        FS.Files OutFiles(FS.FolderName subdir, FS.FileExt ext)
            => (Out() + subdir).Files(ext,true);

        FS.FolderPath Logs()
            => Out() + FS.folder(logs);

        FS.FilePath Log(string id, FS.FileExt ext)
            => Logs() + FS.file(id,ext);

        FS.FilePath Log(string id)
            => Log(id, FS.Log);

        FS.FolderPath Src()
            => Home() + FS.folder(src);

        FS.Files SrcFiles()
            => Src().Files(true);

        FS.Files SrcFiles(string scope)
            => (Src() + FS.folder(scope)).AllFiles;

        FS.FilePath SrcFile(string scope, string fileid, FileKind kind)
            => Src() + FS.folder(scope) + FS.file(fileid, kind.Ext());

        FS.FolderPath Assets()
            => Home() + FS.folder(assets);

        FS.FolderPath Scripts()
            => Home() + FS.folder(scripts);

        FS.FolderPath Scripts(string scope)
            => Scripts() + FS.folder(scope);

        FS.FilePath Script(string scope, ScriptId sid, FS.FileExt ext)
            => Scripts(scope) + FS.file(sid.Format(), ext);
    }
}