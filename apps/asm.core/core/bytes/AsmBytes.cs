//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [ApiHost]
    public partial class AsmBytes
    {
        public static string format<T>(T src)
            where T : unmanaged, IAsmByte
                => src.Value().FormatHex(zpad:true, specifier:true, uppercase:true);

        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static byte encode(Hex8 a0, imm8 a1, AsmHexWriter dst)
            => dst.Write(a0,a1);

        [MethodImpl(Inline), Op]
        public static byte encode(RexPrefix a0, Hex8 a1, imm64 a2, Span<byte> buffer)
        {
            var dst = writer(buffer);
            return dst.Write(a0,a1,a2);
        }

        [MethodImpl(Inline), Op]
        public static byte encode(Rip a0, Jcc8 a1, AsmHexWriter dst)
            => dst.Write(a1.JccCode, AsmRel8.target(a0, a1.Disp));

        [MethodImpl(Inline), Op]
        static AsmHexWriter writer(Span<byte> buffer)
            => new AsmHexWriter(buffer);
    }
}