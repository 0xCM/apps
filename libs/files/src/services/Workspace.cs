//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    public class Workspace : IWorkspace
    {
        readonly IDbArchive Archive;

        public readonly Name Name;

        public readonly ReadOnlySeq<IWorkspace> Deps;

        [MethodImpl(Inline)]
        internal Workspace(IDbArchive archive)
        {
            Archive = archive;
            Name = archive.Root.FolderName.Format();
            Deps = sys.empty<IWorkspace>();
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Archive == null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Archive != null;
        }

        public IDbArchive Location
        {
            [MethodImpl(Inline)]
            get => Archive;
        }

        public Deferred<FS.FileUri> Members()
            => IsNonEmpty ? Location.Enumerate() : defer<FS.FileUri>();

        Name IWorkspace.Name
            => Name;
    }
}