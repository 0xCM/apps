//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Size=2)]
    public readonly struct AsmOcToken<K> : IAsmOpCodeToken<AsmOcToken<K>,K>
        where K : unmanaged, IEquatable<K>
    {
        public AsmOcTokenKind Kind {get;}

        public K Value {get;}

        [MethodImpl(Inline)]
        public AsmOcToken(AsmOcTokenKind kind, K value)
        {
            Kind = kind;
            Value = value;
        }

        [MethodImpl(Inline)]
        public AsmOcToken(byte src)
        {
            Value = @as<byte,K>(src);
            Kind = (AsmOcTokenKind)(src >> 8);
        }

        [MethodImpl(Inline)]
        public bool Equals(AsmOcToken<K> src)
            => Kind == src.Kind && Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(AsmOcToken<K> src)
        {
            var result = ((byte)Kind).CompareTo((byte)src.Kind);
            if(result == 0)
                result = u8(Value).CompareTo(u8(src.Value));
            return result;
        }

        [MethodImpl(Inline)]
        public static implicit operator ushort(AsmOcToken<K> src)
            => core.bw16(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOcToken<K>((AsmOcTokenKind kind, K value) src)
            => new AsmOcToken<K>(src.kind, src.value);

        [MethodImpl(Inline)]
        public static implicit operator AsmOcToken(AsmOcToken<K> src)
            => new AsmOcToken(src.Kind, bw8(src.Value));
    }
}