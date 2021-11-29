//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IInterval<S,T> : IInterval<T>, ITextual, IPair<S,T>
        where S : struct, IInterval<S,T>
        where T : unmanaged
    {
        S New(T left, T right, IntervalKind kind);

        /// <summary>
        /// Creates an open interval with endpoints from the existing interval
        /// </summary>
        S ToOpen();

        /// <summary>
        /// Creates a left-open/right-closed interval with endpoints from the existing interval
        /// </summary>
        S ToLeftOpen();

        /// <summary>
        /// Creates a left-open/right-closed interval with endpoints from the existing interval
        /// </summary>
        S ToRightClosed();

        /// <summary>
        /// Creates a left-open/right-closed interval with endpoints from the existing interval
        /// </summary>
        S ToRightOpen();

        /// <summary>
        /// Creates a left-closed interval with endpoints from the existing interval
        /// </summary>
        S ToLeftClosed();

        /// <summary>
        /// Creates a closed interval with endpoints from the existing interval
        /// </summary>
        S ToClosed();
    }
}