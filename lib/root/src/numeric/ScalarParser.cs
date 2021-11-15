//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public readonly struct ScalarParser
    {
        [Op, MethodImpl(Inline)]
        public static bool parse(Base10 @base, ReadOnlySpan<char> src, out sbyte dst)
            => sbyte.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool parse(Base10 @base, ReadOnlySpan<char> src, out byte dst)
            => byte.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool parse(Base10 @base, ReadOnlySpan<char> src, out short dst)
            => short.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool parse(Base10 @base, ReadOnlySpan<char> src, out ushort dst)
            => ushort.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool parse(Base10 @base, ReadOnlySpan<char> src, out int dst)
            => int.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool parse(Base10 @base, ReadOnlySpan<char> src, out uint dst)
            => uint.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool parse(Base10 @base, ReadOnlySpan<char> src, out long dst)
            => long.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool parse(Base10 @base, ReadOnlySpan<char> src, out ulong dst)
            => ulong.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool parse(Base10 @base, ReadOnlySpan<char> src, out float dst)
            => float.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool parse(Base10 @base, ReadOnlySpan<char> src, out double dst)
            => double.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool int8(Base10 @base, ReadOnlySpan<char> src, out sbyte dst)
            => sbyte.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool uint8(Base10 @base, ReadOnlySpan<char> src, out byte dst)
            => byte.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool int16(Base10 @base, ReadOnlySpan<char> src, out short dst)
            => short.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool uint16(Base10 @base, ReadOnlySpan<char> src, out ushort dst)
            => ushort.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool int32(Base10 @base, ReadOnlySpan<char> src, out int dst)
            => int.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool uint32(Base10 @base, ReadOnlySpan<char> src, out uint dst)
            => uint.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool int64(Base10 @base, ReadOnlySpan<char> src, out long dst)
            => long.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool uint64(Base10 @base, ReadOnlySpan<char> src, out ulong dst)
            => ulong.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool float32(Base10 @base, ReadOnlySpan<char> src, out float dst)
            => float.TryParse(src, out dst);

        [Op, MethodImpl(Inline)]
        public static bool float64(Base10 @base, ReadOnlySpan<char> src, out double dst)
            => double.TryParse(src, out dst);
    }
}