//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using C = AsciCode;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline)]
        public static uint digits(Base10 @base, ReadOnlySpan<C> src, Span<C> dst)
            => Digital.digits(@base, src, dst);

        [MethodImpl(Inline)]
        public static uint digits(Base10 @base, ReadOnlySpan<char> src, uint offset, Span<char> dst)
            => Digital.digits(@base, src, offset, dst);

        [MethodImpl(Inline)]
        public static uint digits(Base10 @base, ReadOnlySpan<char> src, Span<char> dst)
            => Digital.digits(@base, src, dst);

        /// <summary>
        /// Extracts a contiguous sequence of digits from a specified source
        /// </summary>
        /// <param name="n">The maximum number of digits to extract</param>
        /// <param name="base">The mathematical base</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<C> digits(N16 n, Base10 @base, ReadOnlySpan<C> src)
        {
            var storage = ByteBlock16.Empty;
            var dst = recover<C>(storage.Bytes);
            var count = digits(base10, src, dst);
            return count == 0 ? default : slice(dst,0,count);
        }

        /// <summary>
        /// Extracts a contiguous sequence of digits from a specified source
        /// </summary>
        /// <param name="n">The maximum number of digits to extract</param>
        /// <param name="base">The mathematical base</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> digits(N16 n, Base10 @base, ReadOnlySpan<char> src)
        {
            var storage = CharBlock16.Null;
            var dst = storage.Data;
            var count = digits(base10, src, dst);
            return count == 0 ? default : slice(dst,0,count);
        }
    }
}