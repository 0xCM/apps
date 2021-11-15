//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Flows
{
    using System;
    using System.Collections.Generic;

    public interface IChannel2x2<T>
        where T : unmanaged
    {
        void Send(T x0, T x1, out T y0, out T y1);
    }

    public interface IChannel2x2<C,T> : IChannel2x2<T>
        where T : unmanaged
        where C : unmanaged, IChannel2x2<C,T>
    {
    }
}