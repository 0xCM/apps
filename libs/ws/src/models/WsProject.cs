//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WsProject : IWsProject
    {
        public static IWsProject load(FS.FolderPath root, ProjectId id)
            => new WsProject(root, id);

        public static IWsProject load(IRootedArchive root, ProjectId id)
            => new WsProject(root, id);

        public ProjectId Id {get;}

        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public WsProject(FS.FolderPath src, ProjectId id)
        {
            Root = src;
            Id = id;
        }

        [MethodImpl(Inline)]
        public WsProject(IRootedArchive src, ProjectId id)
        {
            Root = src.Root;
            Id = id;
        }

        string IWorkspaceObselete.Name
            => Id.Format();

        ProjectId IProjectWsObsolete.Project
            => Id;
    }
}