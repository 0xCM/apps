//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Size=2, Pack =1)]
    public readonly struct AsmSigToken : IAsmSigToken<AsmSigToken,byte>
    {
        public AsmSigTokenKind Kind {get;}

        public byte Value {get;}

        [MethodImpl(Inline)]
        public AsmSigToken(AsmSigTokenKind kind, byte value)
        {
            Value = value;
            Kind = kind;
        }

        public uint Id
        {
            [MethodImpl(Inline)]
            get => bits.join((byte)Value, (byte)Kind);
        }

        [MethodImpl(Inline)]
        public int CompareTo(AsmSigToken src)
        {
            var result = ((byte)Kind).CompareTo((byte)src.Kind);
            if(result == 0)
                result = Value.CompareTo(src.Value);
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
        public bool Equals(AsmSigToken src)
            => Kind == src.Kind && Value == src.Value;

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

        public static AsmSigToken Empty => default;
    }
}