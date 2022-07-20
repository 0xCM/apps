//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWorkspace : IExpr
    {
        IDbArchive Location {get;}

        bool INullity.IsEmpty
            => Location == null;

        bool INullity.IsNonEmpty
            => Location != null;

        Name Name
            => IsNonEmpty ? Location.Root.FolderName.Format() : Asci.Null;

        ReadOnlySeq<IWorkspace> Deps
            => sys.empty<IWorkspace>();

        string IExpr.Format()
            => Location.Root.Format();

        Deferred<FS.FileUri> Members()
            => Location.Enumerate();
    }
}