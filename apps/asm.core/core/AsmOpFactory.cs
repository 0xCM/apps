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

        [MethodImpl(Inline)]
        public static mem<T> mem<T>(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            where T : unmanaged, IMemOp<T>
                => new mem<T>(@base, index,scale, disp);

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

        [MethodImpl(Inline), Op]
        public static xCr xCr(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static NearPtr nearptr(MemoryAddress address)
            => new NearPtr(address);
    }
}