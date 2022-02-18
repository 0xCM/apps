//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRecords;
    partial struct XedModels
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct InstOperandDetail
        {
            public InstOperand Op;

            public OperandWidth Width;

            public RuleOpName RuleOpName;

            public RuleOperand RuleOp;

            public @string RuleOpInfo;

            public byte Index
            {
                [MethodImpl(Inline)]
                get => Op.Index;
            }

            public XedOpKind OpKind
            {
                [MethodImpl(Inline)]
                get => Op.Kind;
            }

            public VisibilityKind Visibility
            {
                [MethodImpl(Inline)]
                get => Op.Visiblity;
            }

            public OperandAction Action
            {
                [MethodImpl(Inline)]
                get =>Op.Action;
            }

            public @string WidthInfo
                => string.Format("{0}:{1}", Width.Name, Width.Width64);


        }
    }
}