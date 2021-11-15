//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static ExtractTermCode;

    partial struct ApiExtracts
    {
        [Op]
        public static unsafe ApiCaptureResult divine(Span<byte> dst, OpIdentity id, byte* pSrc)
        {
            var limit = dst.Length - 1;
            var start = (long)pSrc;
            var offset = 0;
            int? ret_offset = null;
            var end = (long)pSrc;
            var state = default(byte);

            while(offset < limit)
            {
                state = step(dst, id, ref offset, ref end, ref pSrc);
                if(ret_offset == null && state == RET)
                    ret_offset = offset;
                var tc = term(dst, offset, ret_offset, out var delta);
                if(tc != null)
                    return summarize(dst, id, tc.Value, start, end, delta);
            }
            return summarize(dst, id, CTC_BUFFER_OUT, start, end, 0);
        }

        [Op, MethodImpl(Inline)]
        static unsafe byte step(Span<byte> dst, OpIdentity id, ref int offset, ref long location, ref byte* pSrc)
        {
            var code = Unsafe.Read<byte>(pSrc++);
            dst[offset++] = code;
            location = (long)pSrc;
            return code;
        }

        [Op]
        static ExtractTermCode? term(Span<byte> src, int offset, int? ret_offset, out int delta)
        {
            delta = 0;

            if(offset >= 4)
            {
                var tc = scan4(src, offset, out delta);
                if(tc != null)
                    return tc;
            }

            if(offset >= 5)
            {
                var tc = scan5(src, offset, out delta);
                if(tc != null)
                    return tc;
            }

            if(offset >= 7 && z7(src, offset))
            {
                if(ret_offset == null)
                {
                    delta = -6;
                    return CTC_Zx7;
                }
                delta = -(offset - ret_offset.Value);
                return CTC_RET_Zx7;
            }

            return null;
        }

        [Op, MethodImpl(Inline)]
        static ExtractTermCode? scan4(Span<byte> src, int offset, out int delta)
        {
            var x0 = src[offset - 3];
            var x1 = src[offset - 2];
            var x2 = src[offset - 1];
            var x3 = src[offset - 0];
            delta = -2;

            if(match((x0,RET), (x1, SBB)))
                return CTC_RET_SBB;
            else if(match((x0, RET), (x1, INTR)))
                return CTC_RET_INTR;
            else if(match((x0, RET), (x1, ZED), (x2, SBB)))
                return CTC_RET_ZED_SBB;
            else if(match((x0, RET), (x1, ZED), (x2, ZED)))
                return CTC_RET_Zx3;
            else if(match((x0,INTR), (x1, INTR)))
                return CTC_INTRx2;
            else
                return null;
        }

        [Op, MethodImpl(Inline)]
        static ExtractTermCode? scan5(Span<byte> src, int offset, out int delta)
        {
            var x0 = src[offset - 5];
            var x1 = src[offset - 4];
            var x2 = src[offset - 3];
            var x3 = src[offset - 2];
            var x4 = src[offset - 1];
            delta = 0;

            if(match((x0,ZED), (x1,ZED), (x2,J48), (x3,FF), (x4,E0)))
                return CTC_JMP_RAX;
            else
                return null;
        }

        [Op, MethodImpl(Inline)]
        static bool z7(Span<byte> src, int offset)
            =>      src[offset - 6] == ZED
                && (src[offset - 5] == ZED)
                && (src[offset - 4] == ZED)
                && (src[offset - 3] == ZED)
                && (src[offset - 2] == ZED)
                && (src[offset - 1] == ZED)
                && (src[offset - 0] == ZED);


        [Op, MethodImpl(Inline)]
        static bit match((byte x, byte y) a, (byte x, byte y) b)
            => a.x == a.y
            && b.x == b.y;

        [Op, MethodImpl(Inline)]
        static bit match((byte x, byte y) a, (byte x, byte y) b, (byte x, byte y) c)
            => a.x == a.y
            && b.x == b.y
            && c.x == c.y;

        [Op, MethodImpl(Inline)]
        static bit match((byte x, byte y) a, (byte x, byte y) b, (byte x, byte y) c, (byte x, byte y) d, (byte x, byte y) e)
            => a.x == a.y
            && b.x == b.y
            && c.x == c.y
            && d.x == d.y
            && e.x == e.y;

        [Op, MethodImpl(Inline)]
        static ApiCaptureResult summarize(Span<byte> src, OpIdentity id, ExtractTermCode tc, long start, long end, int delta)
        {
            var outcome = CaptureOutcome.create(tc, start, end, delta);
            var raw = src.Slice(0, (int)(end - start)).ToArray();
            var trimmed = src.Slice(0, outcome.ByteCount).ToArray();
            return ApiCaptureResult.create(id, outcome.TermCode, outcome.Range, CodeBlockPair.create((MemoryAddress)start, raw, trimmed));
        }
    }
}