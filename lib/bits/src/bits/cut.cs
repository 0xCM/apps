//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static System.Runtime.Intrinsics.X86.Bmi2;
    using static System.Runtime.Intrinsics.X86.Bmi2.X64;
    using static Root;

    partial class bits
    {
        /// <summary>
        /// unsigned int _bzhi_u32 (unsigned int a, unsigned int index) BZHI r32a, reg/m32, r32b
        /// Replicates the source bits to the target and disables the high target bits starting at a specified index.
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), MsbOff]
        public static byte cut(byte src, byte index)
            => (byte)ZeroHighBits((uint)src, index);

        /// <summary>
        /// unsigned int _bzhi_u32 (unsigned int a, unsigned int index) BZHI r32a, reg/m32, r32b
        /// Replicates the source bits to the target and disables the high target bits starting at a specified index.
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), MsbOff]
        public static ushort cut(ushort src, byte index)
            => (ushort)ZeroHighBits((uint)src, index);

        /// <summary>
        /// unsigned int _bzhi_u32 (unsigned int a, unsigned int index) BZHI r32a, reg/m32, r32b
        /// Replicates the source bits to the target and disables the high target bits starting at a specified index.
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), MsbOff]
        public static uint cut(uint src, byte index)
            => ZeroHighBits(src, index);

        /// <summary>
        /// unsigned __int64 _bzhi_u64 (unsigned __int64 a, unsigned int index) BZHI r64a,reg/m32, r64b
        /// Disables the high target bits starting at a specified index.
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The index at which to begin disabling bits</param>
        [MethodImpl(Inline), MsbOff]
        public static ulong cut(ulong src, byte index)
            => ZeroHighBits(src, index);
    }
}