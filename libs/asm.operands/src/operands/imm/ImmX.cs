//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static byte BitWidth(this ImmKind src)
            => src switch{
                ImmKind.Imm8u => 8,
                ImmKind.Imm8i => 8,
                ImmKind.Imm16u => 16,
                ImmKind.Imm16i => 16,
                ImmKind.Imm32u => 32,
                ImmKind.Imm32i => 32,
                ImmKind.Imm64u => 64,
                ImmKind.Imm64i => 64,
                _ => 0
            };

        public static NativeSizeCode NativeSize(this ImmKind src)
            => src switch{
                ImmKind.Imm8u => NativeSizeCode.W8,
                ImmKind.Imm8i => NativeSizeCode.W8,
                ImmKind.Imm16u => NativeSizeCode.W16,
                ImmKind.Imm16i => NativeSizeCode.W16,
                ImmKind.Imm32u => NativeSizeCode.W32,
                ImmKind.Imm32i => NativeSizeCode.W32,
                ImmKind.Imm64u => NativeSizeCode.W64,
                ImmKind.Imm64i => NativeSizeCode.W64,
                _ => 0
            };

        [Op]
        public static Index<Imm8R> ToImm8Values(this byte[] src, ImmRefinementKind kind)
            => src.Map(x => new Imm8R(x));
    }
}