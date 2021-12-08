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
        /// Defines an 8-bit displacement
        /// </summary>
        /// <param name="src">The displacement magnitude</param>
        [MethodImpl(Inline), Op]
        public static Disp8 disp8(sbyte src)
            => new Disp8(src);

        /// <summary>
        /// Defines an 8-bit displacement
        /// </summary>
        /// <param name="src">The displacement magnitude</param>
        [MethodImpl(Inline), Op]
        public static Disp8 disp8(short src)
            => new Disp8((sbyte)src);

        /// <summary>
        /// Defines an 8-bit displacement
        /// </summary>
        /// <param name="src">The displacement magnitude</param>
        [MethodImpl(Inline), Op]
        public static Disp8 disp8(int src)
            => new Disp8((sbyte)src);

        /// <summary>
        /// Defines an 8-bit displacement
        /// </summary>
        /// <param name="src">The displacement magnitude</param>
        [MethodImpl(Inline), Op]
        public static Disp8 disp8(long src)
            => new Disp8((sbyte)src);

        /// <summary>
        /// Computs an 8-bit displacement from specified source bytes
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The offset to begin displacement extraction</param>
        [MethodImpl(Inline), Op]
        public static Disp8 disp8(BinaryCode src, byte offset)
            => i8(slice(src.View, offset));

        /// <summary>
        /// Computes an 8-bit displacement relative to a specified instruction pointer and target address
        /// </summary>
        /// <param name="ip">The instruction pointer address</param>
        /// <param name="dst">The target address</param>
        [MethodImpl(Inline), Op]
        public static Disp8 disp8(MemoryAddress ip, MemoryAddress dst)
            => disp8((long)dst - (long)ip);
    }
}