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
    public readonly struct AsmSigToken<K>
        where K : unmanaged
    {
        public AsmSigTokenKind Kind {get;}

        readonly byte _Value;

        [MethodImpl(Inline)]
        public AsmSigToken(AsmSigTokenKind kind, K value)
        {
            Kind = kind;
            _Value = @as<K,byte>(value);
        }

        public K Value
        {
            [MethodImpl(Inline)]
            get => @as<byte,K>(_Value);
        }

        [MethodImpl(Inline)]
        public static implicit operator AsmSigToken<K>((AsmSigTokenKind kind, K value) src)
            => new AsmSigToken<K>(src.kind, src.value);

        [MethodImpl(Inline)]
        public static implicit operator AsmSigToken(AsmSigToken<K> src)
            => new AsmSigToken(src._Value, src.Kind);
    }
}