//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public delegate string FormatterDelegate<T>(T src);

    [Free]
    public delegate string FormatterDelegate(dynamic src);

    [Free]
    public interface IFormatter
    {
        string Format(dynamic src);

        Type SourceType {get;}

    }

    [Free]
    public interface IFormatter<T> : IFormatter
    {
        string Format(T src);

        string IFormatter.Format(dynamic src)
            => Format((T)src);

        Type IFormatter.SourceType
            => typeof(T);
    }
}