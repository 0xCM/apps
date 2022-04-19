//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static WsAtoms;

    public interface IProjectSet : IWorkspace
    {
        IProjectWs Project(ProjectId id)
            => ProjectWs.create(Root,id);

        FS.FolderPath Home(ProjectId project)
            => Root + FS.folder(project.Format());

        FS.FolderPath Out(ProjectId project)
            => Home(project) + FS.folder(output);

        FS.FolderPath Out(ProjectId project, Subject scope)
            => Out(project) + FS.folder(scope.Format());

        FS.Files OutFiles(ProjectId project)
            => Out(project).Files(true);

        FS.FolderPath DataOut(ProjectId project)
            => Out(project, data);

        FS.FolderPath TablesOut(ProjectId project)
            => Out(project, tables);

        FS.FilePath TableOut<T>(ProjectId project)
            where T : struct
                => TablesOut(project) + FS.file(Z0.TableId.identify<T>().Format(), FS.Csv);

        FS.Files OutFiles(ProjectId project, FS.FileExt ext)
            => Out(project).Files(ext, true);

        FS.Files OutFiles(ProjectId project, FileKind kind)
            => OutFiles(project, FileTypes.ext(kind));

        FS.Files OutFiles(ProjectId project, params FileKind[] kinds)
            => Out(project).Files(true, kinds.Select(FileTypes.ext));

        FS.Files OutFiles(ProjectId project, FS.FolderName subdir)
            => (Out(project) + subdir).Files(true);

        FS.Files OutFiles(ProjectId project, FS.FolderName subdir, FS.FileExt ext)
            => (Out(project) + subdir).Files(ext,true);

        FS.FolderPath Src(ProjectId project)
            => Home(project) + FS.folder(src);

        FS.Files SrcFiles(ProjectId project)
            => Src(project).Files(true);

        FS.Files SrcFiles(ProjectId project, Subject scope)
            => (Src(project) + FS.folder(scope.Format())).AllFiles;

        FS.FolderPath Scripts(ProjectId project)
            => Home(project) + FS.folder(scripts);

        FS.FolderPath Scripts(ProjectId project, Subject scope)
            => Scripts(project) + FS.folder(scope.Format());

        FS.FilePath Script(ProjectId project, Subject scope, ScriptId sid, FS.FileExt ext)
            => Scripts(project,scope) + FS.file(sid.Format(), ext);

        FS.FilePath Script(ProjectId project, ScriptId sid, FS.FileExt ext)
            => Scripts(project) + FS.file(sid.Format(), ext);
    }
}