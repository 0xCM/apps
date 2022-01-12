//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct ApiExtracts
    {

        [MethodImpl(Inline), Op]
        internal static unsafe int read(ref byte* pSrc, int count, Span<byte> dst)
            => read(ref pSrc, count, ref first(dst));

        [MethodImpl(Inline), Op]
        internal static unsafe int read(ref byte* pSrc, int limit, ref byte dst)
        {
            var offset = 0;
            var count = 0;
            while(offset<limit && count<MaxZeroCount)
            {
                var value = Unsafe.Read<byte>(pSrc++);
                seek(dst, offset++) = value;
                if(value != 0)
                    count = 0;
                else
                    count++;
            }
            return offset;
        }

        [MethodImpl(Inline), Op]
        internal static unsafe int extract(MemoryAddress src, Span<byte> dst)
        {
            var pSrc = src.Pointer<byte>();
            var limit = dst.Length;
            return read(ref pSrc, limit, dst);
        }

        [MethodImpl(Inline), Op]
        internal static EncodingParser encodings(byte[] buffer)
            => new EncodingParser(EncodingPatterns.Default, buffer);

        [MethodImpl(Inline), Op]
        internal static bool failed(EncodingParserState state)
            => state == EncodingParserState.Failed;

        [MethodImpl(Inline), Op]
        internal static ExtractTermCode termcode(EncodingPatternKind src)
        {
            if(src != 0)
                return (ExtractTermCode)src;
            else
                return ExtractTermCode.Fail;
        }

        [MethodImpl(Inline), Op]
        internal static ReadOnlySpan<byte> parsed(in EncodingParser parser)
            => (parser.Offset + parser.Delta - 1) > 0 ? parser.Buffer.Slice(0, parser.Offset + parser.Delta - 1) : Array.Empty<byte>();

    }
}