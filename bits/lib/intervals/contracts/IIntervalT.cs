//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a contiguous segment of homogenous values that lie within
    /// left and right boundaries 
    /// </summary>
    /// <remarks>
    /// Note that extended real numbers may also serve as endpoints,enabling representations such as (-∞,3] and (-3, ∞).
    /// </remarks>
    public interface IInterval<T> : IInterval
        where T : unmanaged
    {    
        /// <summary>
        ///  The left endpoint
        /// </summary>
        T Left {get;}

        /// <summary>
        ///  The right endpoint
        /// </summary>
        T Right {get;}
    } 
}