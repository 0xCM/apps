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
    public readonly struct AsmOcToken<K>
        where K : unmanaged
    {
        public AsmOcTokenKind Kind {get;}

        readonly byte _Value;

        [MethodImpl(Inline)]
        public AsmOcToken(AsmOcTokenKind kind, K value)
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
        public static implicit operator AsmOcToken<K>((AsmOcTokenKind kind, K value) src)
            => new AsmOcToken<K>(src.kind, src.value);

        [MethodImpl(Inline)]
        public static implicit operator AsmOcToken(AsmOcToken<K> src)
            => new AsmOcToken(src.Kind, src._Value);
    }
}