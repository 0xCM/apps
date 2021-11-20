//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct AsmDisp
    {
        /// <summary>
        /// Defines an IP offset relative to a specified base address, instruction size and target address
        /// </summary>
        /// <param name="base">The base address</param>
        /// <param name="size">The size, in bytes, of the call/branch/jmp instruction</param>
        /// <param name="dst">The call/branch/jmp target</param>
        [MethodImpl(Inline), Op]
        public static long disp(MemoryAddress src, byte fxSize, MemoryAddress dst)
            => (long)(dst - (src + fxSize));

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

        /// <summary>
        /// Defines a 16-bit displacement
        /// </summary>
        /// <param name="src">The displacement magnitude</param>
        [MethodImpl(Inline), Op]
        public static Disp16 disp16(short src)
            => new Disp16(src);

        /// <summary>
        /// Defines a 16-bit displacement
        /// </summary>
        /// <param name="src">The displacement magnitude</param>
        [MethodImpl(Inline), Op]
        public static Disp16 disp16(int src)
            => new Disp16((short)src);

        /// <summary>
        /// Defines a 16-bit displacement
        /// </summary>
        /// <param name="src">The displacement magnitude</param>
        [MethodImpl(Inline), Op]
        public static Disp16 disp16(long src)
            => new Disp16((short)src);

        /// <summary>
        /// Computes a 16-bit displacement relative to a specified instruction pointer and target address
        /// </summary>
        /// <param name="ip">The instruction pointer address</param>
        /// <param name="dst">The target address</param>
        [MethodImpl(Inline), Op]
        public static Disp16 disp16(MemoryAddress ip, MemoryAddress dst)
            => disp16((long)dst - (long)ip);

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