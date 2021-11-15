//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [Op]
        public static string FormatAsmHex(this sbyte src, int? digits = null)
            => HexFormatter.asmhex(src, digits);

        [Op]
        public static string FormatAsmHex(this byte src, int? digits = null)
            => HexFormatter.asmhex(src, digits);

        [Op]
        public static string FormatAsmHex(this short src, int? digits = null)
            => HexFormatter.asmhex(src, digits);

        [Op]
        public static string FormatAsmHex(this ushort src, int? digits = null)
            => HexFormatter.asmhex(src, digits);

        [Op]
        public static string FormatAsmHex(this int src, int? digits = null)
            => HexFormatter.asmhex(src, digits);

        [Op]
        public static string FormatAsmHex(this uint src, int? digits = null)
            => HexFormatter.asmhex(src, digits);

        [Op]
        public static string FormatAsmHex(this ulong src, int? digits = null)
            => HexFormatter.asmhex(src, digits);

        [Op]
        public static string FormatAsmHex(this long src, int? digits = null)
            => HexFormatter.asmhex(src,digits);

        [Op]
        public static string FormatTrimmedAsmHex(this ushort src)
            => src.FormatAsmHex(Widths.effective(src));

        [Op]
        public static string FormatTrimmedAsmHex(this uint src)
            => src.FormatAsmHex(Widths.effective(src));

        [Op]
        public static string FormatTrimmedAsmHex(this ulong src)
            => src.FormatAsmHex(Widths.effective(src));
    }
}