//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
    
    [Free]
    public interface IVar : IExpr, IDecl 
    {
        Label Name {get;}

        Type ValueType {get;}
    }

    [Free]
    public interface IVar<T> : IVar
    {
        Type IVar.ValueType
            => typeof(T);
    }
}