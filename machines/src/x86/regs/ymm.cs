//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 210210
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86.Regs
{
    using System;
    using System.Runtime.CompilerServices;

    using Asm;

    using static Root;

    using K = Asm.RegKind;
    using T = Cell256;

    public readonly struct ymm : IYmmReg
    {
        public Cell256 Content {get;}

        public RegKind RegKind {get;}

        [MethodImpl(Inline)]
        public ymm(Cell256 value, RegKind kind)
        {
            Content = value;
            RegKind = kind;
        }

        [MethodImpl(Inline)]
        public static implicit operator Cell256(ymm src)
            => src.Content;
    }

    public readonly struct Ymm<R> : IReg256<Ymm<R>,Cell256>
        where R : unmanaged, IReg
    {
        public Cell256 Content {get;}

        [MethodImpl(Inline)]
        public Ymm(Cell256 value)
            => Content = value;

        public RegKind RegKind
            => default;

        [MethodImpl(Inline)]
        public static implicit operator ymm(Ymm<R> src)
            => new ymm(src.Content, src.RegKind);
    }

    public readonly struct ymm0 : IReg256<ymm0,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm0(T src)
            => Content = src;

        public K RegKind => K.XMM0;
    }

    public readonly struct ymm1 : IReg256<ymm1,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm1(T src)
            => Content = src;

        public K RegKind => K.XMM1;
    }

    public readonly struct ymm2 : IReg256<ymm2,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm2(T src)
            => Content = src;

        public K RegKind => K.XMM2;
    }

    public readonly struct ymm3 : IReg256<ymm3,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm3(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM3;
    }

    public readonly struct ymm4 : IYmmReg<ymm4,N4>
    {
        public T Content {get;}


        [MethodImpl(Inline)]
        public ymm4(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM4;
    }

    public readonly struct ymm5 : IYmmReg<ymm5,N5>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm5(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM5;
    }

    public readonly struct ymm6 : IYmmReg<ymm6,N6>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm6(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM6;
    }

    public readonly struct ymm7 : IYmmReg<ymm7,N7>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm7(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM7;
    }

    public readonly struct ymm8 : IYmmReg<ymm8,N8>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm8(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM8;
    }

    public readonly struct ymm9 : IYmmReg<ymm9,N9>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm9(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM9;
    }

    public readonly struct ymm10 : IYmmReg<ymm10,N10>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm10(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM10;
    }

    public readonly struct ymm11 : IYmmReg<ymm11,N11>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm11(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM11;
    }

    public readonly struct ymm12 : IYmmReg<ymm12,N12>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm12(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM12;
    }

    public readonly struct ymm13 : IYmmReg<ymm13,N13>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm13(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM13;
    }

    public readonly struct ymm14 : IYmmReg<ymm14,N14>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm14(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM14;
    }

    public readonly struct ymm15 : IYmmReg<ymm15,N15>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm15(T value)
        {
            Content = value;
        }
        public K RegKind => K.XMM15;
    }

    public readonly struct ymm16 : IYmmReg<ymm16,N16>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm16(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM16;

    }

    public readonly struct ymm17 : IYmmReg<ymm17,N17>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm17(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM17;
    }

    public readonly struct ymm18 : IYmmReg<ymm18,N18>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm18(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM18;
    }

    public readonly struct ymm19 : IYmmReg<ymm19,N19>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm19(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM19;
    }

    public readonly struct ymm20 : IYmmReg<ymm20,N20>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm20(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM20;
    }

    public readonly struct ymm21 : IYmmReg<ymm21,N21>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm21(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM21;
    }

    public readonly struct ymm22 : IYmmReg<ymm22,N22>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm22(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM22;
    }

    public readonly struct ymm23 : IYmmReg<ymm23,N23>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm23(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM23;
    }

    public readonly struct ymm24 : IYmmReg<ymm24,N24>
    {
        public T Content {get;}


        [MethodImpl(Inline)]
        public ymm24(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM24;
    }

    public readonly struct ymm25 : IYmmReg<ymm25,N25>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm25(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM25;
    }

    public readonly struct ymm26 : IYmmReg<ymm26,N26>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm26(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM26;
    }

    public readonly struct ymm27 : IYmmReg<ymm27,N27>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm27(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM27;
    }

    public readonly struct ymm28 : IYmmReg<ymm28,N28>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm28(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM28;
    }

    public readonly struct ymm29 : IYmmReg<ymm29,N29>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm29(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM29;
    }

    public readonly struct ymm30 : IYmmReg<ymm30,N30>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm30(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM30;
    }

    public readonly struct ymm31 : IYmmReg<ymm31,N31>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ymm31(T value)
        {
            Content = value;
        }

        public K RegKind => K.XMM31;
    }
}