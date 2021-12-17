//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IScriptVar : IExprVar
    {

    }

    [Free]
    public interface IScriptVar<T> : IScriptVar, IExprVar<T>
    {

    }
}