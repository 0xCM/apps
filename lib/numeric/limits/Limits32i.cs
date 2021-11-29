//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines lower/upper bounds for <see cref='int'/> values
    /// </summary>
    public enum Limits32i : int
    {
        /// <summary>
        /// The minimum representable <see cref='int'/> value
        /// </summary>
        Min = int.MinValue,

        /// <summary>
        /// The maximum representable <see cref='int'/> value
        /// </summary>
        Max = int.MaxValue,
    }
}