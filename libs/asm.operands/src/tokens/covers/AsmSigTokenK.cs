//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Size=2, Pack =1)]
    public readonly struct AsmSigToken<K> : IAsmSigToken<AsmSigToken<K>,K>
        where K : unmanaged, IEquatable<K>
    {
        public AsmSigTokenKind Kind {get;}

        public K Value {get;}

        [MethodImpl(Inline)]
        public AsmSigToken(AsmSigTokenKind kind, K value)
        {
            Value = value;
            Kind = kind;
        }

        public uint Id
        {
            [MethodImpl(Inline)]
            get => bits.join(u8(Value), (byte)Kind);
        }

        [MethodImpl(Inline)]
        public int CompareTo(AsmSigToken<K> src)
        {
            var result = ((byte)Kind).CompareTo((byte)src.Kind);
            if(result == 0)
                result = u8(Value).CompareTo(u8(src.Value));
            return result;
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

        [MethodImpl(Inline)]
        public bool Equals(AsmSigToken<K> src)
            => Kind == src.Kind && u8(Value) == u8(src.Value);

        public override bool Equals(object src)
            => src is AsmSigToken x && Equals(x);

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (ushort)core.bw16(this);
        }

        public override int GetHashCode()
            => (int)Hash;

        public string Format()
            => AsmSigs.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ushort(AsmSigToken<K> src)
            => core.bw16(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmSigToken<K>((AsmSigTokenKind kind, K value) src)
            => new AsmSigToken<K>(src.kind, src.value);

        [MethodImpl(Inline)]
        public static implicit operator AsmSigToken(AsmSigToken<K> src)
            => new AsmSigToken(src.Kind, bw8(src.Value));

        public static AsmSigToken Empty => default;
    }
}