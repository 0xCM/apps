//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using p = Pow2x8;

    /// <summary>
    /// Defines a parameter reference partition that aligns with .net core system capabilities
    /// </summary>
    public enum ClrArgRefKind : byte
    {
        /// <summary>
        /// The empty class
        /// </summary>
        None = 0,

        /// <summary>
        /// Classifies paramters that are declared with the "in" modifier
        /// </summary>
        In = p.P2ᐞ00,

        /// <summary>
        /// Classifies paramters that are declared with the "out" modifier
        /// </summary>
        Out = p.P2ᐞ01,

        /// <summary>
        /// Classifies paramters that are declared with the "ref" modifier
        /// </summary>
        Ref = p.P2ᐞ02,
    }
}