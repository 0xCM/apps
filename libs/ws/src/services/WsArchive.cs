//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;

    public class WsArchive : IWsArchive
    {
        public readonly IRootedArchive Root;

        public readonly ProjectId ProjectId;

        [MethodImpl(Inline)]
        public WsArchive(IRootedArchive root, ProjectId name)
        {
            Root = root;
            ProjectId = name;
        }

        public IDbSources BuildRoot()
            => Root.Sources(build);

        public FS.Files BuildFiles()
            => BuildRoot().Files();

        public FS.Files BuildFiles(FileKind kind)
            => BuildRoot().Files(kind);

        public FS.Files BuildFiles(params FileKind[] kinds)
            => BuildRoot().Files(kinds);

        public FS.Files Files()
            => Root.Files();

        public FS.Files Files(FileKind kind)
            => Root.Files(kind);

        ProjectId IWsArchive.ProjectId
        {
            [MethodImpl(Inline)]
            get => ProjectId;
        }

        FS.FolderPath IRootedArchive.Root
        {
            [MethodImpl(Inline)]
            get => Root.Root;
        }
    }
}