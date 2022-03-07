//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;

    partial struct XedModels
    {
        public struct DisasmOp
        {
            public RuleOpName Name;

            public object Value;

            [MethodImpl(Inline)]
            public DisasmOp(RuleOpName name, byte value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public DisasmOp(RuleOpName name, Register value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public DisasmOp(RuleOpName name, text31 value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public DisasmOp(RuleOpName name, Imm value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public DisasmOp(RuleOpName name, Disp value)
            {
                Name = name;
                Value = value;
            }

            public string Format()
                => Value?.ToString() ?? EmptyString;

            public override string ToString()
                => Format();

            public static DisasmOp Empty => new DisasmOp(RuleOpName.None, uint4.Min);
        }
    }
}