//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    partial struct AsmX
    {
        [Op]
        public static Imm imm(AsmHexCode src, byte pos, bool signed, NativeSize size)
        {
            var dst = Imm.Empty;
            switch(size.Code)
            {
                case NativeSizeCode.W8:
                    dst = imm(size, signed, src[pos]);
                break;
                case NativeSizeCode.W16:
                    dst = imm(size, signed, slice(src.Bytes,pos, 2).TakeUInt16());
                break;
                case NativeSizeCode.W32:
                    dst = imm(size, signed, slice(src.Bytes,pos, 4).TakeUInt32());
                break;
                case NativeSizeCode.W64:
                    dst = imm(size, signed, slice(src.Bytes,pos, 8).TakeUInt64());
                break;
            }
            return dst;
        }

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

        /// <summary>
        /// Defines an 8-bit immediate operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static imm8 imm8(byte src)
            => new imm8(src);

        /// <summary>
        /// Defines a 16-bit immediate operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static imm16 imm16(ushort src)
            => new imm16(src);

        /// <summary>
        /// Defines a 32-bit immediate operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static imm32 imm32(uint src)
            => new imm32(src);

        /// <summary>
        /// Defines a 64-bit immediate operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static imm64 imm64(ulong src)
            => new imm64(src);
    }
}