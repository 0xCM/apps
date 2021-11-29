//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IEnvVar : IRuleVar
    {

    }

    [Free]
    public interface IEnvVar<T> : IEnvVar, IRuleVar<T>
        where T : struct
    {

    }
}