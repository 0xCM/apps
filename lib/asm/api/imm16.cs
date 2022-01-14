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
        /// Defines a 16-bit immediate operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static imm16 imm16(ushort src)
            => new imm16(src);

        /// <summary>
        /// Defines a T-parametric 16-bit immediate operand
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The storage type</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt8k | UInt16k)]
        public static imm16<T> imm16<T>(T src)
            where T : unmanaged
                => new imm16<T>(src);
    }
}