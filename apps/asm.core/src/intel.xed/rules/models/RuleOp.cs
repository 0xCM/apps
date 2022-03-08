//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;

    partial class XedRules
    {
        public struct RuleOp
        {
            public RuleOpName Name;

            public object Value;

            [MethodImpl(Inline)]
            public RuleOp(RuleOpName name, object value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOp(RuleOpName name, byte value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOp(RuleOpName name, Register value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOp(RuleOpName name, text31 value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOp(RuleOpName name, Imm value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOp(RuleOpName name, Disp value)
            {
                Name = name;
                Value = value;
            }

            public string Format()
                => Value?.ToString() ?? EmptyString;

            public override string ToString()
                => Format();

            public static RuleOp Empty => new RuleOp(RuleOpName.None, uint4.Min);
        }
    }
}