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
        public struct OpValue
        {
            public OpName Name;

            public object Value;

            [MethodImpl(Inline)]
            public OpValue(OpName name, object value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public OpValue(OpName name, byte value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public OpValue(OpName name, Register value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public OpValue(OpName name, text31 value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public OpValue(OpName name, Imm value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public OpValue(OpName name, Disp value)
            {
                Name = name;
                Value = value;
            }

            public string Format()
                => Value?.ToString() ?? EmptyString;

            public override string ToString()
                => Format();

            public static OpValue Empty => new OpValue(OpName.None, uint4.Min);
        }
    }
}