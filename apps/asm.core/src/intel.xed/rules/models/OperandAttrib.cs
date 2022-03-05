//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    using K = XedRules.OperandAttribKind;

    partial class XedRules
    {
        public readonly struct OperandAttrib
        {
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
            public XedDataType AsDataType()
                => (XedDataType)Data;

            [MethodImpl(Inline)]
            public OpVisiblity AsVisiblity()
                => (OpVisiblity)Data;

            [MethodImpl(Inline)]
            public RuleMacroKind AsMacro()
                => (RuleMacroKind)Data;

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
            public static implicit operator OperandAttrib(XedDataType src)
                => new OperandAttrib(K.DataType, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator OperandAttrib(OpVisiblity src)
                => new OperandAttrib(K.Visibility, (uint)src);

            [MethodImpl(Inline)]
            public static implicit operator OperandAttrib(RuleMacroKind src)
                => new OperandAttrib(K.Macro, (uint)src);

        }
    }
}