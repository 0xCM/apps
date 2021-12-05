//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.Intrinsics;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Defines the canonical shape of a terneray operator
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    /// <param name="c">The third operand</param>
    /// <typeparam name="T">The operand type</typeparam>
    [Free]
    public delegate T TernaryOp<T>(T a, T b, T c);

    /// <summary>
    /// Characterizes a structural ternary operator
    /// </summary>
    /// <typeparam name="A">The operand type</typeparam>
    [Free, SFx]
    public interface ITernaryOp<A> : IFunc<A,A,A,A>
    {
        new TernaryOp<A> Operation
            => new TernaryOp<A>((this as IFunc<A,A,A,A>).Operation);
    }

    [Free, SFx]
    public interface ITernaryOpIn<A> : IFuncIn<A,A,A,A>
    {

    }

    /// <summary>
    /// Characterizes a vectorized 128-bit ternary operator
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface ITernaryOp128<T> : ITernaryOp<Vector128<T>>, IFunc128<T>
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a vectorized 256-bit ternary operator
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface ITernaryOp256<T> : ITernaryOp<Vector256<T>>, IFunc256<T>
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a vectorized 128-bit ternary operator that also supports evaluation via scalar decomposition
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface ITernaryOp128D<T> : ITernaryOp128<T>, ITernaryOp<T>
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a vectorized 256-bit ternary operator that also supports evaluation via scalar decomposition
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface ITernaryOp256D<T> : ITernaryOp256<T>, ITernaryOp<T>
        where T : unmanaged
    {

    }

}