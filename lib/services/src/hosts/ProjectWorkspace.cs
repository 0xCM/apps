//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ProjectWorkspace : IFileArchive
    {
        [MethodImpl(Inline)]
        public static ProjectWorkspace create(FS.FolderPath root, ProjectId id)
            => new ProjectWorkspace(root, id);

        public FS.FolderPath Root {get;}

        public ProjectId Project {get;}

        [MethodImpl(Inline)]
        ProjectWorkspace(FS.FolderPath root, ProjectId project)
        {
            Root = root;
            Project = project;
        }
    }
}