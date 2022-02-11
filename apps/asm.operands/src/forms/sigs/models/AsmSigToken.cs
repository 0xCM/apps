//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Size=2, Pack =1)]
    public readonly struct AsmSigToken : IComparable<AsmSigToken>, IEquatable<AsmSigToken>
    {
        public byte Value {get;}

        public AsmSigTokenKind Kind {get;}

        [MethodImpl(Inline)]
        public AsmSigToken(AsmSigTokenKind kind, byte value)
        {
            Value = value;
            Kind = kind;
        }

        [MethodImpl(Inline)]
        public AsmSigToken(ushort src)
        {
            Value = (byte)src;
            Kind = (AsmSigTokenKind)(src >> 8);
        }

        [MethodImpl(Inline)]
        public int CompareTo(AsmSigToken src)
        {
            var result = ((byte)Kind).CompareTo((byte)src.Kind);
            if(result == 0)
                result = Value.CompareTo(src.Value);
            return result;
        }

        [MethodImpl(Inline)]
        public bool Equals(AsmSigToken src)
            => Kind == src.Kind && Value == src.Value;

        public override bool Equals(object src)
            => src is AsmSigToken x && Equals(x);

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (ushort)this;
        }

        public override int GetHashCode()
            => (int)Hash;

        public string Format()
            => AsmSigs.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ushort(AsmSigToken src)
            => core.bw16(src);
    }
}