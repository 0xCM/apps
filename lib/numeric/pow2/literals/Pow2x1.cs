//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using K = Pow2;

    /// <summary>
    /// Defines 1
    /// </summary>
    [Flags, LiteralSet(typeof(Pow2))]
    public enum Pow2x1 : byte
    {
        /// <summary>
        /// 2^0 = 1
        /// </summary>
        [Symbol("2^0")]
        P2ᐞ00 = K.T00,
    }
}