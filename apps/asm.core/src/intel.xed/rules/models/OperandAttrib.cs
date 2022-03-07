//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    using K = XedRules.OperandAttribKind;
    using F = XedFormatters;

    partial class XedRules
    {
        public readonly struct OperandAttrib
        {
            public static string format(OperandAttrib src)
            {
                var dst = EmptyString;
                switch(src.Kind)
                {
                    case K.Action:
                        dst = F.format(src.AsAction());
                    break;
                    case K.OpWidth:
                        dst = F.format(src.AsOpWidth());
                    break;

                    case K.PtrWidth:
                        dst = F.format(src.AsPtrWidth());
                    break;

                    case K.DataType:
                        dst = F.format(src.AsElementType());
                    break;

                    case K.EncodingGroup:
                        dst = F.format(src.AsEncodingGroup());
                    break;

                    case K.Common:
                        dst = F.format(src.AsCommon());
                    break;

                    case K.TextProp:
                        dst = F.format(src.AsTextProp());
                    break;

                    case K.Nonterminal:
                        dst = Nonterminals[src.AsNonTerm()].Expr.Text;
                    break;

                    case K.Visibility:
                        dst = F.format(src.AsVisiblity());
                    break;

                    case K.RegLiteral:
                        dst = src.AsRegLiteral().ToString();
                    break;

                    case K.Scale:
                        dst = src.AsScale().Format();
                    break;

                    case K.RegResolver:
                        dst = src.AsRegResolver().Format();
                    break;

                    case K.Macro:
                        dst = src.AsMacro().ToString();
                    break;

                }
                return dst;
            }

            public readonly OperandAttribKind Kind;

            readonly uint Data;

            [MethodImpl(Inline)]
            internal OperandAttrib(OperandAttribKind kind, uint data)
            {
                Kind = kind;
                Data = data;
            }

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

            [MethodImpl(Inline)]
            public TextPropKind AsTextProp()
                => (TextPropKind)Data;

            public string Format()
                => format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator OperandAttrib(OperandAction src)
                => new OperandAttrib(K.Action, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OperandAttrib(OperandWidthKind src)
                => new OperandAttrib(K.OpWidth, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OperandAttrib(PointerWidthKind src)
                => new OperandAttrib(K.PtrWidth, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OperandAttrib(NonterminalKind src)
                => new OperandAttrib(K.Nonterminal, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OperandAttrib(XedRegId src)
                => new OperandAttrib(K.RegLiteral, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OperandAttrib(ScaleFactor src)
                => new OperandAttrib(K.Scale, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OperandAttrib(RegResolver src)
                => new OperandAttrib(K.RegResolver, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator OperandAttrib(ElementKind src)
                => new OperandAttrib(K.DataType, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator OperandAttrib(OpVisiblity src)
                => new OperandAttrib(K.Visibility, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator OperandAttrib(RuleMacroKind src)
                => new OperandAttrib(K.Macro, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator OperandAttrib(EncodingGroup src)
                => new OperandAttrib(K.EncodingGroup, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator OperandAttrib(AttributeKind src)
                => new OperandAttrib(K.Common, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator OperandAttrib(TextPropKind src)
                => new OperandAttrib(K.TextProp, (uint)src);
        }
    }
}