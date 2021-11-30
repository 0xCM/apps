//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IKeyed<T> : ITextual
    {
        T Key {get;}

        string ITextual.Format()
            => Key?.ToString() ?? string.Empty;
    }

    [Free]
    public interface IKeyed<H,T> : IKeyed<T>
        where H : IKeyed<H,T>
    {

    }
}