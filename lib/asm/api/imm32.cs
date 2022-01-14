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
        /// Defines a 32-bit immediate operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static imm32 imm32(uint src)
            => new imm32(src);

        /// <summary>
        /// Defines a T-parametric 32-bit immediate operand
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The storage type</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt8k | UInt16k | UInt32k)]
        public static imm32<T> imm32<T>(T src)
            where T : unmanaged
                => new imm32<T>(src);
    }
}