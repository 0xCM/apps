//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Lines
    {
        [MethodImpl(Inline)]
        public static AsciLineCover<T> asci<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => new AsciLineCover<T>(src);

        [MethodImpl(Inline), Op]
        public static AsciLineCover asci(ReadOnlySpan<byte> src)
            => new AsciLineCover(src);

        [MethodImpl(Inline), Op]
        public static uint asci(ReadOnlySpan<AsciCode> src, ref uint number, ref uint i, out AsciLineCover dst)
            => asci(core.recover<AsciCode,byte>(src), ref number, ref i, out dst);

        [MethodImpl(Inline), Op]
        public static AsciLineCover asci(ReadOnlySpan<byte> src, uint offset, uint length)
            => new AsciLineCover(slice(src,offset,length));

        [MethodImpl(Inline), Op]
        public static uint asci(ReadOnlySpan<byte> src, ref uint number, ref uint i, out AsciLineCover dst)
        {
            var i0 = i;
            dst = default;
            var max = src.Length;
            var length = 0u;
            while(i++ < max - 1)
            {
                if(SQ.eol(skip(src, i), skip(src, i + 1)))
                {
                    length = i - i0;
                    dst = new AsciLineCover(slice(src, i0, length));
                    ++number;
                    i+=2;
                    break;
                }
            }

            return length;
        }

        /// <summary>
        /// Reads a <see cref='AsciLineCover{bytee}'/> from the data source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="number">The current line count</param>
        /// <param name="i">The source-relative offset</param>
        /// <param name="dst">The target</param>
        [Op]
        public static uint asci(string src, ref uint number, ref uint i, out AsciLineCover<byte> dst)
        {
            var i0 = i;
            dst = AsciLineCover<byte>.Empty;
            var max = src.Length;
            var length = 0u;
            var data = span(src);
            if(empty(src,i))
            {
                i+=2;
            }
            else
            {
                while(i++ < max - 1)
                {
                    if(SQ.eol(skip(data, i), skip(data, i + 1)))
                    {
                        length = i - i0;
                        dst = Lines.asci<byte>(text.asci(text.slice(src, i0, length)).View);
                        i+=2;
                        break;
                    }
                }
            }
            return length;
        }
    }
}