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
    using T = System.Byte;
    using G = r8;
    using api = Asm.AsmRegs;

    public struct R8<R> : IReg8<R8<R>,T>
        where R : unmanaged, IReg8<R>
    {
        public byte Data;

        [MethodImpl(Inline)]
        public R8(byte src)
            => Data = src;

        public byte Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

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
        public static implicit operator r8(R8<R> src)
            => new r8(src.Content, src.RegKind);
    }

    /// <summary>
    /// Defines an operand that specifies an 8-bit gp register
    /// </summary>
    public struct r8 : IReg8<r8,T>
    {
        public T Content {get;}

        public K RegKind {get;}

        [MethodImpl(Inline)]
        public r8(T src, K kind)
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

    public struct al : IReg8<al,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public al(T value)
            => Content = value;

        public K RegKind => K.AL;

        [MethodImpl(Inline)]
        public static implicit operator G(al src)
            => new G(src.Content, src.RegKind);
    }

    public struct cl : IReg8<cl,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public cl(T value)
            => Content = value;

        public K RegKind => K.CL;

        [MethodImpl(Inline)]
        public static implicit operator G(cl src)
            => new G(src.Content, src.RegKind);

    }

    public struct dl : IReg8<dl,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public dl(T value)
            => Content = value;

        public K RegKind => K.DL;


        [MethodImpl(Inline)]
        public static implicit operator G(dl src)
            => new G(src.Content, src.RegKind);
    }

    public struct bl : IReg8<bl,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public static implicit operator G(bl src)
            => new G(src.Content, src.RegKind);

        [MethodImpl(Inline)]
        public bl(T value)
            => Content = value;

        public K RegKind => K.BL;
    }

    public struct sil : IReg8<sil,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public sil(T value)
            => Content = value;

        public K RegKind => K.SIL;

        [MethodImpl(Inline)]
        public static implicit operator G(sil src)
            => new G(src.Content, src.RegKind);
    }

    public struct dil : IReg8<dil,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public dil(T value)
            => Content = value;

        public K RegKind => K.DIL;

        [MethodImpl(Inline)]
        public static implicit operator G(dil src)
            => new G(src.Content, src.RegKind);
    }

    public struct spl : IReg8<spl,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public spl(T value)
            => Content = value;

        public K RegKind => K.SPL;


        [MethodImpl(Inline)]
        public static implicit operator G(spl src)
            => new G(src.Content, src.RegKind);
    }

    public struct bpl : IReg8<bpl,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public bpl(T value)
            => Content = value;

        public K RegKind => K.BPL;

        [MethodImpl(Inline)]
        public static implicit operator G(bpl src)
            => new G(src.Content, src.RegKind);
    }

    public struct r8b : IReg8<r8b,T>
    {
        public T Content {get;}


        [MethodImpl(Inline)]
        public r8b(T value)
            => Content = value;

        public K RegKind => K.R8B;


        [MethodImpl(Inline)]
        public static implicit operator G(r8b src)
            => new G(src.Content, src.RegKind);
    }

    public struct r9b : IReg8<r9b,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public r9b(T value)
            => Content = value;

        public K RegKind => K.R9B;

        [MethodImpl(Inline)]
        public static implicit operator G(r9b src)
            => new G(src.Content, src.RegKind);
    }

    public struct r10b : IReg8<r10b,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public r10b(T value)
            => Content = value;

        public K RegKind => K.R10B;

        [MethodImpl(Inline)]
        public static implicit operator G(r10b src)
            => new G(src.Content, src.RegKind);
    }

    public struct r11b : IReg8<r11b,T>
    {
        public T Content {get;}

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public r11b(T value)
            => Content = value;

        public K RegKind => K.R11B;

    }

    public struct r12b : IReg8<r12b,T>
    {
        public T Content {get;}

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public r12b(T value)
            => Content = value;

        public K RegKind => K.R12B;

    }

    public struct r13b : IReg8<r13b,T>
    {
        public T Content {get;}

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public r13b(T value)
            => Content = value;

        public K RegKind => K.R13B;


    }

    public struct r14b : IReg8<r14b,T>
    {
        public T Content {get;}

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public r14b(T value)
            => Content = value;

        public K RegKind => K.R14B;

    }

    public struct r15b : IReg8<r15b,T>
    {
        public T Content {get;}

        public G Generalized
        {
            [MethodImpl(Inline)]
            get => new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public r15b(T value)
            => Content = value;

        public K RegKind => K.R15B;
    }
}