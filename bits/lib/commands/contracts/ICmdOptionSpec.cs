//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes a tool option
    /// </summary>
    [Free]
    public interface ICmdOptionSpec : INamed, ITextual
    {
        @string Description {get;}
    }

    /// <summary>
    /// Characterizes a kinded tool option
    /// </summary>
    [Free]
    public interface ICmdOptionSpec<K> : ICmdOptionSpec
        where K : unmanaged
    {
        K Kind {get;}

        Name INamed.Name
            => Kind.ToString();
    }
}