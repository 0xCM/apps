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
    using T = Cell512;

    public readonly struct zmm : IZmmReg
    {
        public Cell512 Content {get;}

        public RegKind RegKind {get;}

        [MethodImpl(Inline)]
        public zmm(Cell512 value, RegKind kind)
        {
            Content = value;
            RegKind = kind;
        }
    }

    public struct Zmm<R> : IReg512<Zmm<R>,Cell512>
        where R : unmanaged, IReg
    {
        public Cell512 Content {get;}

        [MethodImpl(Inline)]
        public Zmm(Cell512 value)
            => Content = value;
        public RegKind RegKind
            => default(R).RegKind;

        [MethodImpl(Inline)]
        public static implicit operator zmm(Zmm<R> src)
            => new zmm(src.Content, src.RegKind);
    }

    public readonly struct zmm0 : IReg512<zmm0,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm0(T value)
        {
            Content = value;
        }

        public K RegKind
            => K.ZMM0;
    }

    public readonly struct zmm1 : IReg512<zmm1,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm1(T value)
        {
            Content = value;
        }

        public K RegKind
            => K.ZMM1;
    }

    public readonly struct zmm2 : IZmmReg<zmm2,N2>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm2(T value)
        {
            Content = value;
        }

        public K RegKind
            => K.ZMM2;
    }

    public readonly struct zmm3 : IZmmReg<zmm3,N3>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm3(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM3;
    }

    public readonly struct zmm4 : IZmmReg<zmm4,N4>
    {
        public T Content {get;}


        [MethodImpl(Inline)]
        public zmm4(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM4;
    }

    public readonly struct zmm5 : IZmmReg<zmm5,N5>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm5(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM5;
    }

    public readonly struct zmm6 : IZmmReg<zmm6,N6>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm6(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM6;
    }

    public readonly struct zmm7 : IZmmReg<zmm7,N7>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm7(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM7;
    }

    public readonly struct zmm8 : IZmmReg<zmm8,N8>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm8(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM8;
    }

    public readonly struct zmm9 : IZmmReg<zmm9,N9>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm9(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM9;
    }

    public readonly struct zmm10 : IZmmReg<zmm10,N10>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm10(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM10;
    }

    public readonly struct zmm11 : IZmmReg<zmm11,N11>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm11(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM11;
    }

    public readonly struct zmm12 : IZmmReg<zmm12,N12>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm12(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM12;
    }

    public readonly struct zmm13 : IZmmReg<zmm13,N13>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm13(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM13;
    }

    public readonly struct zmm14 : IZmmReg<zmm14,N14>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm14(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM14;
    }

    public readonly struct zmm15 : IZmmReg<zmm15,N15>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm15(T value)
        {
            Content = value;
        }
        public K RegKind => K.ZMM15;
    }

    public readonly struct zmm16 : IZmmReg<zmm16,N16>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm16(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM16;

    }

    public readonly struct zmm17 : IZmmReg<zmm17,N17>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm17(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM17;
    }

    public readonly struct zmm18 : IZmmReg<zmm18,N18>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm18(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM18;
    }

    public readonly struct zmm19 : IZmmReg<zmm19,N19>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm19(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM19;
    }

    public readonly struct zmm20 : IZmmReg<zmm20,N20>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm20(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM20;
    }

    public readonly struct zmm21 : IZmmReg<zmm21,N21>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm21(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM21;
    }

    public readonly struct zmm22 : IZmmReg<zmm22,N22>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm22(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM22;
    }

    public readonly struct zmm23 : IZmmReg<zmm23,N23>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm23(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM23;
    }

    public readonly struct zmm24 : IZmmReg<zmm24,N24>
    {
        public T Content {get;}


        [MethodImpl(Inline)]
        public zmm24(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM24;
    }

    public readonly struct zmm25 : IZmmReg<zmm25,N25>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm25(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM25;
    }

    public readonly struct zmm26 : IZmmReg<zmm26,N26>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm26(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM26;
    }

    public readonly struct zmm27 : IZmmReg<zmm27,N27>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm27(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM27;
    }

    public readonly struct zmm28 : IZmmReg<zmm28,N28>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm28(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM28;
    }

    public readonly struct zmm29 : IZmmReg<zmm29,N29>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm29(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM29;
    }

    public readonly struct zmm30 : IZmmReg<zmm30,N30>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm30(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM30;
    }

    public readonly struct zmm31 : IZmmReg<zmm31,N31>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public zmm31(T value)
        {
            Content = value;
        }

        public K RegKind => K.ZMM31;
    }
}