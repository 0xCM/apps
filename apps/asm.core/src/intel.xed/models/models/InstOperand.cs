//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial struct XedModels
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct InstOperand
        {
            public byte Index;

            public XedOpKind Kind;

            public OperandAction Action;

            public VisibilityKind Visiblity;

            public OperandWidthType WidthType;

            public string Prop2;

            public LookupKind Lookup;
        }
    }
}