//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public readonly struct RuleOperand
        {
            public OperandKind Kind {get;}

            public TextBlock Value {get;}

            [MethodImpl(Inline)]
            public RuleOperand(OperandKind kind, string value)
            {
                Kind = kind;
                Value = value;
            }

            public string Format()
                => Kind == 0 ? Value : string.Format("{0} ({1} kind)", Value, Kind);

            public override string ToString()
                => Format();
        }
    }
}