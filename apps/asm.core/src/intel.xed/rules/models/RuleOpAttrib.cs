//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    using K = XedRules.RuleOpAttribKind;

    partial class XedRules
    {
        public readonly struct RuleOpAttrib
        {
            public readonly RuleOpAttribKind Kind;

            readonly uint Data;

            [MethodImpl(Inline)]
            internal RuleOpAttrib(RuleOpAttribKind kind, uint data)
            {
                Kind = kind;
                Data = data;
            }

            [MethodImpl(Inline)]
            public RuleOpModifier AsModifier()
                => new RuleOpModifier((RuleOpModKind)Data);

            [MethodImpl(Inline)]
            public OperandAction AsAction()
                => (OperandAction)Data;

            [MethodImpl(Inline)]
            public OperandWidthKind AsOpWidth()
                => (OperandWidthKind)Data;

            [MethodImpl(Inline)]
            public PointerWidthKind AsPtrWidth()
                => (PointerWidthKind)Data;

            [MethodImpl(Inline)]
            public XedRegId AsRegLiteral()
                => (XedRegId)Data;

            [MethodImpl(Inline)]
            public NonterminalKind AsNonTerm()
                => (NonterminalKind)Data;

            [MethodImpl(Inline)]
            public MemoryScale AsScale()
                => (ScaleFactor)Data;

            [MethodImpl(Inline)]
            public RegResolver AsRegResolver()
                => (RegResolver)(int)Data;

            [MethodImpl(Inline)]
            public ElementKind AsElementType()
                => (ElementKind)Data;

            [MethodImpl(Inline)]
            public OpVisiblity AsVisiblity()
                => (OpVisiblity)Data;

            [MethodImpl(Inline)]
            public RuleMacroKind AsMacro()
                => (RuleMacroKind)Data;

            [MethodImpl(Inline)]
            public EncodingGroup AsEncodingGroup()
                => (EncodingGroup)Data;

            [MethodImpl(Inline)]
            public AttributeKind AsCommon()
                => (AttributeKind)Data;

            public string Format()
                => XedFormatters.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(OperandAction src)
                => new RuleOpAttrib(K.Action, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(OperandWidthKind src)
                => new RuleOpAttrib(K.OpWidth, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(PointerWidthKind src)
                => new RuleOpAttrib(K.PtrWidth, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(NonterminalKind src)
                => new RuleOpAttrib(K.Nonterminal, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(XedRegId src)
                => new RuleOpAttrib(K.RegLiteral, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(ScaleFactor src)
                => new RuleOpAttrib(K.Scale, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(RegResolver src)
                => new RuleOpAttrib(K.RegResolver, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(ElementKind src)
                => new RuleOpAttrib(K.DataType, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(OpVisiblity src)
                => new RuleOpAttrib(K.Visibility, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(RuleMacroKind src)
                => new RuleOpAttrib(K.Macro, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(EncodingGroup src)
                => new RuleOpAttrib(K.EncodingGroup, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(AttributeKind src)
                => new RuleOpAttrib(K.Common, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib(RuleOpModKind src)
                => new RuleOpAttrib(K.Modifier, (uint)src);
        }
    }
}