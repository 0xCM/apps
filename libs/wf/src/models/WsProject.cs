//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WsProject : IProjectWorkspace
    {
        public static IProjectWorkspace load(FS.FolderPath root, ProjectId id)
            => new WsProject(root, id);

        public static IProjectWorkspace load(IRootedArchive root, ProjectId id)
            => new WsProject(root, id);

        public ProjectId ProjectId {get;}

        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public WsProject(FS.FolderPath src, ProjectId id)
        {
            Root = src;
            ProjectId = id;
        }

        [MethodImpl(Inline)]
        public WsProject(IRootedArchive src, ProjectId id)
        {
            Root = src.Root;
            ProjectId = id;
        }
    }
}