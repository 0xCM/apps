//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct ElementType
        {
            public readonly ElementKind Kind;

            [MethodImpl(Inline)]
            public ElementType(ElementKind kind)
            {
                Kind = kind;
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

            public bool IsNumber
            {
                get => Indicator != 0;
            }

            public bool IsFloat
            {
                [MethodImpl(Inline)]
                get => Indicator == NumericIndicator.Float;
            }

            public bool IsSignedInt
            {
                [MethodImpl(Inline)]
                get => Indicator == NumericIndicator.Signed;
            }

            public bool IsUnsignedInt
            {
                [MethodImpl(Inline)]
                get => Indicator == NumericIndicator.Unsigned;
            }

            public bool IsInt
            {
                [MethodImpl(Inline)]
                get => IsSignedInt || IsUnsignedInt;
            }

            public NumericIndicator Indicator
                => indicator(Kind);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator ElementType(ElementKind src)
                => new ElementType(src);

            [MethodImpl(Inline)]
            public static implicit operator ElementKind(ElementType src)
                => src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator byte(ElementType src)
                => (byte)src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator ElementType(byte src)
                => new ElementType((ElementKind)src);

            public static ElementType Empty => default;
        }
    }
}