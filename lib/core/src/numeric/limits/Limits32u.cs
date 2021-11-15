//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines lower/upper bounds for <see cref='uint'/> values
    /// </summary>
    public enum Limits32u : uint
    {
        /// <summary>
        /// The minimum representable <see cref='uint'/> value
        /// </summary>
        Min = uint.MinValue,

        /// <summary>
        /// The maximum representable <see cref='uint'/> value
        /// </summary>
        Max = uint.MaxValue,
    }
}