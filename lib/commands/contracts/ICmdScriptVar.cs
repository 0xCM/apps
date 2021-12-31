//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ICmdScriptVar : IVarValue
    {

    }

    [Free]
    public interface ICmdScriptVar<T> : ICmdScriptVar, IVarValue<T>
    {

    }
}