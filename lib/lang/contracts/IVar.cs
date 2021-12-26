//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IVar : IExpr
    {
        string Name {get;}
    }

    [Free]
    public interface IVar<T> : IVar
    {
        T Value {get;}
    }
}