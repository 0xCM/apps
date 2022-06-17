//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct WsArchive : IWsArchive
    {
        [Render(32)]
        public readonly ProjectId ProjectId;

        [Render(1)]
        public readonly FS.FolderPath Root;

        [MethodImpl(Inline)]
        public WsArchive(ProjectId id, FS.FolderPath dst)
        {
            ProjectId = id;
            Root = dst;
        }

        ProjectId IWsArchive.ProjectId
        {
            [MethodImpl(Inline)]
            get => ProjectId;
        }

        FS.FolderPath IRootedArchive.Root
        {
            [MethodImpl(Inline)]
            get => Root;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => text.empty(ProjectId) || Root.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => text.nonempty(ProjectId) && Root.IsNonEmpty;
        }

        public string Format()
            => Root.Format();

        public override string ToString()
            => Format();

        public static WsArchive Empty => new WsArchive(EmptyString, FS.FolderPath.Empty);

    }
}