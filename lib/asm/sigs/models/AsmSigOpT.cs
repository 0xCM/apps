//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1, Size =2)]
    public readonly struct AsmSigOp<T>
        where T : unmanaged
    {
        public AsmSigOpKind Kind {get;}

        public T Token {get;}

        [MethodImpl(Inline)]
        public AsmSigOp(AsmSigOpKind kind, T token)
        {
            Kind = kind;
            Token = token;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Kind != 0;
        }

        public static AsmSigOp Empty => default;

        [MethodImpl(Inline)]
        public static implicit operator AsmSigOp(AsmSigOp<T> src)
            => new AsmSigOp(src.Kind, core.bw8(src.Token));

        [MethodImpl(Inline)]
        public static implicit operator AsmSigOp<T>((AsmSigOpKind kind, T value) src)
            => new AsmSigOp<T>(src.kind, src.value);

    }
}