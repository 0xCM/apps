//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    using Asm;

    partial class XedDisasm
    {
        public readonly struct DisasmOp
        {
            public readonly OpName Name;

            public readonly object Value;

            [MethodImpl(Inline)]
            public DisasmOp(OpValue value)
            {
                Name = value.Name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public DisasmOp(OpNameKind name, object value)
            {
                Name = name;
                Value = value;
            }

            public string Format()
                => Value?.ToString() ?? EmptyString;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static explicit operator Disp(DisasmOp src)
                => src.Value is OpValue v ? (Disp)v : Disp.Empty;

            public static DisasmOp Empty => new DisasmOp(OpNameKind.None, z8);
        }
    }
}