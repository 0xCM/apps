//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes any equatable value
    /// </summary>
    /// <typeparam name="T">The value type</typeparam>
    [Free]
    public interface IAny<T> : IEquatable<T>
        where T : IEquatable<T>
    {

    }

    /// <summary>
    /// Characterizes an equatable value reification
    /// </summary>
    /// <typeparam name="F">The reification type</typeparam>
    /// <typeparam name="T">The value type</typeparam>
    [Free]
    public interface IAny<F,T> : IAny<T>
        where T : IEquatable<T>
        where F : IAny<F,T>, new()
    {

    }
}