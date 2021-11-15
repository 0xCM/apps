// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static cpu;
    using static gcpu;

    partial struct vbits
    {
        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <typeparam name="T">The cell type</typeparam>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> vblend<T>(Vector128<T> x, Vector128<T> y, Vector128<T> mask)
            where T : unmanaged
                => vxor(x, vand(vxor(x,y), mask));

        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <typeparam name="T">The cell type</typeparam>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector256<T> vblend<T>(Vector256<T> x, Vector256<T> y, Vector256<T> mask)
            where T : unmanaged
                => vxor(x, vand(vxor(x,y), mask));

        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vblend(Vector128<byte> x, Vector128<byte> y, Vector128<byte> mask)
            => vxor(x, vand(vxor(x,y), mask));

        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vblend(Vector128<ushort> x, Vector128<ushort> y, Vector128<ushort> mask)
            => vxor(x, vand(vxor(x,y), mask));

        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vblend(Vector128<uint> x, Vector128<uint> y, Vector128<uint> mask)
            => vxor(x, vand(vxor(x,y), mask));

        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vblend(Vector128<ulong> x, Vector128<ulong> y, Vector128<ulong> mask)
            => vxor(x, vand(vxor(x,y), mask));

        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vblend(Vector256<byte> x, Vector256<byte> y, Vector256<byte> mask)
            => vxor(x, vand(vxor(x,y), mask));

        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vblend(Vector256<ushort> x, Vector256<ushort> y, Vector256<ushort> mask)
            => vxor(x, vand(vxor(x,y), mask));

        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vblend(Vector256<uint> x, Vector256<uint> y, Vector256<uint> mask)
            => vxor(x, vand(vxor(x,y), mask));

        /// <summary>
        /// Blends the left and right vectors at the bit-level as specified by the mask operand.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="mask">The selection mask</param>
        /// <remarks>Equivalent to select</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vblend(Vector256<ulong> x, Vector256<ulong> y, Vector256<ulong> mask)
            => vxor(x, vand(vxor(x,y), mask));
    }
}