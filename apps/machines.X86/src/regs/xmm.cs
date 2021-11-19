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
    using T = Cell128;

    public struct xmm : IReg128<xmm,T>
    {
        public T Content {get;}

        public K RegKind {get;}

        [MethodImpl(Inline)]
        public xmm(T data, K kind)
        {
            Content = data;
            RegKind = kind;
        }

        public RegIndexCode Index
        {
            [MethodImpl(Inline)]
            get => AsmRegs.index(RegKind);
        }
    }

    public struct Xmm<R> : IReg128<Xmm<R>,Cell128>
        where R : unmanaged, IReg
    {
        public Cell128 Content {get;}

        [MethodImpl(Inline)]
        public Xmm(Cell128 value)
            => Content = value;

        public RegKind RegKind
            => default(R).RegKind;

        [MethodImpl(Inline)]
        public static implicit operator xmm(Xmm<R> src)
            => new xmm(src.Content, src.RegKind);
    }

    public struct xmm0 : IReg128<xmm0,T>
    {
        public const byte Index = 0;

        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm0(T value)
            => Data = value;

        public K RegKind => K.XMM0;

        [MethodImpl(Inline)]
        public static implicit operator xmm(xmm0 src)
            => new xmm(src.Content, src.RegKind);
    }

    public struct xmm1 : IReg128<xmm1,T>
    {
        public const byte Index = 1;

        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm1(T value)
            => Data = value;

        public K RegKind => K.XMM1;

        [MethodImpl(Inline)]
        public static implicit operator xmm(xmm1 src)
            => new xmm(src.Content, src.RegKind);
    }

    public struct xmm2 : IReg128<xmm2,T>
    {
        public const byte Index = 2;

        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm2(T value)
            => Data = value;

        public K RegKind => K.XMM2;

        [MethodImpl(Inline)]
        public static implicit operator xmm(xmm2 src)
            => new xmm(src.Content, src.RegKind);
    }

    public struct xmm3 : IReg128<xmm3,T>
    {
        public const byte Index = 3;

        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm3(T value)
            => Data = value;

        public K RegKind => K.XMM3;

        [MethodImpl(Inline)]
        public static implicit operator xmm(xmm3 src)
            => new xmm(src.Content, src.RegKind);
    }

    public struct xmm4 : IReg128<xmm4,T>
    {
        public const byte Index = 4;

        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm4(T value)
            => Data = value;

        public K RegKind => K.XMM4;

        [MethodImpl(Inline)]
        public static implicit operator xmm(xmm4 src)
            => new xmm(src.Content, src.RegKind);
    }

    public struct xmm5 : IReg128<xmm5,T>
    {
        public const byte Index = 5;

        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm5(T value)
            => Data = value;

        public K RegKind => K.XMM5;

        [MethodImpl(Inline)]
        public static implicit operator xmm(xmm5 src)
            => new xmm(src.Content, src.RegKind);
    }

    public struct xmm6 : IReg128<xmm6,T>
    {
        public const byte Index = 6;

        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm6(T value)
            => Data = value;

        public K RegKind => K.XMM6;

        [MethodImpl(Inline)]
        public static implicit operator xmm(xmm6 src)
            => new xmm(src.Content, src.RegKind);
    }

    public struct xmm7 : IReg128<xmm7,T>
    {
        public const byte Index = 7;

        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm7(T value)
            => Data = value;

        public K RegKind => K.XMM7;

        [MethodImpl(Inline)]
        public static implicit operator xmm(xmm7 src)
            => new xmm(src.Content, src.RegKind);
    }

    public struct xmm8 : IReg128<xmm8,T>
    {
        public const byte Index = 8;

        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm8(T value)
            => Data = value;

        public K RegKind => K.XMM8;

        [MethodImpl(Inline)]
        public static implicit operator xmm(xmm8 src)
            => new xmm(src.Content, src.RegKind);

    }

    public struct xmm9 : IReg128<xmm9,T>
    {
        public const byte Index = 9;

        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm9(T value)
            => Data = value;

        public K RegKind => K.XMM9;

        [MethodImpl(Inline)]
        public static implicit operator xmm(xmm9 src)
            => new xmm(src.Content, src.RegKind);
    }

    public struct xmm10 : IReg128<xmm10,T>
    {
        public const byte Index = 10;

        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm10(T value)
            => Data = value;

        public K RegKind => K.XMM10;

        [MethodImpl(Inline)]
        public static implicit operator xmm(xmm10 src)
            => new xmm(src.Content, src.RegKind);

    }

    public struct xmm11 : IReg128<xmm11,T>
    {
        public const byte Index = 11;

        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm11(T value)
            => Data = value;

        public K RegKind => K.XMM11;

        [MethodImpl(Inline)]
        public static implicit operator xmm(xmm11 src)
            => new xmm(src.Content, src.RegKind);

    }

    public struct xmm12 : IReg128<xmm12,T>
    {
        public const byte Index = 12;

        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm12(T value)
            => Data = value;

        public K RegKind => K.XMM12;

        [MethodImpl(Inline)]
        public static implicit operator xmm(xmm12 src)
            => new xmm(src.Content, src.RegKind);

    }

    public struct xmm13 : IReg128<xmm13,T>
    {
        public const byte Index = 13;

        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm13(T value)
            => Data = value;

        public K RegKind => K.XMM13;

        [MethodImpl(Inline)]
        public static implicit operator xmm(xmm13 src)
            => new xmm(src.Content, src.RegKind);

    }

    public struct xmm14 : IReg128<xmm14,T>
    {
        public const byte Index = 14;

        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm14(T value)
            => Data = value;

        public K RegKind => K.XMM14;

        [MethodImpl(Inline)]
        public static implicit operator xmm(xmm14 src)
            => new xmm(src.Content, src.RegKind);

    }

    public struct xmm15 : IReg128<xmm15,T>
    {
        public const byte Index = 15;

        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm15(T value)
            => Data = value;

        public K RegKind => K.XMM15;


        [MethodImpl(Inline)]
        public static implicit operator xmm(xmm15 src)
            => new xmm(src.Content, src.RegKind);

    }

    public struct xmm16 : IReg128<xmm16,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm16(T value)
            => Data = value;

        public K RegKind => K.XMM16;
    }

    public struct xmm17 : IReg128<xmm17,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm17(T value)
            => Data = value;

        public K RegKind => K.XMM17;
    }

    public struct xmm18 : IReg128<xmm18,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm18(T value)
            => Data = value;

        public K RegKind => K.XMM18;
    }

    public struct xmm19 : IReg128<xmm19,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm19(T value)
            => Data = value;

        public K RegKind => K.XMM19;
    }

    public struct xmm20 : IReg128<xmm20,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm20(T value)
            => Data = value;

        public K RegKind => K.XMM20;
    }

    public struct xmm21 : IReg128<xmm21,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm21(T value)
            => Data = value;

        public K RegKind => K.XMM21;
    }

    public struct xmm22 : IReg128<xmm22,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm22(T value)
            => Data = value;

        public K RegKind => K.XMM22;
    }

    public struct xmm23 : IReg128<xmm23,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm23(T value)
            => Data = value;

        public K RegKind => K.XMM23;
    }

    public struct xmm24 : IReg128<xmm24,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm24(T value)
            => Data = value;

        public K RegKind => K.XMM24;
    }

    public struct xmm25 : IReg128<xmm25,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm25(T value)
            => Data = value;

        public K RegKind => K.XMM25;
    }

    public struct xmm26 : IReg128<xmm26,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm26(T value)
                => Data = value;

        public K RegKind => K.XMM26;
    }

    public struct xmm27 : IReg128<xmm27,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm27(T value)
            => Data = value;

        public K RegKind => K.XMM27;
    }

    public struct xmm28 : IReg128<xmm28,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm28(T value)
            => Data = value;

        public K RegKind => K.XMM28;
    }

    public struct xmm29 : IReg128<xmm29,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm29(T value)
            => Data = value;

        public K RegKind => K.XMM29;
    }

    public struct xmm30 : IReg128<xmm30,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm30(T value)
            => Data = value;

        public K RegKind => K.XMM30;
    }

    public struct xmm31 : IReg128<xmm31,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public xmm31(T value)
            => Data = value;

        public K RegKind => K.XMM31;
    }
}