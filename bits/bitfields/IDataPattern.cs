//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDataPattern
    {

    }

    public interface IDataPattern<T> : IDataPattern
        where T : unmanaged
    {
        T Content {get;}
    }
}