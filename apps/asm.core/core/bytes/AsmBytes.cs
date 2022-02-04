//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;

    [ApiHost]
    public partial class AsmBytes
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static byte encode(Hex8 a0, imm8 a1, AsmHexWriter dst)
        {
            dst.Write1(a0);
            dst.Write1(a1);
            return (byte)dst.BytesWritten;
        }

        [MethodImpl(Inline), Op]
        public static byte encode(RexPrefix a0, Hex8 a1, imm64 a2, Span<byte> buffer)
        {
            var dst = writer(buffer);
            dst.Write1(a0);
            dst.Write1(a1);
            dst.Write8(a2);
            return (byte)dst.BytesWritten;
        }


        [MethodImpl(Inline), Op]
        public static void encode(Rip rip, Jcc8 jcc, AsmHexWriter dst)
        {
            var target = AsmRel8.target(rip, jcc.Disp);
            dst.Write1(jcc.JccCode);
            dst.Write1(AsmRel8.target(rip, jcc.Disp));
        }

        [MethodImpl(Inline), Op]
        static AsmHexWriter writer(Span<byte> buffer)
            => new AsmHexWriter(buffer);
    }
}