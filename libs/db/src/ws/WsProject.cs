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

        public ProjectId Id {get;}

        public FS.FolderPath Root {get;}

        public Settings ProjectSettings => Settings.Empty;

        [MethodImpl(Inline)]
        public WsProject(FS.FolderPath root, ProjectId id)
        {
            Root = root;
            Id = id;
        }

        Identifier IWorkspace.Name
            => Id.Format();

        ProjectId IProjectWs.Project
            => Id;
    }
}