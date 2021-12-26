//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines lower/upper bounds for <see cref='byte'/> values
    /// </summary>
    [SymSource("limits", NumericBaseKind.Base16)]
    public enum Limits8u : byte
    {
        /// <summary>
        /// The minimum representable <see cref='byte'/> value
        /// </summary>
        Min = byte.MinValue,

        /// <summary>
        /// The maximum representable <see cref='byte'/> value
        /// </summary>
        Max = byte.MaxValue,
    }
}