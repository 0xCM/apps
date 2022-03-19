//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    using K = XedRules.RuleOpClass;

    partial class XedRules
    {
        public readonly struct RuleOpAttrib : IComparable<RuleOpAttrib>, IEquatable<RuleOpAttrib>
        {
            public readonly RuleOpClass Class;

            readonly uint Data;

            [MethodImpl(Inline)]
            internal RuleOpAttrib(RuleOpClass kind, uint data)
            {
                Class = kind;
                Data = data;
            }

            [MethodImpl(Inline)]
            public int CompareTo(RuleOpAttrib src)
                => ((uint)Class).CompareTo((uint)src.Class);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public bool Equals(RuleOpAttrib src)
                => Class == src.Class && Data == src.Data;

            [MethodImpl(Inline)]
            public RuleOpModifier AsModifier()
                => new RuleOpModifier((RuleOpModKind)Data);

            [MethodImpl(Inline)]
            public OperandAction AsAction()
                => (OperandAction)Data;

            [MethodImpl(Inline)]
            public OperandWidthCode AsOpWidth()
                => (OperandWidthCode)Data;

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
            public static implicit operator RuleOpAttrib(OperandAction src)
                => new RuleOpAttrib(K.Action, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(OperandWidthCode src)
                => new RuleOpAttrib(K.OpWidth, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(PointerWidthKind src)
                => new RuleOpAttrib(K.PtrWidth, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(Nonterminal src)
                => new RuleOpAttrib(K.Nonterminal, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(XedRegId src)
                => new RuleOpAttrib(K.RegLiteral, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(ScaleFactor src)
                => new RuleOpAttrib(K.Scale, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(ElementKind src)
                => new RuleOpAttrib(K.ElementType, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(OpVisibility src)
                => new RuleOpAttrib(K.Visibility, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(RuleMacroKind src)
                => new RuleOpAttrib(K.Macro, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(RuleOpModKind src)
                => new RuleOpAttrib(K.Modifier, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(RuleOpModifier src)
                => new RuleOpAttrib(K.Modifier, (uint)src.Kind);

            public static RuleOpAttrib Empty => default;
        }
    }
}