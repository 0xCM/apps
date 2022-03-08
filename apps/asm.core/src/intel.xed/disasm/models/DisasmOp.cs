//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using static XedRules;

    partial struct XedModels
    {
        public readonly struct DisasmOp
        {
            public readonly RuleOpName Name;

            public readonly object Value;

            [MethodImpl(Inline)]
            public DisasmOp(RuleOpName name, object value)
            {
                Name = name;
                Value = value;
            }

            public string Format()
                => Value?.ToString() ?? EmptyString;

            public override string ToString()
                => Format();

            public static DisasmOp Empty => new DisasmOp(RuleOpName.None, z8);
        }
    }
}