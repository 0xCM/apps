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
    using G = r64;

    /// <summary>
    /// Defines an operand that specifies a 64-bit gp register
    /// </summary>
    public struct r64 : IReg64<r64,T>
    {
        public T Content {get;}

        public K RegKind {get;}

        [MethodImpl(Inline)]
        public r64(T src, K kind)
        {
            Content = src;
            RegKind = kind;
        }

        public RegIndexCode Index
        {
            [MethodImpl(Inline)]
            get => AsmRegs.index(RegKind);
        }
    }

    public struct R64<R> : IReg64<R64<R>,T>
        where R : unmanaged, IReg64<T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public R64(T src)
            => Content= src;

        public RegKind RegKind
        {
            [MethodImpl(Inline)]
            get => default(R).RegKind;
        }

        public RegIndexCode Index
        {
            [MethodImpl(Inline)]
            get => AsmRegs.index(RegKind);
        }

        [MethodImpl(Inline)]
        public static implicit operator r64(R64<R> src)
            => new r64(src.Content, src.RegKind);
    }

    /// <summary>
    /// Represents the <see cref='K.RAX'/> register
    /// </summary>
    /// <remarks>
    /// | 000  | rax    | eax    | ax     | al    |
    /// </remarks>
    public struct rax : IReg64<rax,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public rax(T value)
            => Content = value;

        public al Al
        {
            [MethodImpl(Inline)]
            get => new al((byte)Content);
        }

        public ax Ax
        {
            [MethodImpl(Inline)]
            get => new ax((ushort)Content);
        }

        public eax Eax
        {
            [MethodImpl(Inline)]
            get => new eax((uint)Content);
        }

        public K RegKind => K.RAX;

        [MethodImpl(Inline)]
        public static implicit operator G(rax src)
            => new G(src.Content, src.RegKind);

        [MethodImpl(Inline)]
        public static implicit operator rax(T src)
            => new rax(src);
    }

    /// <summary>
    /// Register C Extended: 0001  [rcx    | ecx    | cx     | cl    ]
    /// </summary>
    public struct rcx : IReg64<rcx,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public static implicit operator G(rcx src)
            => new G(src.Content, src.RegKind);

        [MethodImpl(Inline)]
        public rcx(T value)
            => Data = value;

        public K RegKind => K.RAX;

        public cl Cl
        {
            [MethodImpl(Inline)]
            get => new cl((byte)Content);
        }

        public cx Cx
        {
            [MethodImpl(Inline)]
            get => new cx((ushort)Content);
        }

        public ecx Ecx
        {
            [MethodImpl(Inline)]
            get => new ecx((uint)Content);
        }

        public G Generalized
        {
            [MethodImpl(Inline)]
            get => new G(Content, RegKind);
        }
    }

    /// <summary>
    /// Register D Extended: | 0010  | rdx    | edx    | dx     | dl    |
    /// </summary>
    public struct rdx : IReg64<rdx,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public static implicit operator G(rdx src)
            => new G(src.Content, src.RegKind);

        [MethodImpl(Inline)]
        public rdx(T value)
            => Data = value;

        public K RegKind => K.RDX;
    }

    /// <summary>
    /// Register B Extended
    /// </summary>
    public struct rbx : IReg64<rbx,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public static implicit operator G(rbx src)
            => new G(src.Content, src.RegKind);

        [MethodImpl(Inline)]
        public rbx(T value)
            => Data = value;

        public K RegKind => K.RBX;
    }

    /// <summary>
    /// Register Source Index: Specifies the source for data copies
    /// </summary>
    public struct rsi : IReg64<rsi,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public static implicit operator G(rsi src)
            => new G(src.Content, src.RegKind);

        [MethodImpl(Inline)]
        public rsi(T value)
            => Data = value;

        public K RegKind => K.RSI;

    }

    /// <summary>
    /// Register Destination Index: Specifies the target for data copies
    /// </summary>
    public struct rdi : IReg64<rdi,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public rdi(T value)
            => Data = value;

        public K RegKind => K.RDI;

        public G Generalized
        {
            [MethodImpl(Inline)]
            get =>new G(Content, RegKind);
        }

        [MethodImpl(Inline)]
        public static implicit operator G(rdi src)
            => new G(src.Content, src.RegKind);
    }

    /// <summary>
    /// Register Stack Pointer: Specifies the current location in stack and grows downwards
    /// </summary>
    public struct rsp : IReg64<rsp,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public rsp(T value)
                => Data = value;

        public K RegKind => K.RSP;

        [MethodImpl(Inline)]
        public static implicit operator G(rsp src)
            => new G(src.Content, src.RegKind);
    }

    /// <summary>
    /// Register Base Pointer: Specifies the top of the stack
    /// </summary>
    public struct rbp : IReg64<rbp,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public rbp(T value)
            => Data = value;

        public K RegKind => K.RBP;

        [MethodImpl(Inline)]
        public static implicit operator G(rbp src)
            => new G(src.Content, src.RegKind);
    }

    public struct r8q : IReg64<r8q,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public r8q(T value)
            => Data = value;

        public K RegKind => K.R8Q;

        [MethodImpl(Inline)]
        public static implicit operator G(r8q src)
            => new G(src.Content, src.RegKind);
    }

    public struct r9q : IReg64<r9q,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public r9q(T value)
            => Data = value;

        public K RegKind => K.R9Q;

        [MethodImpl(Inline)]
        public static implicit operator G(r9q src)
            => new G(src.Content, src.RegKind);

    }

    public struct r10q : IReg64<r10q,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public r10q(T value)
            => Data = value;

        public K RegKind => K.R10Q;

        [MethodImpl(Inline)]
        public static implicit operator G(r10q src)
            => new G(src.Content, src.RegKind);

    }

    public struct r11q : IReg64<r11q,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public r11q(T value)
            => Data = value;

        public K RegKind => K.R11Q;

        [MethodImpl(Inline)]
        public static implicit operator G(r11q src)
            => new G(src.Content, src.RegKind);
    }

    public struct r12q : IReg64<r12q,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public r12q(T value)
            => Data = value;

        public K RegKind => K.R12Q;

        [MethodImpl(Inline)]
        public static implicit operator G(r12q src)
            => new G(src.Content, src.RegKind);

    }

    public struct r13q : IReg64<r13q,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public r13q(T value)
            => Data = value;

        public K RegKind => K.R13Q;

        [MethodImpl(Inline)]
        public static implicit operator G(r13q src)
            => new G(src.Content, src.RegKind);
    }

    public struct r14q : IReg64<r14q,T>
    {
        public T Data;

        public T Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public r14q(T value)
            => Data = value;

        public K RegKind => K.R14Q;

        [MethodImpl(Inline)]
        public static implicit operator G(r14q src)
            => new G(src.Content, src.RegKind);
    }

    public struct r15q : IReg64<r15q,T>
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public r15q(T value)
            => Content = value;

        public K RegKind => K.R15Q;

        [MethodImpl(Inline)]
        public static implicit operator G(r15q src)
            => new G(src.Content, src.RegKind);
    }
}