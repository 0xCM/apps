//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static WsNames;

    public sealed class ProjectWs : Workspace<ProjectWs>, IProjectWs, IProjectProvider
    {
        [MethodImpl(Inline)]
        public static IProjectWs create(FS.FolderPath home, ProjectId id)
            => new ProjectWs(home,id);

        public static IProjectProvider provider(FS.FolderPath home, ProjectId id)
            => new ProjectWs(home,id);

        IProjectWs IProjectProvider.Project()
            => this;

        public ProjectId Project {get;}

        public Settings ProjectSettings {get;}

        public ProjectWs(FS.FolderPath src, ProjectId project)
            : base(src)
        {
            Project = project;
            ProjectSettings = Z0.Settings.Empty;
            var path = src + FS.file("project", FS.Settings);
            if(path.Exists)
            {
                var result = AppSettings.load(path);
                if(result)
                    ProjectSettings = result.Data;
            }
        }

        public Identifier Name
            => Project.Id;
    }

    partial class XTend
    {
        public static IProjectSet Projects(this DevWs src)
            => ProjectSet.create(src.Root + FS.folder(projects));

        public static IProjectWs Project(this DevWs src, ProjectId id)
            => ProjectWs.create(src.Root + FS.folder(projects), id);
    }
}