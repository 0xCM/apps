//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Size=2)]
    public readonly struct AsmSigOp : IEquatable<AsmSigOp>
    {
        public byte Value {get;}

        public AsmSigTokenKind Kind {get;}

        public AsmModifierKind Modifier {get;}

        [MethodImpl(Inline)]
        public AsmSigOp(AsmSigTokenKind kind, byte value, AsmModifierKind mod = 0)
        {
            Value = value;
            Kind = kind;
            Modifier = mod;
        }

        public uint Id
        {
            [MethodImpl(Inline)]
            get => bits.join((byte)Value, (byte)Kind);
        }

        public bool HasModifier
        {
            [MethodImpl(Inline)]
            get => Modifier != 0;
        }

        [MethodImpl(Inline)]
        public AsmSigOp WithoutModifier()
            => new AsmSigOp(Kind, Value);

        [MethodImpl(Inline)]
        public AsmSigOp WithModifier(AsmModifierKind mod)
            => new AsmSigOp(Kind, Value, mod);

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

        public override int GetHashCode()
            => (int)Id;

        [MethodImpl(Inline)]
        public bool Equals(AsmSigOp src)
            => core.bw64(this) == core.bw64(src);

        public override bool Equals(object src)
            => src is AsmSigOp x && Equals(x);

        public string Format()
            => AsmSigs.format(this);

        public override string ToString()
            => Format();

        public static AsmSigOp Empty =>default;
    }
}