//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    using K = XedRules.OpAttribClass;

    partial class XedRules
    {
        public readonly struct OpAttrib : IComparable<OpAttrib>, IEquatable<OpAttrib>
        {
            public readonly OpAttribClass Class;

            readonly uint Data;

            [MethodImpl(Inline)]
            internal OpAttrib(OpAttribClass kind, uint data)
            {
                Class = kind;
                Data = data;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Class == 0 && Data == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Class != 0 || Data != 0;
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
            public OpModifier ToModifier()
                => new OpModifier((OpModKind)Data);

            [MethodImpl(Inline)]
            public OpAction ToAction()
                => (OpAction)Data;

            [MethodImpl(Inline)]
            public OpWidthCode ToWidthCode()
                => (OpWidthCode)Data;

            [MethodImpl(Inline)]
            public XedRegId ToRegLiteral()
                => (XedRegId)Data;

            [MethodImpl(Inline)]
            public Nonterminal ToNonTerm()
                => (RuleName)Data;

            [MethodImpl(Inline)]
            public MemoryScale ToScale()
                => (MemoryScale)(ScaleFactor)Data;

            [MethodImpl(Inline)]
            public ElementType ToElementType()
                => (ElementType)Data;

            [MethodImpl(Inline)]
            public Visibility ToVisibility()
                => (OpVisibility)Data;

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(OpAction src)
                => new OpAttrib(K.Action, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(OpWidthCode src)
                => new OpAttrib(K.Width, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(Nonterminal src)
                => new OpAttrib(K.Nonterminal, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(XedRegId src)
                => new OpAttrib(K.RegLiteral, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(ElementType src)
                => new OpAttrib(K.ElementType, (uint)src.Kind);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(OpVisibility src)
                => new OpAttrib(K.Visibility, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(OpModKind src)
                => new OpAttrib(K.Modifier, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(OpModifier src)
                => new OpAttrib(K.Modifier, (uint)src.Kind);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib(MemoryScale src)
                => new OpAttrib(K.Scale, (uint)src.Factor);

            public static OpAttrib Empty => default;
        }
    }
}