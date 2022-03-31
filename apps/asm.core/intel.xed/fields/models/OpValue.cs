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
            public OpNameKind Name;

            public object Data;

            [MethodImpl(Inline)]
            public OpValue(OpNameKind name, byte value)
            {
                Name = name;
                Data = value;
            }

            [MethodImpl(Inline)]
            public OpValue(OpNameKind name, Register value)
            {
                Name = name;
                Data = value;
            }

            [MethodImpl(Inline)]
            public OpValue(OpNameKind name, text31 value)
            {
                Name = name;
                Data = value;
            }

            [MethodImpl(Inline)]
            public OpValue(OpNameKind name, Imm value)
            {
                Name = name;
                Data = value;
            }

            [MethodImpl(Inline)]
            public OpValue(OpNameKind name, Disp value)
            {
                Name = name;
                Data = value;
            }

            public string Format()
                => Data?.ToString() ?? EmptyString;

            public override string ToString()
                => Format();

            public static OpValue Empty => new OpValue(OpNameKind.None, uint4.Min);
        }
    }
}