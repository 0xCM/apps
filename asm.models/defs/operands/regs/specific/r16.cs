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
    using G = AsmOperands.r16;
    using K = AsmRegTokens.Gp16Reg;
    using api = AsmRegs;

    partial struct AsmOperands
    {
        public readonly struct r16 : IRegOp16<G>
        {
            public I Index {get;}

            [MethodImpl(Inline)]
            public r16(I index)
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
                get => NativeSizeCode.W16;
            }

            public NativeSizeCode WidthCode
            {
                [MethodImpl(Inline)]
                get => NativeSizeCode.W16;
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
                => api.reg(src.WidthCode, src.RegClassCode, src.Index);

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

        public readonly struct ax : IRegOp16<ax>
        {
            public I Index => I.r0;

            [MethodImpl(Inline)]
            public static implicit operator G(ax src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(ax src)
                => (K)src.Index;
        }

        public struct cx : IRegOp16<cx>
        {
            public I Index => I.r1;

            [MethodImpl(Inline)]
            public static implicit operator G(cx src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(cx src)
                => (K)src.Index;
        }

        public struct dx : IRegOp16<dx>
        {
            public I Index => I.r2;

            [MethodImpl(Inline)]
            public static implicit operator G(dx src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(dx src)
                => (K)src.Index;
        }

        public struct bx : IRegOp16<bx>
        {
            public I Index => I.r3;

            [MethodImpl(Inline)]
            public static implicit operator G(bx src)
                => new(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(bx src)
                => (K)src.Index;
        }

        public struct si : IRegOp16<si>
        {
            public I Index => I.r4;

            [MethodImpl(Inline)]
            public static implicit operator G(si src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(si src)
                => (K)src.Index;
        }

        public struct di : IRegOp16<di>
        {
            public I Index => I.r5;

            [MethodImpl(Inline)]
            public static implicit operator G(di src)
                => new G(src.Index);

            [MethodImpl(Inline)]
            public static implicit operator K(di src)
                => (K)src.Index;
        }

        public struct sp : IRegOp16<sp>
        {
            public I Index => I.r6;

            [MethodImpl(Inline)]
            public static implicit operator G(sp src)
                => new(src.Index);
        }

        public struct bp : IRegOp16<bp>
        {
            public I Index => I.r7;

            [MethodImpl(Inline)]
            public static implicit operator G(bp src)
                => new(src.Index);
        }

        public struct r8w : IRegOp16<r8w>
        {
            public I Index => I.r8;

            [MethodImpl(Inline)]
            public static implicit operator G(r8w src)
                => new(src.Index);
        }

        public struct r9w : IRegOp16<r9w>
        {
            public I Index => I.r9;

            [MethodImpl(Inline)]
            public static implicit operator G(r9w src)
                => new(src.Index);
        }

        public struct r10w : IRegOp16<r10w>
        {
            public I Index => I.r10;

            [MethodImpl(Inline)]
            public static implicit operator G(r10w src)
                => new(src.Index);
        }

        public struct r11w : IRegOp16<r11w>
        {
            public I Index => I.r11;

            [MethodImpl(Inline)]
            public static implicit operator G(r11w src)
                => new(src.Index);
        }

        public struct r12w : IRegOp16<r12w>
        {
            public I Index => I.r12;

            [MethodImpl(Inline)]
            public static implicit operator G(r12w src)
                => new (src.Index);
        }

        public struct r13w : IRegOp16<r13w>
        {
            public I Index => I.r13;

            [MethodImpl(Inline)]
            public static implicit operator G(r13w src)
                => new (src.Index);
        }

        public struct r14w : IRegOp16<r14w>
        {
            public I Index => I.r14;

            [MethodImpl(Inline)]
            public static implicit operator G(r14w src)
                => new (src.Index);
        }

        public struct r15w : IRegOp16<r15w>
        {
            public I Index => I.r15;

            [MethodImpl(Inline)]
            public static implicit operator G(r15w src)
                => new (src.Index);
        }
    }
}