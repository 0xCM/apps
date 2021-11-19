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
    using T = System.UInt32;
    using G = r32;
    using api = Asm.AsmRegs;

    /// <summary>
    /// Defines an operand that specifies a 32-bit gp register
    /// </summary>
    public struct r32 : IReg32<r32,T>
    {
        public T Content {get;}

        public K RegKind {get;}

        [MethodImpl(Inline)]
        public r32(T src, K kind)
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

    public readonly struct R32<R> : IReg32<R32<R>,T>
        where R : unmanaged, IReg32<R>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public R32(T value)
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
        public static implicit operator r32(R32<R> src)
            => new r32(src.Content, src.RegKind);
    }

    public struct eax : IReg32<eax,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public eax(T value)
            => Content = value;

        public K RegKind => K.EAX;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get => new G(Content, RegKind);
        }

        public string Name => nameof(eax);

        [MethodImpl(Inline)]
        public static implicit operator G(eax src)
            => src.Generalized;

        [MethodImpl(Inline)]
        public static implicit operator eax(T src)
            => new eax(src);

        [MethodImpl(Inline)]
        public static implicit operator T(eax src)
            => src.Content;
    }

    public struct ecx : IReg32<ecx,T>
    {
        public T Content {get;}


        [MethodImpl(Inline)]
        public ecx(T value)
            => Content = value;

        public K RegKind => K.ECX;

        public string Name => nameof(ecx);

        public G Generalized
        {
            [MethodImpl(Inline)]
            get => new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public static implicit operator G(ecx src)
            => src.Generalized;

        [MethodImpl(Inline)]
        public static implicit operator ecx(T src)
            => new ecx(src);

        [MethodImpl(Inline)]
        public static implicit operator T(ecx src)
            => src.Content;
    }

    public struct edx : IReg32<edx,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public edx(T value)
            => Content = value;

        public K RegKind => K.EDX;

        public string Name => nameof(edx);

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public static implicit operator G(edx src)
            => src.Generalized;

        [MethodImpl(Inline)]
        public static implicit operator edx(T src)
            => new edx(src);

        [MethodImpl(Inline)]
        public static implicit operator T(edx src)
            => src.Content;
    }

    public struct ebx : IReg32<ebx,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public ebx(T value)
            => Content = value;

        public K RegKind => K.EBX;

        public string Name => nameof(ebx);

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public static implicit operator G(ebx src)
            => src.Generalized;

        [MethodImpl(Inline)]
        public static implicit operator ebx(T src)
            => new ebx(src);

        [MethodImpl(Inline)]
        public static implicit operator T(ebx src)
            => src.Content;
    }

    public struct esi : IReg32<esi,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public static implicit operator G(esi src)
            => src.Generalized;

        [MethodImpl(Inline)]
        public esi(T value)
            => Content = value;

        public K RegKind => K.ESI;

        public string Name => nameof(esi);

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }
    }

    public struct edi : IReg32<edi,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public static implicit operator G(edi src)
            => src.Generalized;

        [MethodImpl(Inline)]
        public edi(T value)
            => Content = value;

        public K RegKind => K.EDI;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }
    }

    public struct esp : IReg32<esp,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public static implicit operator G(esp src)
            => src.Generalized;

        [MethodImpl(Inline)]
        public esp(T value)
            => Content = value;

        public K RegKind => K.ESP;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }
    }

    public struct ebp : IReg32<ebp,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public static implicit operator G(ebp src)
            => src.Generalized;

        [MethodImpl(Inline)]
        public ebp(T value)
        {
            Content = value;
        }

        public K RegKind => K.EBP;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }
    }

    public struct r8d : IReg32<r8d,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public r8d(T value)
            => Content = value;

        public K RegKind => K.R8D;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }
    }

    public struct r9d : IReg32<r9d,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public r9d(T value)
        {
            Content = value;
        }

        public K RegKind => K.R9D;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }
    }

    public struct r10d : IReg32<r10d,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public r10d(T value)
            => Content = value;

        public K RegKind => K.R10D;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }
    }

    public struct r11d : IReg32<r11d,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public r11d(T value)
            => Content = value;

        public K RegKind => K.R11D;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }
    }

    public struct r12d : IReg32<r12d,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public r12d(T value)
            => Content = value;

        public K RegKind => K.R12D;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }
    }

    public struct r13d : IReg32<r13d,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public r13d(T value)
        {
            Content = value;
        }

        public K RegKind => K.R13D;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }
    }

    public struct r14d : IReg32<r14d,T>
    {
        public T Content {get;}


        [MethodImpl(Inline)]
        public r14d(T value)
            => Content = value;

        public K RegKind => K.R14D;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }
    }

    public struct r15d : IReg32<r15d,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public r15d(T value)
            => Content = value;

        public K RegKind => K.R15D;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }
    }
}