//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IVarResolver
    {
        Value<dynamic> Resolve(IVar var);
    }

    [Free]
    public interface IVarResolver<T> : IVarResolver
    {
        Value<T> Resolve(IVar<T> var);
    }
}