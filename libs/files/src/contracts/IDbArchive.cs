//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDbArchive : IDbSources, IDbTargets
    {
        string Name => Root.Name;

        IDbArchive Scoped(string scope)
            => Datasets.archive(Root + FS.folder(scope));
    }
}