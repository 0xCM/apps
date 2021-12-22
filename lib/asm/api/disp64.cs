//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct asm
    {
        /// <summary>
        /// Defines a 64-bit displacement
        /// </summary>
        /// <param name="src">The displacement magnitude</param>
        [MethodImpl(Inline), Op]
        public static Disp64 disp64(long src)
            => new Disp64(src);

        /// <summary>
        /// Computs a 64-bit displacement from specified source bytes
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The offset to begin displacement extraction</param>
        [MethodImpl(Inline), Op]
        public static Disp64 disp64(BinaryCode src, byte offset)
            => i64(slice(src.View, offset));

        /// <summary>
        /// Computes a 64-bit displacement relative to a specified instruction pointer and target address
        /// </summary>
        /// <param name="ip">The instruction pointer address</param>
        /// <param name="dst">The target address</param>
        [MethodImpl(Inline), Op]
        public static Disp64 disp64(MemoryAddress ip, MemoryAddress dst)
            => disp64((long)dst - (long)ip);
    }
}