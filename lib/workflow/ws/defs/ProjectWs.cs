//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class ProjectWs : Workspace<ProjectWs>, IProjectWs
    {
        [MethodImpl(Inline)]
        public static IProjectWs create(FS.FolderPath home, ProjectId id)
            => new ProjectWs(home,id);

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
}