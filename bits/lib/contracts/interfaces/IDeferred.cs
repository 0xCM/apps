//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes a container over discrete/enumerable content which need not be finite
    /// </summary>
    /// <typeparam name="T">The element type</typeparam>
    [Free]
    public interface IDeferred<T> : IContented<IEnumerable<T>>, IEnumerable<T>
    {
        IEnumerator IEnumerable.GetEnumerator()
            => Content.GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => Content.ToList().GetEnumerator();
    }

    /// <summary>
    /// Characterizes a reified container over discrete/enumerable content which need not be finite
    /// </summary>
    /// <typeparam name="F">The reifying type</typeparam>
    /// <typeparam name="T">The element type</typeparam>
    [Free]
    public interface IDeferred<F,T> : IDeferred<T>, IContented<F,IEnumerable<T>,T>, IConcatenable<F,T>
        where F : IDeferred<F,T>, new()
    {
        F IConcatenable<F,T>.Concat(F rhs)
            => WithContent(Content.Concat(rhs.Content));
    }
}