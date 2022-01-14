//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct asm
    {
        /// <summary>
        /// Defines a 64-bit immediate operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static imm64 imm64(uint src)
            => new imm64(src);

        /// <summary>
        /// Defines a T-parametric 64-bit immediate operand
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The storage type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static imm64<T> imm64<T>(T src)
            where T : unmanaged
                => new imm64<T>(src);
    }
}