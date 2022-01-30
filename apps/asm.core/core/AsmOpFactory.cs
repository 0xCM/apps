//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Operands;

    using static core;

    [ApiHost]
    public readonly struct AsmOpFactory
    {
        [MethodImpl(Inline), Op]
        public static rK rK(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static RegOp reg(NativeSizeCode width, RegClassCode @class, RegIndexCode r)
            => AsmRegs.reg(width, @class,r);

        [MethodImpl(Inline), Op]
        public static RegOp reg(RegKind kind)
            => AsmRegs.reg(kind);

        [MethodImpl(Inline), Op]
        public static RegOp reg(in AsmOperand src)
            => AsmRegs.reg(src);

        [MethodImpl(Inline), Op]
        public static r8 r8(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static r16 r16(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static r32 r32(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static r64 r64(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static xmm r128(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static ymm r256(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static zmm r512(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static rCr rCr(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static rDb rDb(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static RegMask regmask(RegOp target, RegIndex mask, RegMaskKind kind)
            => new RegMask(target,mask,kind);

        [MethodImpl(Inline), Op]
        public static FarPtr farptr(Address16 selector, long offset)
            => new FarPtr(selector,offset);

        [MethodImpl(Inline), Op]
        public static Disp disp(long value, NativeSize size)
            => new Disp(value,size);

        [MethodImpl(Inline), Op]
        public static Disp disp(long value, BitWidth size)
            => new Disp(value, NativeSize.code(size));

        [MethodImpl(Inline)]
        public static mem<T> mem<T>(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            where T : unmanaged, IMemOp<T>
                => new mem<T>(@base, index,scale, disp);

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

        /// <summary>
        /// Defines an IP offset relative to a specified base address, instruction size and target address
        /// </summary>
        /// <param name="base">The base address</param>
        /// <param name="size">The size, in bytes, of the call/branch/jmp instruction</param>
        /// <param name="dst">The call/branch/jmp target</param>
        [MethodImpl(Inline), Op]
        public static Disp64 disp64(MemoryAddress src, byte fxSize, MemoryAddress dst)
            => (long)(dst - (src + fxSize));

        [MethodImpl(Inline), Op]
        public static m8 mem8(RegOp @base)
            => new m8(@base, RegOp.Invalid, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m8 mem8(AsmAddress address)
            => new m8(address);

        [MethodImpl(Inline), Op]
        public static m8 mem8(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m8(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m16 mem16(RegOp @base)
            => new m16(@base, RegOp.Invalid, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m16 mem16(AsmAddress address)
            => new m16(address);

        [MethodImpl(Inline), Op]
        public static m16 mem16(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m16(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m32 mem32(RegOp @base)
            => new m32(@base, RegOp.Invalid, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m32 mem32(AsmAddress address)
            => new m32(address);

        [MethodImpl(Inline), Op]
        public static m32 mem32(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m32(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m64 mem64(RegOp @base)
            => new m64(@base, RegOp.Invalid, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m64 mem64(AsmAddress address)
            => new m64(address);

        [MethodImpl(Inline), Op]
        public static m64 mem64(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m64(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m128 mem128(RegOp @base)
            => new m128(@base, RegOp.Invalid, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m128 mem128(AsmAddress address)
            => new m128(address);

        [MethodImpl(Inline), Op]
        public static m128 mem128(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m128(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m256 mem256(RegOp @base)
            => new m256(@base, RegOp.Invalid, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m256 mem256(AsmAddress address)
            => new m256(address);

        [MethodImpl(Inline), Op]
        public static m256 mem256(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m256(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m512 mem512(RegOp @base)
            => new m512(@base, RegOp.Invalid, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m512 mem512(AsmAddress address)
            => new m512(address);

        [MethodImpl(Inline), Op]
        public static m512 mem512(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m512(@base,index,scale,disp);

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

        [MethodImpl(Inline), Op]
        public static xCr xCr(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static NearPtr nearptr(MemoryAddress address)
            => new NearPtr(address);

    }
}