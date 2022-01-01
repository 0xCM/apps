//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using I = RegIndexCode;
    using G = xCr;
    using K = AsmRegTokens.XControlReg;
    using api = AsmRegs;

    public readonly struct xCr : IRegOp64<xCr>
    {
        public RegIndexCode Index {get;}

        [MethodImpl(Inline)]
        public xCr(I index)
        {
            Index = index;
        }

        public string Format()
            => ((K)Index).ToString();

        public override string ToString()
            => Format();

        public NativeSizeCode WidthCode
        {
            [MethodImpl(Inline)]
            get => NativeSizeCode.W64;
        }

        public RegClassCode RegClassCode
        {
            [MethodImpl(Inline)]
            get => RegClassCode.XCR;
        }

        public RegWidth RegWidth
        {
            [MethodImpl(Inline)]
            get => NativeSizeCode.W64;
        }

        public RegClass RegClass
        {
            [MethodImpl(Inline)]
            get => RegClassCode;
        }


        [MethodImpl(Inline)]
        public AsmOperand Untyped()
            => new AsmOperand(this);

        [MethodImpl(Inline)]
        public static implicit operator RegOp(G src)
            => api.reg(src.WidthCode, src.RegClassCode, src.Index);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(G src)
            => src.Untyped();

        [MethodImpl(Inline)]
        public static implicit operator K(G src)
            => (K)src.Index;

        [MethodImpl(Inline)]
        public static implicit operator G(K src)
            => new G((I)src);

        [MethodImpl(Inline)]
        public static implicit operator G(uint4 src)
            => new G((I)(byte)src);

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
    }
}