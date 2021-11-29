//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines lower/upper bounds for uint24 values
    /// </summary>
    public enum Limits24u : uint
    {
        /// <summary>
        /// The minimum representable uint24 value
        /// </summary>
        Min = ushort.MinValue,

        /// <summary>
        /// The maximum representable uint24 value
        /// </summary>
        Max = (uint)Limits16u.Max | ((uint)Limits8u.Max << 16),
    }
}