//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Size=2)]
    public readonly struct AsmSigOp : IEquatable<AsmSigOp>
    {
        public readonly AsmSigTokenKind Kind;

        public readonly byte Value;

        public readonly AsmModifierKind Modifier;

        [MethodImpl(Inline)]
        public AsmSigOp(AsmSigTokenKind kind, byte value, AsmModifierKind mod = 0)
        {
            Value = value;
            Kind = kind;
            Modifier = mod;
        }

        public AsmSigToken Token
        {
            [MethodImpl(Inline)]
            get => new AsmSigToken(Kind, Value);
        }

        public uint Id
        {
            [MethodImpl(Inline)]
            get => bits.join((byte)Value, (byte)Kind);
        }

        public bool IsModified
        {
            [MethodImpl(Inline)]
            get => Modifier != 0;
        }

        public bool IsMasked
        {
            [MethodImpl(Inline)]
            get => IsModified && (byte)Modifier <= (byte)AsmModifierKind.k1z;
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