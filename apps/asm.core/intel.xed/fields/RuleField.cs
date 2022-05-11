//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        /// <summary>
        /// Value:[28:13] | DataKind:[12:9] | Operator:[8:6] | FieldKind:[5:0]
        /// </summary>
        [StructLayout(LayoutKind.Sequential,Pack=1,Size =4)]
        public readonly record struct RuleField
        {
            [MethodImpl(Inline)]
            public static implicit operator uint(RuleField src)
                => core.@as<RuleField,uint>(src);

            [MethodImpl(Inline)]
            public static explicit operator RuleField(uint src)
                => core.@as<RuleField>(src);

            public static RuleField Empty => default;
        }
    }
}