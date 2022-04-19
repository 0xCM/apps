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

        FS.FilePath IProjectWs.Log(string id)
            => Logs() + FS.file(id,FS.Log);

        FS.FolderPath Api()
            => Home() + FS.folder("api");

        FS.FolderPath ApiDocs()
            => Api() + FS.folder("docs");

        FS.FilePath ApiDoc(string name, FS.FileExt ext)
            => ApiDocs() + FS.file(name, ext);

        FS.FilePath ApiTablePath<T>()
            where T : struct
                => TablePath<T>("api");

        FS.FilePath ApiTablePath<T>(string scope)
            where T : struct
                => Api() + FS.folder(scope) + TableFile<T>();

        FS.FilePath ApiTablePath<T>(string scope, string suffix)
            where T : struct
                => Api() + FS.folder(scope) + TableFile<T>(suffix);

        FS.FolderPath Sources()
            => Home() + FS.folder("sources");

        FS.FolderPath SourceSettings(string scope)
            => Sources(scope) + FS.folder("settings");

        FS.FilePath SourceSettingsPath(string scope, string name, FS.FileExt ext)
            => SourceSettings(scope) + FS.file(name,ext);

        FS.FolderPath Sources(string scope)
            => Sources() + FS.folder(scope);

        FS.FilePath Source(string name, FS.FileExt ext)
            => Sources() + FS.file(name,ext);

        FS.Files SourcePaths(string scope)
            => Sources(scope).AllFiles;

        FS.FolderPath Jobs()
            => Subdir("jobs");

        FS.Files JobSpecs()
            => (Jobs() + FS.folder("specs")).Files(FS.ext("job"));

        FS.FilePath JobSpec(string name)
            => Jobs() + FS.file(name, FS.ext("job"));

        FS.FilePath Source(string scope, string name, FS.FileExt ext)
            => Sources(scope) + FS.file(name, ext);

        FS.FolderPath ProjectData()
            => Home() + FS.folder("projects");

        FS.FolderPath ProjectData(IProjectWs project)
            => ProjectData() + FS.folder(project.Name.Format());

        FS.FolderPath ProjectData(string scope)
            => ProjectData() + FS.folder(scope);

        FS.FolderPath ProjectData(IProjectWs project, string name)
            => ProjectData(project) + FS.folder(name);

        FS.FileName ProjectFile(IProjectWs project, string name, FS.FileExt ext)
            => FS.file(string.Format("{0}.{1}", project.Name, name), ext);

        FS.FileName ProjectFile(IProjectWs project, string name, FileKind kind)
            => FS.file(string.Format("{0}.{1}", project.Name, name), kind.Ext());

        FS.FileName TableFileName<T>(IProjectWs project)
            where T : struct
                => FS.file(string.Format("{0}.{1}", project.Name, Z0.Tables.identify<T>()), FS.Csv);

        FS.FilePath ProjectTable<T>(IProjectWs project)
            where T : struct
                => ProjectData(project) + TableFileName<T>(project);
    }
}