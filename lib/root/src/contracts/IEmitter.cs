//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.Intrinsics;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IEmitter<T>
    {
        bool Emit(out T dst);
    }

    /// <summary>
    /// Characterizes an operation that produces a value that does not depend on arguments
    /// </summary>
    /// <typeparam name="A">The production type</typeparam>
    [Free, SFx]
    public interface ISFxEmitter<A> : IFunc<A>
    {

    }

    [Free, SFx]
    public interface IEmitter128<T> : ISFxEmitter<Vector128<T>>, IFunc128<T>
        where T : unmanaged
    {

    }

    [Free, SFx]
    public interface IEmitter256<T> : ISFxEmitter<Vector256<T>>, IFunc256<T>
        where T : unmanaged
    {

    }
}