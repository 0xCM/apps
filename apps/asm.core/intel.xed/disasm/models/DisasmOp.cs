//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDisasm
    {
        public readonly struct DisasmOp
        {
            public readonly OpName Name;

            public readonly object Value;

            [MethodImpl(Inline)]
            public DisasmOp(OpName name, object value)
            {
                Name = name;
                Value = value;
            }

            public string Format()
                => Value?.ToString() ?? EmptyString;

            public override string ToString()
                => Format();

            public static DisasmOp Empty => new DisasmOp(OpName.None, z8);
        }
    }
}