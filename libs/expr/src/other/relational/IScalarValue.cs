//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IScalarValue<K,T> : IScalarValue<T>, IValue<T>, IScalarExpr
        where T : unmanaged
        where K : unmanaged
    {

    }
}