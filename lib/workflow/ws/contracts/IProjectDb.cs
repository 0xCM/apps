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

        FS.FolderPath ProjectData(IProjectWs src, string name)
            => ProjectData() + FS.folder(string.Format("{0}.{1}", src.Project, name));

        FS.FilePath ProjectTable<T>(IProjectWs src)
            where T : struct
                => ProjectData() + FS.file(string.Format("{0}.{1}", src.Project, TableId<T>()), FS.Csv);

        FS.FilePath ProjectTable<T>(IProjectWs src, string scope)
            where T : struct
                => ProjectData(scope) + FS.file(string.Format("{0}.{1}", src.Project, TableId<T>()), FS.Csv);

        FS.FilePath ProjectDataFile(IProjectWs src, FileKind kind)
            => ProjectData() + FS.file(src.Project.Format(), kind.Ext());

        FS.FilePath ProjectDataFile(IProjectWs src, string scope, FileKind kind)
            => ProjectData(scope) + FS.file(src.Project.Format(), kind.Ext());

        FS.FilePath ProjectDataFile(IProjectWs src, string name, FS.FileExt ext)
            => ProjectData() + FS.file(string.Format("{0}.{1}", src.Project, name), ext);

        FS.FilePath ProjectDataFile(IProjectWs src, string scope, string name, FS.FileExt ext)
            => ProjectData(scope) + FS.file(string.Format("{0}.{1}", src.Project, name), ext);

        FS.Files ProjectDataFiles(IProjectWs src, FS.FileExt ext)
            => ProjectData().Files(ext,true);

        FS.Files ProjectDataFiles(IProjectWs src, string scope, FS.FileExt ext)
            => ProjectData(scope).Files(ext,true);

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