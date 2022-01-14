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
        /// Defines an 8-bit immediate operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static imm8 imm8(byte src)
            => new imm8(src);

        /// <summary>
        /// Defines a T-parametric 8-bit immediate operand
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The storage type</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt8k)]
        public static imm8<T> imm8<T>(T src)
            where T : unmanaged
                => new imm8<T>(src);
    }
}