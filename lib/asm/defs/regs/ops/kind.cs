//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
     using System;
     using System.Runtime.CompilerServices;

    using static Root;
    using static RegFieldFacets;

    partial struct AsmRegs
    {
        [MethodImpl(Inline), Op]
        public static RegKind kind(RegIndexCode i, RegClassCode k, NativeSizeCode w)
            => (RegKind)(((uint)i  << IndexField) | ((uint)k << ClassField) | ((uint)w << WidthField));

        /// <summary>
        /// Determines the register class from the kind
        /// </summary>
        /// <param name="src">The source kind</param>
        [MethodImpl(Inline), Op]
        public static RegClassCode @class(RegKind src)
            => (RegClassCode)bits.slice((uint)src, (byte)RegFieldIndex.K, (byte)RegFieldWidth.RegClass);

        /// <summary>
        /// Determines the register class from the operand
        /// </summary>
        /// <param name="src">The register operand</param>
        [MethodImpl(Inline), Op]
        public static RegClassCode @class(RegOp src)
            => (RegClassCode)bits.segment(src.Bitfield, 5, 9);
    }
}