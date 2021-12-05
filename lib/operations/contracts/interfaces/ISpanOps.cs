//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes a function that produces spans values
    /// </summary>
    /// <typeparam name="T">The emission type</typeparam>
    [Free]
    public delegate Span<T> SpanEmitter<T>();

    /// <summary>
    /// Characterizes a structural function that accepts source span and
    /// target spans defined over cells of common type
    /// </summary>
    /// <typeparam name="W">The cell width</typeparam>
    /// <typeparam name="T">The cell type</typeparam>
    [Free, SFx]
    public interface IUnarySpanOp<T> : IFunc
    {
        Span<T> Invoke(ReadOnlySpan<T> src, Span<T> dst);
    }

    /// <summary>
    /// Characterizes a function that accepts two source spans and a target span over a common element type
    /// </summary>
    /// <typeparam name="T">The span element type</typeparam>
    [Free, SFx]
    public interface IBinarySpanOp<T> : IFunc
    {
        Span<T> Invoke(ReadOnlySpan<T> lhs, ReadOnlySpan<T> rhs, Span<T> dst);
    }

    /// <summary>
    /// Characterizes a structural function that accepts two source spans and a
    /// target span defined over cells of common type
    /// </summary>
    /// <typeparam name="T">The span element type</typeparam>
    [Free, SFx]
    public interface ITernarySpanOp<T> : IFunc
    {
        Span<T> Invoke(ReadOnlySpan<T> a, ReadOnlySpan<T> b, ReadOnlySpan<T> c, Span<T> dst);
    }
}