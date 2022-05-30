//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Size=2, Pack =1)]
    public readonly struct AsmOcToken : IAsmOpCodeToken<AsmOcToken,byte>
    {
        public AsmOcTokenKind Kind {get;}

        public byte Value {get;}

        [MethodImpl(Inline)]
        public AsmOcToken(AsmOcTokenKind kind, byte value)
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
        public int CompareTo(AsmOcToken src)
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
        public bool Equals(AsmOcToken src)
            => Kind == src.Kind && Value == src.Value;

        public override bool Equals(object src)
            => src is AsmOcToken x && Equals(x);

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => core.bw16(this);
        }

        public override int GetHashCode()
            => (int)Hash;

        public string Format()
            => AsmOpCodes.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator ==(AsmOcToken a, AsmOcToken b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(AsmOcToken a, AsmOcToken b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static explicit operator byte(AsmOcToken src)
            => src.Value;

        public static AsmOcToken Empty => default;

    }
}