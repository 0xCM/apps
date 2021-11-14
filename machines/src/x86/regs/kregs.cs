//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86.Regs
{
    using System;
    using System.Runtime.CompilerServices;

    using Asm;

    using static Root;

    using K = Asm.RegKind;
    using T = System.UInt64;
    using G = kreg;
    using api = Asm.AsmRegs;

    /// <summary>
    /// Defines an operand that specifies a 64-bit gp register
    /// </summary>
    public struct kreg : IReg64<kreg,T>
    {
        public T Content {get;}

        public K RegKind {get;}

        [MethodImpl(Inline)]
        public kreg(T src, K kind)
        {
            Content = src;
            RegKind = kind;
        }

        public RegIndexCode Index
        {
            [MethodImpl(Inline)]
            get => api.index(RegKind);
        }
    }

    /// <summary>
    /// Represents the <see cref='K.K0'/> register
    /// </summary>
    public struct k0 : IReg64<k0,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public k0(T value)
            => Content = value;

        public K RegKind => K.K0;

        [MethodImpl(Inline)]
        public static implicit operator G(k0 src)
            => new G(src.Content, src.RegKind);

        [MethodImpl(Inline)]
        public static implicit operator k0(T src)
            => new k0(src);
    }

    /// <summary>
    /// Represents the <see cref='K.K1'/> register
    /// </summary>
    public struct k1 : IReg64<k1,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public k1(T value)
            => Content = value;

        public K RegKind => K.K1;

        [MethodImpl(Inline)]
        public static implicit operator G(k1 src)
            => new G(src.Content, src.RegKind);

        [MethodImpl(Inline)]
        public static implicit operator k1(T src)
            => new k1(src);
    }

    /// <summary>
    /// Represents the <see cref='K.K2'/> register
    /// </summary>
    public struct k2 : IReg64<k2,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public k2(T value)
            => Content = value;

        public K RegKind => K.K2;

        [MethodImpl(Inline)]
        public static implicit operator G(k2 src)
            => new G(src.Content, src.RegKind);

        [MethodImpl(Inline)]
        public static implicit operator k2(T src)
            => new k2(src);
    }

    /// <summary>
    /// Represents the <see cref='K.K3'/> register
    /// </summary>
    public struct k3 : IReg64<k3,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public k3(T value)
            => Content = value;

        public K RegKind => K.K3;

        [MethodImpl(Inline)]
        public static implicit operator G(k3 src)
            => new G(src.Content, src.RegKind);

        [MethodImpl(Inline)]
        public static implicit operator k3(T src)
            => new k3(src);
    }

    /// <summary>
    /// Represents the <see cref='K.K4'/> register
    /// </summary>
    public struct k4 : IReg64<k4,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public k4(T value)
            => Content = value;

        public K RegKind => K.K4;

        [MethodImpl(Inline)]
        public static implicit operator G(k4 src)
            => new G(src.Content, src.RegKind);

        [MethodImpl(Inline)]
        public static implicit operator k4(T src)
            => new k4(src);
    }

    /// <summary>
    /// Represents the <see cref='K.K5'/> register
    /// </summary>
    public struct k5 : IReg64<k5,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public k5(T value)
            => Content = value;

        public K RegKind => K.K5;

        [MethodImpl(Inline)]
        public static implicit operator G(k5 src)
            => new G(src.Content, src.RegKind);

        [MethodImpl(Inline)]
        public static implicit operator k5(T src)
            => new k5(src);
    }

    /// <summary>
    /// Represents the <see cref='K.K6'/> register
    /// </summary>
    public struct k6 : IReg64<k6,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public k6(T value)
            => Content = value;

        public K RegKind => K.K6;

        [MethodImpl(Inline)]
        public static implicit operator G(k6 src)
            => new G(src.Content, src.RegKind);

        [MethodImpl(Inline)]
        public static implicit operator k6(T src)
            => new k6(src);
    }

    /// <summary>
    /// Represents the <see cref='K.K7'/> register
    /// </summary>
    public struct k7 : IReg64<k7,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public k7(T value)
            => Content = value;

        public K RegKind => K.K7;

        [MethodImpl(Inline)]
        public static implicit operator G(k7 src)
            => new G(src.Content, src.RegKind);

        [MethodImpl(Inline)]
        public static implicit operator k7(T src)
            => new k7(src);
    }
}