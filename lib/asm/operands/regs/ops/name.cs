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
    using static RegClasses;

    partial struct AsmRegs
    {
        [MethodImpl(Inline), Op]
        public static AsmRegName name(DbClass k, RegIndexCode index)
        {
            const byte RegLength = 3;
            const string Data = "db0db1db2db3db4db5db6db7";
            var i0 = (uint)index*RegLength;
            return FixedChars.txt(n7,slice(text.chars(Data), i0, RegLength));
        }

        [MethodImpl(Inline), Op]
        public static AsmRegName name(MmxClass k, RegIndexCode index)
        {
            const byte RegLength = 3;
            const string Data = "mm0mm1mm2mm3mm4mm5m6mm7";
            var i0 = (uint)index*RegLength;
            return FixedChars.txt(n7,slice(text.chars(Data), i0, RegLength));
        }

        [MethodImpl(Inline), Op]
        public static AsmRegName name(CrClass k, RegIndexCode index)
        {
            const byte RegLength = 3;
            const string Data = "cr0cr1cr2cr3cr4cr5cr6cr7";
            var i0 = (uint)index*RegLength;
            return FixedChars.txt(n7,slice(text.chars(Data), i0, RegLength));
        }

        [MethodImpl(Inline), Op]
        public static AsmRegName name(XmmClass k, RegIndexCode index)
        {
            const byte RegLength = 5;
            const string Data = "xmm0 xmm1 xmm2 xmm3 xmm4 xmm5 xmm6 xmm7 xmm8 xmm9 xmm10xmm11xmm12xmm13xmm14xmm15xmm16xmm17xmm18xmm19xmm20xmm21xmm22xmm23xmm24xmm25xmm26xmm27xmm28xmm29xmm30xmm31";
            var i0 = (uint)index*RegLength;
            return FixedChars.txt(n7,slice(text.chars(Data), i0, RegLength));
        }

        [MethodImpl(Inline), Op]
        public static AsmRegName name(YmmClass k, RegIndexCode index)
        {
            const byte RegLength = 5;
            const string Data = "ymm0 ymm1 ymm2 ymm3 ymm4 ymm5 ymm6 ymm7 ymm8 ymm9 ymm10ymm11ymm12ymm13ymm14ymm15ymm16ymm17ymm18ymm19ymm20ymm21ymm22ymm23ymm24ymm25ymm26ymm27ymm28ymm29ymm30ymm31";
            var i0 = (uint)index*RegLength;
            return FixedChars.txt(n7,slice(text.chars(Data), i0, RegLength));
        }

        [MethodImpl(Inline), Op]
        public static AsmRegName name(ZmmClass k, RegIndexCode index)
        {
            const byte RegLength = 5;
            const string Data = "zmm0 zmm1 zmm2 zmm3 zmm4 zmm5 zmm6 zmm7 zmm8 zmm9 zmm10zmm11zmm12zmm13zmm14zmm15zmm16zmm17zmm18zmm19zmm20zmm21zmm22zmm23zmm24zmm25zmm26zmm27zmm28zmm29zmm30zmm31";
            var i0 = (uint)index*RegLength;
            return FixedChars.txt(n7,slice(text.chars(Data), i0, RegLength));
        }

        [MethodImpl(Inline), Op]
        public static AsmRegName name(MaskClass k, RegIndexCode index)
        {
            const byte RegLength = 2;
            const string Data = "k0k1k2k3k4k5k6k7";
            var i0 = (ushort)((uint)index*RegLength);
            return FixedChars.txt(n7,slice(text.chars(Data), i0, RegLength));
        }

        [MethodImpl(Inline), Op]
        public static AsmRegName name(GpClass k, RegIndexCode index, NativeSizeCode width)
        {
            const byte RegLength = 4;
            const string R0 = "rax eax ax  al  ";
            const string R1 = "rcx ecx cx  cl  ";
            const string R2 = "rdx edx dx  dl  ";
            const string R3 = "rbx ebx bx  bl  ";
            const string R4 = "rsp esp sp  spl ";
            const string R5 = "rbp ebp bp  bpl ";
            const string R6 = "rsi esi si  sil ";
            const string R7 = "rdi edi di  dil ";
            const string R8 = "r8  r8d r8w r8b ";
            const string R9 = "r9  r9d r9w r9b ";
            const string R10 = "r10 r10dr10wr10b";
            const string R11 = "r11 r11dr11wr11b";
            const string R12 = "r12 r12dr12wr12b";
            const string R13 = "r13 r13dr13wr13b";
            const string R14 = "r14 r14dr14wr14b";
            const string R15 = "r15 r15dr15wr15b";
            const string Data = R0 + R1 + R2 + R3 + R4 + R5 + R6 + R7 + R8 + R9 + R10 + R11 + R12 + R13 + R14 + R15;
            var data = 0ul;
            var i0 = offsset(k, index, width);
            return FixedChars.txt(n7, slice(text.chars(Data), i0, RegLength));
        }

        public static AsmRegName name<T>(T src)
            where T : unmanaged, IRegOp
        {
            switch(src.RegClassCode)
            {
                case RegClassCode.GP:
                    return name(Gp, src.Index, (NativeSizeCode)(u16(src) & 0b111));
                case RegClassCode.XMM:
                    return name(Xmm, src.Index);
                case RegClassCode.YMM:
                    return name(Ymm, src.Index);
                case RegClassCode.ZMM:
                    return name(Zmm, src.Index);
                case RegClassCode.MASK:
                    return name(KReg, src.Index);
            }
            return text7.Empty;
        }

        [Op]
        public static AsmRegName name(RegOp src)
        {
            switch(src.RegClassCode)
            {
                case RegClassCode.GP:
                    return name(Gp, src.Index, (NativeSizeCode)(src.Bitfield & 0b111));
                case RegClassCode.XMM:
                    return name(Xmm, src.Index);
                case RegClassCode.YMM:
                    return name(Ymm, src.Index);
                case RegClassCode.ZMM:
                    return name(Zmm, src.Index);
                case RegClassCode.MASK:
                    return name(KReg, src.Index);
            }
            return text7.Empty;
        }

        [MethodImpl(Inline), Op]
        static ushort offsset(GpClass k, RegIndexCode index, NativeSizeCode width)
        {
            const byte RegLength = 4;
            const byte RowLength = 4*RegLength;
            var row = (uint)((uint)index*RowLength);
            var col = z32;
            if(width == NativeSizeCode.W64)
                col = 0;
            else if(width == NativeSizeCode.W32)
                col = 4;
            else if(width == NativeSizeCode.W16)
                col = 8;
            else
                col = 12;

            return (ushort)(row + col);
        }
    }
}