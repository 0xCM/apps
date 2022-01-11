//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDataPattern
    {
        MatchKind MatchKind {get;}
    }

    public interface IDataPattern<T> : IDataPattern
        where T : unmanaged
    {
        T State {get;}
    }
}