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
            => Home() + FS.folder("logs");

        FS.FolderPath Api()
            => Home() + FS.folder("api");

        FS.FolderPath ProjectData()
            => Home() + FS.folder("projects");

        FS.FolderPath ProjectData(string scope)
            => ProjectData() + FS.folder(scope);

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

        FS.FilePath ProjectTable<T>(IProjectWs ws)
            where T : struct
                => ProjectData() + FS.file(string.Format("{0}.{1}", ws.Project, TableId<T>()), FS.Csv);

        FS.FilePath ProjectTable<T>(IProjectWs ws, string scope)
            where T : struct
                => ProjectData(scope) + FS.file(string.Format("{0}.{1}", ws.Project, TableId<T>()), FS.Csv);

        FS.FilePath ProjectDataFile(IProjectWs ws, string name, FS.FileExt ext)
            => ProjectData() + FS.file(string.Format("{0}.{1}", ws.Project, name), ext);

        FS.FilePath ProjectDataFile(IProjectWs ws, string scope, string name, FS.FileExt ext)
            => ProjectData(scope) + FS.file(string.Format("{0}.{1}", ws.Project, name), ext);

        FS.FilePath ApiTablePath<T>()
            where T : struct
                => TablePath<T>("api");

        FS.FilePath ApiTablePath<T>(string scope)
            where T : struct
                => Api() + FS.folder(scope) + TableFile<T>();

        FS.FilePath ApiTablePath<T>(string scope, string suffix)
            where T : struct
                => Api() + FS.folder(scope) + TableFile<T>(suffix);
    }
}