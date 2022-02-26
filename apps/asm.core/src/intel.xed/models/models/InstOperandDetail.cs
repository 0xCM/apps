//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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

            public TextBlock Description;

            public byte Index
            {
                [MethodImpl(Inline)]
                get => Op.Index;
            }

            public FieldKind OpKind
            {
                [MethodImpl(Inline)]
                get => Op.Kind;
            }

            public OperandAction Action
            {
                [MethodImpl(Inline)]
                get => Op.Action;
            }

            public string Format()
                => Description;

            public override string ToString()
                => Format();

        }
    }
}