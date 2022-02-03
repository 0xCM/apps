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
        public static byte encode(Hex8 a0, imm8 a1, Span<byte> dst)
        {
            var target = writer(dst);
            target.Write1(a0);
            target.Write1(a1);
            return (byte)target.BytesWritten;
        }

        [MethodImpl(Inline), Op]
        public static byte encode(RexPrefix a0, Hex8 a1, imm64 a2, Span<byte> dst)
        {
            var target = writer(dst);
            target.Write1(a0);
            target.Write1(a1);
            target.Write8(a2);
            return (byte)target.BytesWritten;
        }

        [MethodImpl(Inline), Op]
        static SpanWriter writer(Span<byte> buffer)
            => Spans.writer(buffer);

    }
}