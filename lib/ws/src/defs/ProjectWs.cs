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

        public ProjectWs(FS.FolderPath src, ProjectId project)
            : base(src)
        {
            Project = project;

        }

        public Identifier Name
            => Project.Id;
    }
}