//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDbArchive : IDbSources, IDbTargets
    {

    }

    public interface IDbArchive<A> : IDbArchive
        where A : IDbArchive, new()
    {

    }
}