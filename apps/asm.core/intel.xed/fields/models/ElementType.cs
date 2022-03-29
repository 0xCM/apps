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

            public string Name
            {
                [MethodImpl(Inline)]
                get => IsEmpty ? EmptyString : XedRender.format(Kind);
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

            public bool IsFloat
            {
                [MethodImpl(Inline)]
                get=> Kind == ElementKind.BF16 || Kind == ElementKind.F16 || Kind == ElementKind.F32 || Kind == ElementKind.F64 || Kind == ElementKind.F80;
            }

            public bool IsSignedInt
            {
                [MethodImpl(Inline)]
                get => Kind == ElementKind.INT;
            }

            public bool IsUnsignedInt
            {
                [MethodImpl(Inline)]
                get => Kind == ElementKind.UINT;
            }

            public bool IsInt
            {
                [MethodImpl(Inline)]
                get => IsSignedInt || IsUnsignedInt;
            }

            public char Indicator
            {
                [MethodImpl(Inline)]
                get => (char)(IsFloat ? NumericIndicator.Float : IsSignedInt ? NumericIndicator.Signed : IsUnsignedInt ? NumericIndicator.Unsigned : NumericIndicator.None);
            }

            public string Format()
                => Name;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator ElementType(ElementKind src)
                => new ElementType(src);

            [MethodImpl(Inline)]
            public static implicit operator ElementKind(ElementType src)
                => src.Kind;

            public static ElementType Empty => default;
        }
    }
}