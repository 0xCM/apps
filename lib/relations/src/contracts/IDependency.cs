//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IDependency<S,T>
    {
        S Source {get;}

        T Target {get;}
    }

    [Free]
    public interface IDependency<T> : IDependency<T,T>
    {
        new T Source {get;}

        new T Target {get;}

        T IDependency<T,T>.Source
            => Source;

        T IDependency<T,T>.Target
            => Target;
    }
}