//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ProjectDbWs : Workspace<ProjectDbWs>, IProjectDb
    {
        public Settings ProjectSettings => Settings.Empty;

        [MethodImpl(Inline)]
        public static ProjectDbWs create(FS.FolderPath root)
            => new ProjectDbWs(root);

        [MethodImpl(Inline)]
        internal ProjectDbWs(FS.FolderPath root)
            : base(root)
        {

        }
    }
}