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
        public readonly struct Operand
        {
            public readonly OpName Name;

            public readonly object Value;

            [MethodImpl(Inline)]
            public Operand(OpValue value)
            {
                Name = value.Name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public Operand(OpNameKind name, object value)
            {
                Name = name;
                Value = value;
            }

            public string Format()
                => Value?.ToString() ?? EmptyString;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static explicit operator Disp(Operand src)
                => src.Value is OpValue v ? (Disp)v : Disp.Empty;

            public static Operand Empty => new Operand(OpNameKind.None, z8);
        }
    }
}