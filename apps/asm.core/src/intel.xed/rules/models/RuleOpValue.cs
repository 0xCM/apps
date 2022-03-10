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
        public struct RuleOpValue
        {
            public RuleOpName Name;

            public object Value;

            [MethodImpl(Inline)]
            public RuleOpValue(RuleOpName name, object value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOpValue(RuleOpName name, byte value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOpValue(RuleOpName name, Register value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOpValue(RuleOpName name, text31 value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOpValue(RuleOpName name, Imm value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOpValue(RuleOpName name, Disp value)
            {
                Name = name;
                Value = value;
            }

            public string Format()
                => Value?.ToString() ?? EmptyString;

            public override string ToString()
                => Format();

            public static RuleOpValue Empty => new RuleOpValue(RuleOpName.None, uint4.Min);
        }
    }
}