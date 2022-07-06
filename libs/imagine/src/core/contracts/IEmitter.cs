//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IEmitter<T>
    {
        bool Next(out T dst);
    }

    /// <summary>
    /// Characterizes an operation that produces a value that does not depend on arguments
    /// </summary>
    /// <typeparam name="A">The production type</typeparam>
    [Free, SFx]
    public interface ISFxEmitter<A> : IFunc<A>
    {

    }

}