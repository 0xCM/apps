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
        /// <summary>
        /// Extracts a contiguous digit sequence from a specified source and writes the elements to a specified target,
        /// and returns the number of digits extracted
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static uint digits(Base2 @base, ReadOnlySpan<char> src, uint offset, Span<char> dst)
        {
            var max = min(src.Length, dst.Length);
            var counter = 0u;
            for(var i=offset; i<max; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(Digital.test(@base,c))
                    seek(dst,counter++) = c;
                else
                    break;
            }
            return counter;
        }

        /// <summary>
        /// Extracts a contiguous digit sequence from a specified source and writes the elements to a specified target,
        /// and returns the number of digits extracted
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static uint digits(Base2 @base, ReadOnlySpan<char> src, Span<char> dst)
            => digits(@base, src, 0, dst);

        /// <summary>
        /// Extracts a contiguous digit sequence from a specified source and writes the elements to a specified target,
        /// and returns the number of digits extracted to the caller
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static uint digits(Base10 @base, ReadOnlySpan<C> src, Span<C> dst)
        {
            var max = min(src.Length, dst.Length);
            var counter = 0u;
            for(var i=0; i<max; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(Digital.test(@base,c))
                    seek(dst,counter++) = c;
                else
                    break;
            }
            return counter;
        }

        /// <summary>
        /// Extracts a contiguous digit sequence from a specified source and writes the elements to a specified target,
        /// and returns the number of digits extracted
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static uint digits(Base10 @base, ReadOnlySpan<char> src, uint offset, Span<char> dst)
        {
            var max = min(src.Length, dst.Length);
            var counter = 0u;
            for(var i=offset; i<max; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(Digital.test(@base,c))
                    seek(dst,counter++) = c;
                else
                    break;
            }
            return counter;
        }

        /// <summary>
        /// Extracts a contiguous digit sequence from a specified source and writes the elements to a specified target,
        /// and returns the number of digits extracted
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static uint digits(Base10 @base, ReadOnlySpan<char> src, Span<char> dst)
            => digits(@base, src, 0, dst);

        /// <summary>
        /// Extracts a contiguous digit sequence from a specified source and writes the elements to a specified target,
        /// and returns the number of digits extracted
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static uint digits(Base16 @base, ReadOnlySpan<char> src, uint offset, Span<char> dst)
        {
            var max = min(src.Length, dst.Length);
            var counter = 0u;
            for(var i=offset; i<max; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(Digital.test(@base,c))
                    seek(dst,counter++) = c;
                else
                    break;
            }
            return counter;
        }

        /// <summary>
        /// Extracts a contiguous digit sequence from a specified source and writes the elements to a specified target,
        /// and returns the number of digits extracted
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static uint digits(Base16 @base, ReadOnlySpan<char> src, Span<char> dst)
            => digits(@base, src, 0, dst);

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