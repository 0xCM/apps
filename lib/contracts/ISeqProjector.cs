//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ISeqProjector
    {
        Outcome<uint> Project(ReadOnlySpan<dynamic> src, Span<dynamic> dst);
    }

    /// <summary>
    /// Characterizes a sequence projector
    /// </summary>
    /// <typeparam name="S">The source element type</typeparam>
    /// <typeparam name="T">The target element type</typeparam>
    [Free]
    public interface ISeqProjector<S,T> : ISeqProjector
    {
        /// <summary>
        /// Projects elements from a specified source into a specified target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The data target</param>
        /// <returns>The count of projected elements, if successful; otherwise an error specification</returns>
        Outcome<uint> Project(ReadOnlySpan<S> src, Span<T> dst);

        Outcome<uint> ISeqProjector.Project(ReadOnlySpan<dynamic> src, Span<dynamic> dst)
            => Project(recover<dynamic,S>(src), recover<dynamic,T>(dst));
    }
}