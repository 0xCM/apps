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
    using static AsmRegTokens;

    partial struct Ccv
    {
        [ApiHost("ccv.win64")]
        public readonly struct Win64 : ICallCv<Win64>
        {
            public CcvKind Kind => CcvKind.WinX64;

            [MethodImpl(Inline)]
            public static implicit operator Win64(CcvKind src)
                => default;

            [MethodImpl(Inline)]
            public static implicit operator CcvKind(Win64 src)
                => src.Kind;

            [MethodImpl(Inline), Op]
            public static ReadOnlySpan<Gp8Reg> regs(W8 w)
                => recover<Gp8Reg>(slice(WinX64Data,0,Win64MaxReg + 1));

            [MethodImpl(Inline), Op]
            public static ReadOnlySpan<Gp16Reg> regs(W16 w)
                => recover<Gp16Reg>(slice(WinX64Data,0,Win64MaxReg + 1));

            [MethodImpl(Inline), Op]
            public static ReadOnlySpan<Gp32Reg> regs(W32 w)
                => recover<Gp32Reg>(slice(WinX64Data,0,Win64MaxReg + 1));

            [MethodImpl(Inline), Op]
            public static ReadOnlySpan<Gp64Reg> regs(W64 w)
                => recover<Gp64Reg>(slice(WinX64Data,0,Win64MaxReg + 1));

            [MethodImpl(Inline), Op]
            public static ref readonly Gp8Reg reg(W8 w, byte index)
                => ref skip(regs(w), index);

            [MethodImpl(Inline), Op]
            public static ref readonly Gp16Reg reg(W16 w, byte index)
                => ref skip(regs(w), index);

            [MethodImpl(Inline), Op]
            public static ref readonly Gp32Reg reg(W32 w, byte index)
                => ref skip(regs(w), index);

            [MethodImpl(Inline), Op]
            public static ref readonly Gp64Reg reg(W64 w, byte index)
                => ref skip(regs(w), index);

            // [MethodImpl(Inline), Op]
            // public static ref readonly v4<Gp8Reg> slots(W8 w)
            //     => ref first(recover<v4<Gp8Reg>>(bytes(regs(w))));

            // [MethodImpl(Inline), Op]
            // public static ref readonly v4<Gp16Reg> slots(W16 w)
            //     => ref first(recover<v4<Gp16Reg>>(bytes(regs(w))));

            // [MethodImpl(Inline), Op]
            // public static ref readonly v4<Gp32Reg> slots(W32 w)
            //     => ref first(recover<v4<Gp32Reg>>(bytes(regs(w))));

            // [MethodImpl(Inline), Op]
            // public static ref readonly v4<Gp64Reg> slots(W64 w)
            //     => ref first(recover<v4<Gp64Reg>>(bytes(regs(w))));

            [MethodImpl(Inline), Op]
            public static bit slot(Win64 cc, byte index, out Gp8Reg dst)
            {
                var i = math.and(index,Win64MaxReg);
                bit valid = i <= Win64MaxReg;
                dst = reg(w8,i);
                return valid;
            }

            [MethodImpl(Inline), Op]
            public static bit slot(Win64 cc, byte index, out Gp16Reg dst)
            {
                var i = math.and(index,Win64MaxReg);
                bit valid = i <= Win64MaxReg;
                dst = reg(w16,i);
                return valid;
            }

            [MethodImpl(Inline), Op]
            public static bit slot(Win64 cc, byte index, out Gp32Reg dst)
            {
                var i = math.and(index,Win64MaxReg);
                bit valid = i <= Win64MaxReg;
                dst = reg(w32,i);
                return valid;
            }

            [MethodImpl(Inline), Op]
            public static bit slot(Win64 cc, byte index, out Gp64Reg dst)
            {
                var i = math.and(index,Win64MaxReg);
                bit valid = i <= Win64MaxReg;
                dst = reg(w64,i);
                return valid;
            }

            const byte CcvSize = 64;

            const byte Win64MaxReg = 3;

            // rax=0, rcx=1, rdx=2, rbx=3, rsp=4, rbp=5, rsi=6, rdi=7, r8=8, r9=9, r10=10, r11, r12, r13, r14, r15
            static ReadOnlySpan<byte> WinX64Data
                => new byte[CcvSize]{
                    1,2,8,9,0,0,0,0,
                    0,0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,0,
                    32,33,34,35,36,37,38,39,
                    40,41,42,43,44,45,46,47,
                    48,49,50,51,52,53,54,56,
                    57,58,59,60,61,62,63,64};
        }
    }
}