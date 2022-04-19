//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Collections;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IDeferredSource<T> : ISource<IEnumerable<T>>, IEnumerable<T>
    {
        IEnumerator IEnumerable.GetEnumerator()
            => Next().GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => Next().GetEnumerator();
    }
}