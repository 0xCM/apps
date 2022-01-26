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
    public readonly struct AsmOcToken<K> : IAsmOpCodeToken<K>
        where K : unmanaged
    {
        readonly byte _Value;

        public AsmOcTokenKind Kind {get;}

        [MethodImpl(Inline)]
        public AsmOcToken(AsmOcTokenKind kind, K value)
        {
            Kind = kind;
            _Value = @as<K,byte>(value);
        }

        [MethodImpl(Inline)]
        public AsmOcToken(ushort src)
        {
            _Value = (byte)src;
            Kind = (AsmOcTokenKind)(src >> 8);
        }

        public K Value
        {
            [MethodImpl(Inline)]
            get => @as<byte,K>(_Value);
        }

        [MethodImpl(Inline)]
        public static implicit operator ushort(AsmOcToken<K> src)
            => core.bw16(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOcToken<K>((AsmOcTokenKind kind, K value) src)
            => new AsmOcToken<K>(src.kind, src.value);

        [MethodImpl(Inline)]
        public static implicit operator AsmOcToken(AsmOcToken<K> src)
            => new AsmOcToken(src.Kind, src._Value);
    }
}