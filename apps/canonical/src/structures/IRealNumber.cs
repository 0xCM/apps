//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Characterizes a structured real
    /// </summary>
    /// <typeparam name="S">The reification type</typeparam>
    public interface IRealNumber<S> : IOrderedNumber<S>, ITrigonmetric<S>, IComparable<S>
        where S : IRealNumber<S>, new()
    {

    }

    /// <summary>
    /// Characterizes a reification structure over real numbers
    /// </summary>
    /// <typeparam name="S">The reification type</typeparam>
    /// <typeparam name="T">The underlying type</typeparam>
    public interface IRealNumber<S,T> : IRealNumber<S>
        where S : IRealNumber<S,T>, new()
    {

    }
}