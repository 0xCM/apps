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
    using G = AsmOperands.r8;
    using K = AsmRegTokens.Gp8Reg;
    using api = AsmRegs;

    partial struct AsmOperands
    {
        public readonly struct r8 : IRegOp8<r8>
        {
            public RegIndexCode Index {get;}

            [MethodImpl(Inline)]
            public r8(RegIndexCode index)
            {
                Index = index;
            }

            public NativeSize Size
            {
                [MethodImpl(Inline)]
                get => NativeSizeCode.W8;
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

            public string Format()
                => ((K)Index).ToString();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator RegOp(G src)
                => api.reg(src.Size, src.RegClassCode, src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(G src)
                => (K)src.Index;

            [MethodImpl(Inline)]
            public static implicit operator I(G src)
                => src.Index;

            [MethodImpl(Inline)]
            public static implicit operator G(I src)
                => new G(src);

            [MethodImpl(Inline)]
            public static implicit operator G(K src)
                => new G((I)src);

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

        public readonly struct al : IRegOp8<al>
        {
            public I Index => I.r0;

            public static implicit operator r8(al src)
                => new r8(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(al src)
                => (K)src.Index;
        }

        public struct cl : IRegOp8<cl>
        {
            public I Index => I.r1;

            [MethodImpl(Inline)]
            public static implicit operator G(cl src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(cl src)
                => (K)src.Index;
        }

        public struct dl : IRegOp8<dl>
        {
            public I Index => I.r2;

            [MethodImpl(Inline)]
            public static implicit operator G(dl src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(dl src)
                => (K)src.Index;
        }

        public struct bl : IRegOp8<bl>
        {
            public I Index => I.r3;

            [MethodImpl(Inline)]
            public static implicit operator G(bl src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(bl src)
                => (K)src.Index;
        }

        public struct sil : IRegOp8<sil>
        {
            public I Index => I.r4;

            [MethodImpl(Inline)]
            public static implicit operator G(sil src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(sil src)
                => (K)src.Index;
        }

        public struct dil : IRegOp8<dil>
        {
            public I Index => I.r5;

            [MethodImpl(Inline)]
            public static implicit operator G(dil src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(dil src)
                => (K)src.Index;
        }

        public struct spl : IRegOp8<spl>
        {
            public I Index => I.r6;

            [MethodImpl(Inline)]
            public static implicit operator G(spl src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(spl src)
                => (K)src.Index;
        }

        public struct bpl : IRegOp8<bpl>
        {
            public I Index => I.r7;


            [MethodImpl(Inline)]
            public static implicit operator G(bpl src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(bpl src)
                => (K)src.Index;
        }

        public struct r8b : IRegOp8<r8b>
        {
            public I Index => I.r8;

            [MethodImpl(Inline)]
            public static implicit operator G(r8b src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(r8b src)
                => (K)src.Index;
        }

        public struct r9b : IRegOp8<r9b>
        {
            public I Index => I.r9;

            [MethodImpl(Inline)]
            public static implicit operator G(r9b src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(r9b src)
                => (K)src.Index;
        }

        public struct r10b : IRegOp8<r10b>
        {
            public I Index => I.r10;

            [MethodImpl(Inline)]
            public static implicit operator G(r10b src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(r10b src)
                => (K)src.Index;
        }

        public struct r11b : IRegOp8<r11b>
        {
            public I Index => I.r11;

            [MethodImpl(Inline)]
            public static implicit operator G(r11b src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(r11b src)
                => (K)src.Index;
        }

        public struct r12b : IRegOp8<r12b>
        {
            public I Index => I.r12;

            [MethodImpl(Inline)]
            public static implicit operator G(r12b src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(r12b src)
                => (K)src.Index;
        }

        public struct r13b : IRegOp8<r13b>
        {
            public I Index => I.r13;

            [MethodImpl(Inline)]
            public static implicit operator G(r13b src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(r13b src)
                => (K)src.Index;
        }

        public struct r14b : IRegOp8<r14b>
        {
            public I Index => I.r14;

            [MethodImpl(Inline)]
            public static implicit operator G(r14b src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(r14b src)
                => (K)src.Index;
        }

        public struct r15b : IRegOp8<r15b>
        {
            public I Index => I.r15;

            [MethodImpl(Inline)]
            public static implicit operator G(r15b src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(r15b src)
                => (K)src.Index;
        }
    }
}