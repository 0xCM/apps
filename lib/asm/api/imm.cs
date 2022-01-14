//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct asm
    {
        [Op]
        public static Imm imm(NativeSize size, bool signed, ulong value)
        {
            var kind = ImmKind.None;
            switch(size.Code)
            {
                case NativeSizeCode.W8:
                    kind = signed ? ImmKind.Imm8i : ImmKind.Imm8;
                break;
                case NativeSizeCode.W16:
                    kind = signed ? ImmKind.Imm16i : ImmKind.Imm16;
                break;
                case NativeSizeCode.W32:
                    kind = signed ? ImmKind.Imm32i : ImmKind.Imm32;
                break;
                case NativeSizeCode.W64:
                    kind = signed ? ImmKind.Imm64i : ImmKind.Imm64;
                break;
            }
            return new Imm(kind, value);
        }

        [Op]
        public static Imm imm(NativeSize size, long value)
        {
            var kind = ImmKind.None;
            switch(size.Code)
            {
                case NativeSizeCode.W8:
                    kind = ImmKind.Imm8i;
                break;
                case NativeSizeCode.W16:
                    kind = ImmKind.Imm16i;
                break;
                case NativeSizeCode.W32:
                    kind = ImmKind.Imm32i;
                break;
                case NativeSizeCode.W64:
                    kind = ImmKind.Imm64i;
                break;
            }
            return new Imm(kind, value);
        }

        [Op]
        public static Imm imm(NativeSize size, ulong value)
        {
            var kind = ImmKind.None;
            switch(size.Code)
            {
                case NativeSizeCode.W8:
                    kind = ImmKind.Imm8;
                break;
                case NativeSizeCode.W16:
                    kind = ImmKind.Imm16;
                break;
                case NativeSizeCode.W32:
                    kind = ImmKind.Imm32;
                break;
                case NativeSizeCode.W64:
                    kind = ImmKind.Imm64;
                break;
            }
            return new Imm(kind, value);
        }

        [MethodImpl(Inline), Op]
        public static Imm imm(ImmKind kind, ulong value)
            => new Imm(kind, value);
    }
}