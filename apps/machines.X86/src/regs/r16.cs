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
    using T = System.UInt16;
    using G = r16;
    using api = Asm.AsmRegs;

    /// <summary>
    /// Defines an operand that specifies a 16-bit gp register
    /// </summary>
    public struct r16 : IReg16<r16,T>
    {
        public T Content {get;}

        public K RegKind {get;}

        [MethodImpl(Inline)]
        public r16(T src, K kind)
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

    public readonly struct R16<R> : IReg16<R16<R>,T>
        where R : unmanaged, IReg16<R>
    {
        public ushort Content {get;}

        [MethodImpl(Inline)]
        public R16(ushort value)
            => Content = value;

        public RegKind RegKind
        {
            [MethodImpl(Inline)]
            get => default(R).RegKind;
        }

        public RegIndexCode Index
        {
            [MethodImpl(Inline)]
            get => api.index(RegKind);
        }

        [MethodImpl(Inline)]
        public static implicit operator r16(R16<R> src)
            => new r16(src.Content, src.RegKind);
    }

    public struct ax : IReg16<ax,T>
    {
        public T Content  {get;}

        [MethodImpl(Inline)]
        public static implicit operator G(ax src)
            => src.Generalized;

        [MethodImpl(Inline)]
        public ax(T value)
        {
            Content = value;
        }

        public K RegKind => K.AX;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get => new G(Content, RegKind);
        }
    }

    public struct cx : IReg16<cx,T>
    {
        public T Content  {get;}

        [MethodImpl(Inline)]
        public static implicit operator G(cx src)
            => src.Generalized;

        [MethodImpl(Inline)]
        public cx(T value)
        {
            Content = value;
        }

        public K RegKind => K.CX;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }
    }

    public struct dx : IReg16<dx,T>
    {
        public T Content  {get;}

        [MethodImpl(Inline)]
        public dx(T value)
        {
            Content = value;
        }

        public K RegKind => K.DX;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get => new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public static implicit operator G(dx src)
            => src.Generalized;
    }

    public struct bx : IReg16<bx,T>
    {
        public T Content  {get;}

        [MethodImpl(Inline)]
        public static implicit operator G(bx src)
            => src.Generalized;

        [MethodImpl(Inline)]
        public bx(T value)
        {
            Content = value;
        }

        public K RegKind => K.BX;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }
    }

    public struct si : IReg16<si,T>
    {
        public T Content  {get;}

        [MethodImpl(Inline)]
        public static implicit operator G(si src)
            => src.Generalized;

        [MethodImpl(Inline)]
        public si(T value)
        {
            Content = value;
        }

        public K RegKind => K.SI;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }
    }

    public struct di : IReg16<di,T>
    {
        public T Content  {get;}

        [MethodImpl(Inline)]
        public static implicit operator G(di src)
            => src.Generalized;

        [MethodImpl(Inline)]
        public di(T value)
        {
            Content = value;
        }

        public K RegKind => K.DI;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }
    }

    public struct sp : IReg16<sp,T>
    {
        public T Content  {get;}

        [MethodImpl(Inline)]
        public sp(T value)
        {
            Content = value;
        }

        public K RegKind => K.SP;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get => new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public static implicit operator G(sp src)
            => src.Generalized;
    }

    public struct bp : IReg16<bp,T>
    {
        public T Content  {get;}

        [MethodImpl(Inline)]
        public static implicit operator G(bp src)
            => src.Generalized;

        [MethodImpl(Inline)]
        public bp(T value)
        {
            Content = value;
        }

        public K RegKind => K.AX;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }
    }

    public struct r8w : IReg16<r8w,T>
    {
        public T Content  {get;}

        [MethodImpl(Inline)]
        public r8w(T value)
        {
            Content = value;
        }

        public K RegKind => K.R8W;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public static implicit operator G(r8w src)
            => src.Generalized;

    }

    public struct r9w : IReg16<r9w,T>
    {
        public T Content  {get;}

        [MethodImpl(Inline)]
        public r9w(T value)
        {
            Content = value;
        }

        public K RegKind => K.R9W;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public static implicit operator G(r9w src)
            => src.Generalized;
    }

    public struct r10w : IReg16<r10w,T>
    {
        public T Content  {get;}

        [MethodImpl(Inline)]
        public r10w(T value)
        {
            Content = value;
        }

        public K RegKind => K.R10W;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public static implicit operator G(r10w src)
            => src.Generalized;

    }

    public struct r11w : IReg16<r11w,T>
    {
        public T Content  {get;}

        [MethodImpl(Inline)]
        public r11w(T value)
        {
            Content = value;
        }

        public K RegKind => K.R11W;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public static implicit operator G(r11w src)
            => src.Generalized;
    }

    public struct r12w : IReg16<r12w,T>
    {
        public T Content  {get;}

        [MethodImpl(Inline)]
        public r12w(T value)
        {
            Content = value;
        }

        public K RegKind => K.R12W;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public static implicit operator G(r12w src)
            => src.Generalized;
    }

    public struct r13w : IReg16<r13w,T>
    {
        public T Content  {get;}

        [MethodImpl(Inline)]
        public r13w(T value)
        {
            Content = value;
        }

        public K RegKind => K.R13W;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public static implicit operator G(r13w src)
            => src.Generalized;
    }

    public struct r14w : IReg16<r14w,T>
    {
        public T Content  {get;}

        [MethodImpl(Inline)]
        public r14w(T value)
        {
            Content = value;
        }

        public K RegKind => K.R14W;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public static implicit operator G(r14w src)
            => src.Generalized;

    }

    public struct r15w : IReg16<r15w,T>
    {
        public T Content  {get;}

        [MethodImpl(Inline)]
        public r15w(T value)
        {
            Content = value;
        }

        public K RegKind => K.R15W;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public static implicit operator G(r15w src)
            => src.Generalized;
   }
}