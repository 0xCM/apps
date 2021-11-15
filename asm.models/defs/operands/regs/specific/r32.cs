//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using I = RegIndexCode;
    using G = AsmOperands.r32;
    using K = AsmRegTokens.Gp32Reg;
    using api = AsmRegs;

    partial struct AsmOperands
    {
        public readonly struct r32 : IRegOp32<r32>
        {
            public RegIndexCode Index {get;}

            [MethodImpl(Inline)]
            public r32(RegIndexCode index)
            {
                Index = index;
            }

            public string Format()
                => ((K)Index).ToString();

            public override string ToString()
                => Format();

            public NativeSize Size
            {
                [MethodImpl(Inline)]
                get => NativeSizeCode.W32;
            }

            public RegClassCode RegClassCode
            {
                [MethodImpl(Inline)]
                get => RegClassCode.GP;
            }

            public RegWidth RegWidth
            {
                [MethodImpl(Inline)]
                get => Size;
            }

            public RegClass RegClass
            {
                [MethodImpl(Inline)]
                get => RegClassCode;
            }

            [MethodImpl(Inline)]
            public static implicit operator RegOp(G src)
                => api.reg(src.Size, src.RegClassCode, src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(G src)
                => (K)src.Index;

            [MethodImpl(Inline)]
            public static implicit operator G(K src)
                => new G((I)src);

            [MethodImpl(Inline)]
            public static implicit operator G(I src)
                => new G(src);

            [MethodImpl(Inline)]
            public static implicit operator I(G src)
                => src.Index;

            [MethodImpl(Inline)]
            public static explicit operator byte(G src)
                => (byte)src.Index;

            [MethodImpl(Inline)]
            public static implicit operator G(Sym<K> src)
                => new G((I)src.Kind);

            [MethodImpl(Inline)]
            public static G operator ++(G src)
                => api.next(src);

            [MethodImpl(Inline)]
            public static G operator --(G src)
                => api.prior(src);
        }

        public readonly struct eax : IRegOp32<eax>
        {
            public I Index => I.r0;

            [MethodImpl(Inline)]
            public static implicit operator G(eax src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(eax src)
                => (K)src.Index;
        }

        public struct ecx : IRegOp32<ecx>
        {
            public I Index => I.r1;

            [MethodImpl(Inline)]
            public static implicit operator G(ecx src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(ecx src)
                => (K)src.Index;
        }

        public struct edx : IRegOp32<edx>
        {
            public I Index => I.r2;

            [MethodImpl(Inline)]
            public static implicit operator G(edx src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(edx src)
                => (K)src.Index;
        }

        public struct ebx : IRegOp32<ebx>
        {
            public I Index => I.r3;

            [MethodImpl(Inline)]
            public static implicit operator G(ebx src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(ebx src)
                => (K)src.Index;
        }

        public struct esi : IRegOp32<esi>
        {
            public I Index => I.r4;

            [MethodImpl(Inline)]
            public static implicit operator G(esi src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(esi src)
                => (K)src.Index;
        }

        public struct edi : IRegOp32<edi>
        {
            public I Index => I.r5;

            [MethodImpl(Inline)]
            public static implicit operator G(edi src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(edi src)
                => (K)src.Index;
        }

        public struct esp : IRegOp32<esp>
        {
            public I Index => I.r6;

            [MethodImpl(Inline)]
            public static implicit operator G(esp src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(esp src)
                => (K)src.Index;
        }

        public struct ebp : IRegOp32<ebp>
        {
            public I Index => I.r7;

            [MethodImpl(Inline)]
            public static implicit operator G(ebp src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(ebp src)
                => (K)src.Index;
        }

        public struct r8d : IRegOp32<r8d>
        {
            public I Index => I.r8;

            [MethodImpl(Inline)]
            public static implicit operator G(r8d src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(r8d src)
                => (K)src.Index;
        }

        public struct r9d : IRegOp32<r9d>
        {
            public I Index => I.r9;

            [MethodImpl(Inline)]
            public static implicit operator G(r9d src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(r9d src)
                => (K)src.Index;
        }

        public struct r10d : IRegOp32<r10d>
        {
            public I Index => I.r10;

            [MethodImpl(Inline)]
            public static implicit operator G(r10d src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(r10d src)
                => (K)src.Index;
        }

        public struct r11d : IRegOp32<r11d>
        {
            public I Index => I.r11;

            [MethodImpl(Inline)]
            public static implicit operator G(r11d src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(r11d src)
                => (K)src.Index;
        }

        public struct r12d : IRegOp32<r12d>
        {
            public I Index => I.r12;

            [MethodImpl(Inline)]
            public static implicit operator G(r12d src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(r12d src)
                => (K)src.Index;
        }

        public struct r13d : IRegOp32<r13d>
        {
            public I Index => I.r13;

            [MethodImpl(Inline)]
            public static implicit operator G(r13d src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(r13d src)
                => (K)src.Index;
        }

        public struct r14d : IRegOp32<r14d>
        {
            public I Index => I.r14;

            [MethodImpl(Inline)]
            public static implicit operator G(r14d src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(r14d src)
                => (K)src.Index;
        }

        public struct r15d : IRegOp32<r15d>
        {
            public I Index => I.r15;

            [MethodImpl(Inline)]
            public static implicit operator G(r15d src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(r15d src)
                => (K)src.Index;
        }
    }
}