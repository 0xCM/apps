//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free, SFx]
    public interface IValueProjector
    {
        ValueType Project(ValueType src);

        object Project(object src);
    }

    [Free, SFx]
    public interface IValueProjector<T> : IValueProjector
        where T : struct
    {
        new ref T Project(object src);

        object IValueProjector.Project(object src)
            =>  Project(src);
    }

    [Free, SFx]
    public interface IValueProjector<S,T> : IValueProjector<T>
        where S : struct
        where T : struct
    {
        ref T Project(in S src);

        ref T IValueProjector<T>.Project(object src)
            => ref Project((T)src);
    }
}