//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct OperandDetail
        {
            public InstOperand Def;

            public OperandWidth Width;

            public RuleOpName RuleOpName;

            public RuleOperand Rule;

            public @string RuleDescription;

            public TextBlock DefDescription;

            public byte Index
            {
                [MethodImpl(Inline)]
                get => Def.Index;
            }

            public FieldKind FieldKind
            {
                [MethodImpl(Inline)]
                get => Def.Kind;
            }

            public OperandAction Action
            {
                [MethodImpl(Inline)]
                get => Def.Action;
            }

            public string Format()
                => DefDescription;

            public override string ToString()
                => Format();
        }
    }
}