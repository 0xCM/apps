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
        public struct InstOperand
        {
            public byte Index;

            public FieldKind Kind;

            public OperandAction Action;

            public VisibilityKind Visiblity;

            public OperandWidthKind WidthType;

            public string Prop2;

            public LookupKind Lookup;
        }
    }
}