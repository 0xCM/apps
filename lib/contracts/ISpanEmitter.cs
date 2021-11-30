//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes an emitter that shoots out spans
    /// </summary>
    /// <typeparam name="T">The span element type</typeparam>
    [Free, SFx]
    public interface ISpanEmitter<T> : IFunc
    {
        Span<T> Invoke();
    }
}