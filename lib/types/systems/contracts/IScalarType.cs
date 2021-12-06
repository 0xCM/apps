//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IScalarType<K> : ISizedType, IType<K>
        where K : unmanaged
    {

    }

    public interface IScalarType : IScalarType<ScalarClass>
    {

    }
}