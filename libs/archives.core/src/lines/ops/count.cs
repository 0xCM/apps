//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using SQ = SymbolicQuery;

    partial struct Lines
    {
        [Op]
        public static LineCount count(FS.FilePath src)
            => (src, Lines.count(src.ReadBytes()));

        [Op]
        public static Index<LineCount> count(ReadOnlySpan<FS.FilePath> src)
        {
            var dst = bag<LineCount>();
            iter(src, path => dst.Add(count(path)), true);
            return dst.ToArray().Sort();
        }

        [Op]
        public static uint count(FS.FilePath src, TextEncodingKind encoding)
        {
            var counter = 0u;
            using var reader = src.Reader(encoding);
            var line = reader.ReadLine();
            while(line != null)
            {
                counter++;
                line = reader.ReadLine();
            }

            return counter;
        }

        /// <summary>
        /// Counts the number of asci-encoded lines represented in the source
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static uint count(ReadOnlySpan<byte> src)
        {
            var size = src.Length;
            var counter = 0u;
            for(var pos=0u; pos<size- 1; pos++)
            {
                ref readonly var a0 = ref skip(src, pos);
                ref readonly var a1 = ref skip(src, pos + 1);
                if(SQ.eol(a0,a1))
                    counter++;
            }
            return counter;
        }

        /// <summary>
        /// Counts the number of lines represented in the source
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static uint count(ReadOnlySpan<char> src)
        {
            var size = src.Length;
            var counter = 0u;
            for(var pos=0u; pos<size- 1; pos++)
            {
                ref readonly var a0 = ref skip(src, pos);
                ref readonly var a1 = ref skip(src, pos + 1);
                if(SQ.eol(a0,a1))
                    counter++;
            }
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static uint count(ReadOnlySpan<AsciCode> src)
            => count(recover<AsciCode,byte>(src));
    }
}