//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IOrderedNumber<S> :  IStepwise<S>,  IOrdered<S>,  INumber<S>
        where S : IOrderedNumber<S>, new() {}

    /// <summary>
    /// Characterizes a structural number with order
    /// </summary>
    /// <typeparam name="S">The reification type</typeparam>
    /// <typeparam name="T">The underlying type</typeparam>
    public interface IOrderedNumber<S,T> : IOrderedNumber<S>
        where S : IOrderedNumber<S,T>, new() {}

}