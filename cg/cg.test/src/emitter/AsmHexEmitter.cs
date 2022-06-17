//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static Hex8Kind;
    using Operands;

    public class AsmHexEmitter : AppService<AsmHexEmitter>
    {
        /// <summary>
        /// (AND AL, imm8)[24 ib]
        /// </summary>
        /// <param name="r"></param>
        /// <param name="imm8"></param>
        [MethodImpl(Inline), Op]
        public void and(al r, Imm8 imm8, AsmHexWriter dst)
            => dst.Write(x24,imm8);

        /// <summary>
        /// 20 /r | AND r/m8, r8 | 0x20 MOD[0b11] REG[rrr] RM[nnn]
        /// </summary>
        /// <param name="r0">REG0=GPR8_B():rw</param>
        /// <param name="r1">REG1=GPR8_R():r</param>
        public static void and(r8 r0, r8 r1, AsmHexWriter dst)
        {
            var modrm = ModRm.init();
            modrm.Mod((uint2)0b11);
            modrm.Reg(r1);
            modrm.Rm(r0);
            dst.Write(x20, modrm);
        }

        [MethodImpl(Inline), Op]
        public static void jo(Hex8 cb, AsmHexWriter dst)
            => dst.Write(x70, cb);

        [MethodImpl(Inline), Op]
        public static void jo(Hex32 cd, AsmHexWriter dst)
            => dst.Write(x70, x86, cd);

        [MethodImpl(Inline), Op]
        public static void encode(Hex8 a0, Imm8 a1, AsmHexWriter dst)
            => dst.Write(a0,a1);

        [MethodImpl(Inline), Op]
        public static void encode(RexPrefix a0, Hex8 a1, Imm64 a2, AsmHexWriter dst)
            => dst.Write(a0,a1,a2);

        [MethodImpl(Inline), Op]
        public static void encode(Rip a0, Jcc8 a1, AsmHexWriter dst)
            => dst.Write(a1.JccCode, AsmRel8.target(a0, a1.Disp));

        [MethodImpl(Inline)]
        public static byte pack<A>(A a, uint offset, Span<byte> dst)
            where A : unmanaged
        {
            var i0 = offset;
            var i = i0;
            @as<A>(seek(dst,offset)) = a;
            i += size<A>();
            return (byte)(i - i0);
        }

        [MethodImpl(Inline)]
        public static byte pack<A,B>(A a, B b, uint offset, Span<byte> dst)
            where A : unmanaged
            where B : unmanaged
        {
            var i0 = offset;
            var i = i0;
            @as<A>(seek(dst,i)) = a;
            i += size<A>();
            @as<B>(seek(dst, i)) = b;
            i += size<B>();
            return (byte)(i - i0);
        }

        [MethodImpl(Inline)]
        public static byte pack<A,B>(A a, B b, Span<byte> dst)
            where A : unmanaged
            where B : unmanaged
                => pack(a,b,0u,dst);

        [MethodImpl(Inline)]
        public static byte pack<A,B,C>(A a, B b, C c, uint offset, Span<byte> dst)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
        {
            var i0 = offset;
            var i = i0;
            @as<A>(seek(dst,i)) = a;
            i += size<A>();
            @as<B>(seek(dst, i)) = b;
            i += size<B>();
            @as<C>(seek(dst, i)) = c;
            i += size<C>();
            return (byte)(i - i0);
        }

        [MethodImpl(Inline)]
        public static byte pack<A,B,C>(A a, B b, C c, Span<byte> dst)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
                => pack(a,b,c,0u,dst);

        [MethodImpl(Inline)]
        public static byte pack<A,B,C,D>(A a, B b, C c, D d, uint offset, Span<byte> dst)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
            where D : unmanaged
        {
            var i0 = offset;
            var i = i0;
            @as<A>(seek(dst,i)) = a;
            i += size<A>();
            @as<B>(seek(dst, i)) = b;
            i += size<B>();
            @as<C>(seek(dst, i)) = c;
            i += size<C>();
            @as<D>(seek(dst, i)) = d;
            i += size<D>();
            return (byte)(i - i0);
        }

        [MethodImpl(Inline)]
        public static byte pack<A,B,C,D>(A a, B b, C c, D d, Span<byte> dst)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
            where D : unmanaged
                => pack(a,b,c,d,0u,dst);
    }
}