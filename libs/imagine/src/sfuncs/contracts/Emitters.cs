//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines the canonical shape of an emitter
    /// </summary>
    /// <typeparam name="T">The production type</typeparam>
    [Free]
    public delegate T Emitter<T>();

    /// <summary>
    /// Defines the canonical shape of an emitter
    /// </summary>
    /// <typeparam name="T">The production type</typeparam>
    /// <typeparam name="C">The cell type into which the production type is segmented</typeparam>
    [Free]
    public delegate T Emitter<T,C>();

    /// <summary>
    /// Characterizes a function that produces spans values
    /// </summary>
    /// <typeparam name="T">The emission type</typeparam>
    [Free]
    public delegate Span<T> SpanEmitter<T>();

}