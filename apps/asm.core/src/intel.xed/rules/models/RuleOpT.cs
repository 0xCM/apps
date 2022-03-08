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
        public readonly struct RuleOp<T>
            where T : unmanaged
        {
            public readonly RuleOpName Name;

            public readonly T Value;

            [MethodImpl(Inline)]
            public RuleOp(RuleOpName name, T value)
            {
                Name = name;
                Value = value;
            }

            public static implicit operator RuleOp(RuleOp<T> src)
                => new RuleOp(src.Name, src.Value);
        }
    }
}