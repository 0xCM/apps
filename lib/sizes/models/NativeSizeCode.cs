//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource]
    public enum NativeSizeCode : byte
    {
        /// <summary>
        /// Indicates the width of an 8-bit register
        ///</summary>
        [Symbol("w8", "Indicates an 8-bit width")]
        W8 = 0,

        /// <summary>
        /// Indicates the width of a 16-bit register
        ///</summary>
        [Symbol("w16", "Indicates a 16-bit width")]
        W16 = 1,

        /// <summary>
        /// Indicates the width of a 32-bit register
        ///</summary>
        [Symbol("w32" ,"Indicates a 32-bit width")]
        W32 = 2,

        /// <summary>
        /// Indicates the width of a 64-bit register
        ///</summary>
        [Symbol("w64", "Indicates a 64-bit width")]
        W64 = 3,

        /// <summary>
        /// Indicates the width of a 128-bit register
        ///</summary>
        [Symbol("w128", "Indicates a 128-bit width")]
        W128 = 4,

        /// <summary>
        /// Indicates 256-bit width
        ///</summary>
        [Symbol("w256", "Indicates a 256-bit width")]
        W256 = 5,

        /// <summary>
        /// Indicates 512-bit width
        ///</summary>
        [Symbol("w512", "Indicates 512-bit width")]
        W512 = 6,

        /// <summary>
        /// Indicates an 80-bit width
        ///</summary>
        [Symbol("w80", "Indicates an 80-bit width")]
        W80 = 7,
    }
}