//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static byte Width(this ImmKind src)
            => src switch{
                ImmKind.Imm8 => 8,
                ImmKind.Imm8i => 8,
                ImmKind.Imm16 => 16,
                ImmKind.Imm16i => 16,
                ImmKind.Imm32 => 32,
                ImmKind.Imm32i => 32,
                ImmKind.Imm64 => 64,
                ImmKind.Imm64i => 64,
                _ => 0
            };

        public static NativeSizeCode NativeSize(this ImmKind src)
            => src switch{
                ImmKind.Imm8 => NativeSizeCode.W8,
                ImmKind.Imm8i => NativeSizeCode.W8,
                ImmKind.Imm16 => NativeSizeCode.W16,
                ImmKind.Imm16i => NativeSizeCode.W16,
                ImmKind.Imm32 => NativeSizeCode.W32,
                ImmKind.Imm32i => NativeSizeCode.W32,
                ImmKind.Imm64 => NativeSizeCode.W64,
                ImmKind.Imm64i => NativeSizeCode.W64,
                _ => 0
            };

        [Op]
        public static Index<imm8R> ToImm8Values(this byte[] src, ImmRefinementKind kind)
            => src.Map(x => new imm8R(x));
    }
}