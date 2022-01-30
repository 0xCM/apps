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

        public AsmSigOpKind OpKind {get;}

        public NativeSize Size {get;}

        public AsmModifierKind Modifier {get;}

        [MethodImpl(Inline)]
        public AsmSigOp(AsmSigOpKind kind, byte value, NativeSizeCode size = NativeSizeCode.Unknown, AsmModifierKind mod = 0)
        {
            Value = value;
            OpKind = kind;
            Size = size;
            Modifier = mod;
        }

        public uint Id
        {
            [MethodImpl(Inline)]
            get => bits.join((byte)Value, (byte)OpKind, (byte)Size);
        }

        [MethodImpl(Inline)]
        public AsmSigOp WithModifier(AsmModifierKind mod)
            => new AsmSigOp(OpKind, Value, Size, mod);

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => OpKind == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => OpKind != 0;
        }

        public override int GetHashCode()
            => (int)Id;

        [MethodImpl(Inline)]
        public bool Equals(AsmSigOp src)
            => core.bw64(this) == core.bw64(src);

        public override bool Equals(object src)
            => src is AsmSigOp x && Equals(x);

        public static AsmSigOp Empty =>default;
    }
}