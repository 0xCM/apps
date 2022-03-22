//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct Visibility
        {
            readonly OpVisibility V0;

            readonly VisibilityKind V1;

            [MethodImpl(Inline)]
            public Visibility(OpVisibility src)
            {
                V0 = src;
                V1 = 0;
            }

            [MethodImpl(Inline)]
            public Visibility(VisibilityKind src)
            {
                V0 = 0;
                V1 = src;
            }

            public bool IsExplicit
            {
                [MethodImpl(Inline)]
                get => V0 == OpVisibility.Explicit || V1 == VisibilityKind.EXPLICIT;
            }

            public bool IsSuppresed
            {
                [MethodImpl(Inline)]
                get => V0 == OpVisibility.Suppressed || V1 == VisibilityKind.SUPPRESSED;
            }

            public bool IsImplicit
            {
                [MethodImpl(Inline)]
                get => V0 == OpVisibility.Implicit || V1 == VisibilityKind.IMPLICIT;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => V0 == 0 && V1 == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => V0 != 0 || V1 != 0;
            }

            public string Format()
            {
                if(V0 != 0)
                {
                    return XedRender.format(V0);
                }
                else if(V1 != 0)
                {
                    return XedRender.format(V1);
                }
                else
                    return EmptyString;
            }

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Visibility(OpVisibility src)
                => new Visibility(src);

            [MethodImpl(Inline)]
            public static implicit operator Visibility(VisibilityKind src)
                => new Visibility(src);

            [MethodImpl(Inline)]
            public static explicit operator ushort(Visibility src)
                => src.V0 !=0 ? (ushort)src.V0 : (ushort)src.V1;

            [MethodImpl(Inline)]
            public static explicit operator byte(Visibility src)
                => src.V0 !=0 ? (byte)src.V0 : (byte)src.V1;
        }
    }
}