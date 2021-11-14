//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct asm
    {
        /// <summary>
        /// Defines a 32-bit displacement
        /// </summary>
        /// <param name="src">The displacement magnitude</param>
        [MethodImpl(Inline), Op]
        public static Disp32 disp32(int src)
            => new Disp32(src);

        /// <summary>
        /// Defines a 32-bit displacement
        /// </summary>
        /// <param name="src">The displacement magnitude</param>
        [MethodImpl(Inline), Op]
        public static Disp32 disp32(long src)
            => new Disp32((int)src);

        /// <summary>
        /// Computs a 32-bit displacement from specified source bytes
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The offset to begin displacement extraction</param>
        [MethodImpl(Inline), Op]
        public static Disp32 disp32(BinaryCode src, byte offset)
            => i32(slice(src.View, offset));

        /// <summary>
        /// Computes a 32-bit displacement relative to a specified instruction pointer and target address
        /// </summary>
        /// <param name="ip">The instruction pointer address</param>
        /// <param name="dst">The target address</param>
        [MethodImpl(Inline), Op]
        public static Disp32 disp32(MemoryAddress ip, MemoryAddress dst)
            => disp32((long)dst - (long)ip);
    }
}