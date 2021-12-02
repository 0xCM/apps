//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Linq;

    partial class XTend
    {
        public static ImmBitWidth Width(this ImmKind src)
            => src switch{
                ImmKind.Imm8 => ImmBitWidth.W8,
                ImmKind.Imm8i => ImmBitWidth.W8,
                ImmKind.Imm16 => ImmBitWidth.W16,
                ImmKind.Imm16i => ImmBitWidth.W16,
                ImmKind.Imm32 => ImmBitWidth.W32,
                ImmKind.Imm32i => ImmBitWidth.W32,
                ImmKind.Imm64 => ImmBitWidth.W64,
                ImmKind.Imm64i => ImmBitWidth.W64,
                _ => 0
            };

        [Op]
        public static Index<imm8R> RefinedImmValues(this ParameterInfo param)
        {
            if(param.IsRefinedImmediate())
                return param.ParameterType.GetEnumValues().Cast<byte>().Array().ToImm8Values(ImmRefinementKind.Refined);
            else
                return sys.empty<imm8R>();
        }

        [Op]
        public static Index<imm8R> ToImm8Values(this byte[] src, ImmRefinementKind kind)
            => src.Map(x => new imm8R(x));
    }
}