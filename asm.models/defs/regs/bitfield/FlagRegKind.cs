//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static RegFieldFacets;
    using static RegIndexCode;
    using static RegClassCode;
    using static NativeSizeCode;

    /// <summary>
    /// Defines flag register classifiers
    /// </summary>
    public enum FlagRegKind : ushort
    {
        /// <summary>
        /// Indicates the 16-bit FLAGS register
        /// </summary>
        Flags = r0 | FLAG << ClassField | W16 << WidthField,

        /// <summary>
        /// Indicates the 32-bit EFLAGS register
        /// </summary>
        EFlags = r0 | FLAG << ClassField | W32 << WidthField,

        /// <summary>
        /// Indicates the 64-bit RFLAGS register
        /// </summary>
        RFlags = r0 | FLAG << ClassField | W64 << WidthField,
    }
}