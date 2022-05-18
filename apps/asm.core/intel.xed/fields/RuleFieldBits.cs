//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        /// <summary>
        /// Value[28:13] DataKind[12:9] Operator[8:6] FieldKind[5:0]
        /// </summary>
        [StructLayout(LayoutKind.Sequential,Pack=1,Size =4)]
        public readonly record struct RuleFieldBits
        {
            [MethodImpl(Inline)]
            public static implicit operator uint(RuleFieldBits src)
                => core.@as<RuleFieldBits,uint>(src);

            [MethodImpl(Inline)]
            public static explicit operator RuleFieldBits(uint src)
                => core.@as<RuleFieldBits>(src);

            public static RuleFieldBits Empty => default;
        }
    }
}