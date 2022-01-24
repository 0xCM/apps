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
    using static core;

    [StructLayout(LayoutKind.Sequential, Size=2)]
    public readonly struct AsmSigOp<K> : IAsmSigOp<K>
        where K : unmanaged
    {
        readonly byte _Value;

        public AsmSigOpKind Kind {get;}

        [MethodImpl(Inline)]
        public AsmSigOp(AsmSigOpKind kind, K value)
        {
            Kind = kind;
            _Value = @as<K,byte>(value);
        }

        public K Token
        {
            [MethodImpl(Inline)]
            get => @as<byte,K>(_Value);
        }

        [MethodImpl(Inline)]
        public static implicit operator AsmSigOp<K>((AsmSigOpKind kind, K value) src)
            => new AsmSigOp<K>(src.kind, src.value);

        [MethodImpl(Inline)]
        public static implicit operator AsmSigOp(AsmSigOp<K> src)
            => new AsmSigOp(src.Kind, src._Value);
    }
}