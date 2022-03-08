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
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct DisasmOp<T>
            where T : unmanaged
        {
            public readonly RuleOpName Name;

            public readonly T Value;

            [MethodImpl(Inline)]
            public DisasmOp(RuleOpName name, T value)
            {
                Name = name;
                Value = value;
            }

            public string Format()
                => Value.ToString();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator DisasmOp(DisasmOp<T> src)
                => new DisasmOp(src.Name, src.Value);
        }
    }
}