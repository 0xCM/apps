//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a reification structure over an integer type
    /// </summary>
    /// <typeparam name="S">The reification type</typeparam>
    /// <typeparam name="T">The underlying type</typeparam>
    public interface IInteger<S,T> : IInteger<S>
        where S : IInteger<S,T>, new() { }

    public interface IInteger<S> :  IRealNumber<S>, IStepwise<S>
        where S : IInteger<S>, new()
    { }
}