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
            => Subdir("logs");

        FS.FolderPath Api()
            => Home() + FS.folder("api");

        FS.FolderPath ApiDocs()
            => Api() + FS.folder("docs");

        FS.FilePath ApiDoc(string name, FS.FileExt ext)
            => ApiDocs() + FS.file(name, ext);

        FS.FilePath ApiTablePath<T>()
            where T : struct
                => TablePath<T>("api");

        FS.FolderPath Sources()
            => Home() + FS.folder("sources");

        FS.FolderPath Sources(string scope)
            => Sources() + FS.folder(scope);

        FS.FilePath Source(string name, FS.FileExt ext)
            => Sources() + FS.file(name,ext);
        FS.FolderPath Jobs()
            => Subdir("jobs");

        FS.Files JobSpecs()
            => (Jobs() + FS.folder("specs")).Files(FS.ext("job"));

        FS.FilePath Source(string scope, string name, FS.FileExt ext)
            => Sources(scope) + FS.file(name, ext);

        FS.FolderPath ProjectData()
            => Home() + FS.folder("projects");

        FS.FolderPath ProjectData(IProjectWs project)
            => ProjectData() + FS.folder(project.Name);

        FS.FileName TableFileName<T>(IProjectWs project)
            where T : struct
                => FS.file(string.Format("{0}.{1}", project.Name, Z0.Tables.identify<T>()), FS.Csv);

        FS.FilePath ProjectTable<T>(IProjectWs project)
            where T : struct
                => ProjectData(project) + TableFileName<T>(project);
    }
}