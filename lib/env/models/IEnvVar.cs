//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IEnvVar : IVarValue
    {

    }

    [Free]
    public interface IEnvVar<T> : IEnvVar, IVarValue<T>
        where T : struct
    {

    }
}