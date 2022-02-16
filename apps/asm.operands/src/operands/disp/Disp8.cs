//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Defines a signed 8-bit displacement
    /// </summary>
    [DataType(TypeSyntax.Disp8)]
    public readonly struct Disp8 : IDisplacement<Disp8,sbyte>
    {
        /// <summary>
        /// The base displacement magnitude
        /// </summary>
        public sbyte Value {get;}

        [MethodImpl(Inline)]
        public Disp8(sbyte @base)
        {
            Value = @base;
        }

        public NativeSize Size
            => NativeSizeCode.W8;

        public AsmOpKind OpKind
            => AsmOpKind.Disp8;

        public AsmOpClass OpClass
            => AsmOpClass.Disp;

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        public bool Positive
        {
            [MethodImpl(Inline)]
            get => Value > 0;
        }

        public bool Negative
        {
            [MethodImpl(Inline)]
            get => Value < 0;
        }

        long IDisplacement.Value
            => Value;

        [MethodImpl(Inline)]
        public bool Equals(Disp8 src)
            => Value == src.Value;

        public string Format()
            => AsmRender.disp(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Disp8(byte src)
            => new Disp8((sbyte)src);

        [MethodImpl(Inline)]
        public static implicit operator Disp8(sbyte src)
            => new Disp8(src);

        [MethodImpl(Inline)]
        public static implicit operator byte(Disp8 src)
            => (byte)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator sbyte(Disp8 src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Disp(Disp8 src)
            => new Disp(src.Value, src.Size);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(Disp8 src)
            => new AsmOperand(src);
    }
}