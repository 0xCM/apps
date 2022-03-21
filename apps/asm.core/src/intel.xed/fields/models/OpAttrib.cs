//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    using K = XedRules.OpClass;

    partial class XedRules
    {
        public readonly struct OpAttrib : IComparable<OpAttrib>, IEquatable<OpAttrib>
        {
            public readonly OpClass Class;

            readonly uint Data;

            [MethodImpl(Inline)]
            internal OpAttrib(OpClass kind, uint data)
            {
                Class = kind;
                Data = data;
            }

            [MethodImpl(Inline)]
            public int CompareTo(OpAttrib src)
                => ((uint)Class).CompareTo((uint)src.Class);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public bool Equals(OpAttrib src)
                => Class == src.Class && Data == src.Data;

            [MethodImpl(Inline)]
            public OpModifier AsModifier()
                => new OpModifier((OpModKind)Data);

            [MethodImpl(Inline)]
            public OpAction AsAction()
                => (OpAction)Data;

            [MethodImpl(Inline)]
            public OpWidthCode AsOpWidth()
                => (OpWidthCode)Data;

            [MethodImpl(Inline)]
            public PointerWidthKind AsPtrWidth()
                => (PointerWidthKind)Data;

            [MethodImpl(Inline)]
            public XedRegId AsRegLiteral()
                => (XedRegId)Data;

            [MethodImpl(Inline)]
            public NontermKind AsNonTerm()
                => (NontermKind)Data;

            [MethodImpl(Inline)]
            public MemoryScale AsScale()
                => (ScaleFactor)Data;

            [MethodImpl(Inline)]
            public ElementKind AsElementType()
                => (ElementKind)Data;

            [MethodImpl(Inline)]
            public OpVisibility AsVisiblity()
                => (OpVisibility)Data;

            [MethodImpl(Inline)]
            public RuleMacroKind AsMacro()
                => (RuleMacroKind)Data;

            [MethodImpl(Inline)]
            public AttributeKind AsCommon()
                => (AttributeKind)Data;

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(OpAction src)
                => new OpAttrib(K.Action, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(OpWidthCode src)
                => new OpAttrib(K.OpWidth, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(PointerWidthKind src)
                => new OpAttrib(K.PtrWidth, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(Nonterminal src)
                => new OpAttrib(K.Nonterminal, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(XedRegId src)
                => new OpAttrib(K.RegLiteral, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(ScaleFactor src)
                => new OpAttrib(K.Scale, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(ElementKind src)
                => new OpAttrib(K.ElementType, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(OpVisibility src)
                => new OpAttrib(K.Visibility, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(OpModKind src)
                => new OpAttrib(K.Modifier, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(OpModifier src)
                => new OpAttrib(K.Modifier, (uint)src.Kind);

            public static OpAttrib Empty => default;
        }
    }
}