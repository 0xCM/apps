//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{

    using static core;

    [ApiHost]
    public readonly struct AsmValues
    {
        /// <summary>
        /// Computes an 8-bit displacement from specified source bytes
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The offset to begin displacement extraction</param>
        [MethodImpl(Inline), Op]
        public static Disp8 disp8(BinaryCode src, byte offset)
            => i8(slice(src.View, offset));

        /// <summary>
        /// Computes an 8-bit displacement relative to a specified instruction pointer and target address
        /// </summary>
        /// <param name="rip">The instruction pointer address</param>
        /// <param name="dst">The target address</param>
        [MethodImpl(Inline), Op]
        public static Disp8 disp8(MemoryAddress rip, MemoryAddress dst)
            => new Disp8((sbyte)((long)dst - (long)rip));

        /// <summary>
        /// Computes a 16-bit displacement relative to a specified instruction pointer and target address
        /// </summary>
        /// <param name="rip">The instruction pointer address</param>
        /// <param name="dst">The target address</param>
        [MethodImpl(Inline), Op]
        public static Disp16 disp16(MemoryAddress rip, MemoryAddress dst)
            => new Disp16((short)((long)dst - (long)rip));

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
        /// <param name="rip">The instruction pointer address</param>
        /// <param name="dst">The target address</param>
        [MethodImpl(Inline), Op]
        public static Disp32 disp32(MemoryAddress rip, MemoryAddress dst)
            => new Disp32((int)((long)dst - (long)rip));

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
        /// <param name="rip">The instruction pointer address</param>
        /// <param name="dst">The target address</param>
        [MethodImpl(Inline), Op]
        public static Disp64 disp64(MemoryAddress rip, MemoryAddress dst)
            => new Disp64((long)dst - (long)rip);

        /// <summary>
        /// Defines an IP offset relative to a specified base address, instruction size and target address
        /// </summary>
        /// <param name="base">The base address</param>
        /// <param name="size">The size, in bytes, of the call/branch/jmp instruction</param>
        /// <param name="dst">The call/branch/jmp target</param>
        [MethodImpl(Inline), Op]
        public static Disp64 disp64(MemoryAddress src, byte instsize, MemoryAddress dst)
            => (long)(dst - (src + instsize));


        [MethodImpl(Inline), Op]
        public static Disp disp(long value, NativeSize size)
            => new Disp(value,size);

        [MethodImpl(Inline), Op]
        public static Disp disp(long value, BitWidth size)
            => new Disp(value, NativeSize.code(size));

        [Op]
        public static Imm imm(NativeSize size, bool signed, ulong value)
        {
            var kind = ImmKind.None;
            switch(size.Code)
            {
                case NativeSizeCode.W8:
                    kind = signed ? ImmKind.Imm8i : ImmKind.Imm8;
                break;
                case NativeSizeCode.W16:
                    kind = signed ? ImmKind.Imm16i : ImmKind.Imm16;
                break;
                case NativeSizeCode.W32:
                    kind = signed ? ImmKind.Imm32i : ImmKind.Imm32;
                break;
                case NativeSizeCode.W64:
                    kind = signed ? ImmKind.Imm64i : ImmKind.Imm64;
                break;
            }
            return new Imm(kind, value);
        }

        [Op]
        public static Imm imm(NativeSize size, long value)
        {
            var kind = ImmKind.None;
            switch(size.Code)
            {
                case NativeSizeCode.W8:
                    kind = ImmKind.Imm8i;
                break;
                case NativeSizeCode.W16:
                    kind = ImmKind.Imm16i;
                break;
                case NativeSizeCode.W32:
                    kind = ImmKind.Imm32i;
                break;
                case NativeSizeCode.W64:
                    kind = ImmKind.Imm64i;
                break;
            }
            return new Imm(kind, value);
        }

        [Op]
        public static Imm imm(NativeSize size, ulong value)
        {
            var kind = ImmKind.None;
            switch(size.Code)
            {
                case NativeSizeCode.W8:
                    kind = ImmKind.Imm8;
                break;
                case NativeSizeCode.W16:
                    kind = ImmKind.Imm16;
                break;
                case NativeSizeCode.W32:
                    kind = ImmKind.Imm32;
                break;
                case NativeSizeCode.W64:
                    kind = ImmKind.Imm64;
                break;
            }
            return new Imm(kind, value);
        }

        [MethodImpl(Inline), Op]
        public static Imm imm(ImmKind kind, ulong value)
            => new Imm(kind, value);

        /// <summary>
        /// Defines an 8-bit immediate operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static imm8 imm8(byte src)
            => new imm8(src);

        /// <summary>
        /// Defines a 16-bit immediate operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static imm16 imm16(ushort src)
            => new imm16(src);

        /// <summary>
        /// Defines a 32-bit immediate operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static imm32 imm32(uint src)
            => new imm32(src);

        /// <summary>
        /// Defines a 64-bit immediate operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static imm64 imm64(ulong src)
            => new imm64(src);
    }
}