//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial struct XedModels
    {
        public struct RuleOperand
        {
            public RuleOpName Name;

            public object Value;

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, Hex64 value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, uint4 value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, XedRegId value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, text31 value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, Imm value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, Disp value)
            {
                Name = name;
                Value = value;
            }

            public string Format()
                => Value?.ToString() ?? EmptyString;

            public override string ToString()
                => Format();

            public static RuleOperand Empty => new RuleOperand(RuleOpName.None, uint4.Min);
        }
    }
}