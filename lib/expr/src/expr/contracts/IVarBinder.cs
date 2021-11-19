//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IVarBinder<T>
    {
        T Bind(string name);
    }

    public interface IVarBinder<K,T>
        where K : unmanaged
    {
        T Bind(K kind);
    }
}