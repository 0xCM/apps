//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using D = DecimalDigitFacets;

    [Free,ApiHost]
    public class AsciLines
    {
        [Op]
        public static LineCount count(FS.FilePath src)
            => (src, count(src.ReadBytes()));

        public static void emit(ReadOnlySpan<LineStats> src, FS.FilePath dst)
        {
            using var writer = dst.AsciWriter();
            writer.WriteLine(LineStats.Header);
            for(var i=0; i<src.Length; i++)
                writer.WriteLine(skip(src,i).Format());
        }

        public static Index<LineStats> stats(FS.FilePath src)
        {
            var data = src.ReadBytes();
            var count = AsciLines.count(data);
            var dst = alloc<LineStats>(count);
            for(var i=0; i<count; i++)
            {

            }
            return dst;
        }
        public static ReadOnlySpan<LineStats> stats(ReadOnlySpan<byte> data, uint buffer = 0)
        {
            var dst = span<LineStats>(buffer);
            var last = 0u;
            var counter = 0u;
            var j=0u;
            for(var i=0u; i<data.Length && i < buffer; i++)
            {
                if(SQ.nl(skip(data,i)))
                {
                    var offset = i;
                    var length = (byte)(offset - last);
                    seek(dst,j++) = new LineStats(counter++, offset, length);
                    last = offset;
                }
            }

            return slice(dst,0,j);
        }

        [Op]
        public static Index<LineCount> count(ReadOnlySpan<FS.FilePath> src)
        {
            var dst = bag<LineCount>();
            iter(src, path => dst.Add(count(path)), true);
            return dst.ToArray().Sort();
        }

        public static Index<LineStats> stats(MemoryFile src, uint buffer = 0)
        {
            var dst = list<LineStats>(buffer);
            var data = src.View();
            var last = 0u;
            var counter = 0u;
            for(var i=0u; i<data.Length; i++)
            {
                if(SQ.nl(skip(data,i)))
                {
                    var offset = i;
                    var length = (byte)(offset - last);
                    dst.Add(new LineStats(counter++, offset, length));
                    last = offset;
                }
            }

            return dst.Array();
        }

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

        [MethodImpl(Inline), Op]
        public static bool empty(ReadOnlySpan<char> src, uint offset)
        {
            var last = src.Length - 1;
            if(offset < last - 1)
                return SQ.eol(skip(src, offset), skip(src, offset + 1));
            return true;
        }

        [MethodImpl(Inline), Op]
        public static bool empty(ReadOnlySpan<AsciCode> src, uint offset)
            => empty(recover<AsciCode,byte>(src), offset);

        [MethodImpl(Inline), Op]
        public static bool empty(ReadOnlySpan<byte> src, uint offset)
        {
            var last = src.Length - 1;
            if(offset < last - 1)
                return SQ.eol(skip(src, offset), skip(src, offset + 1));
            return true;
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
                        dst = asci<byte>(text.asci(text.slice(src, i0, length)).View);
                        i+=2;
                        break;
                    }
                }
            }
            return length;
        }

        public static void load(FS.FilePath src)
        {
            using var map = MemoryFiles.map(src);
            var data = map.View<AsciSymbol>();
            var count = AsciLines.count(data);
        }

        [MethodImpl(Inline), Op]
        public static uint count(ReadOnlySpan<AsciSymbol> src)
            => count(recover<AsciSymbol,byte>(src));

        [MethodImpl(Inline), Op]
        public static uint count(ReadOnlySpan<AsciCode> src)
            => count(recover<AsciCode,byte>(src));

        // static uint count(ReadOnlySpan<byte> src, List<byte> dst)
        // {

        // }
        /// <summary>
        /// Counts the number of asci-encoded lines represented in the source
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        static uint count(ReadOnlySpan<byte> src)
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

        public static EnvVars<string> env(FS.FilePath src, char sep = Chars.Eq)
        {
            var k = z16;
            var dst = list<EnvVar<string>>();
            var line = AsciLineCover.Empty;
            var buffer = alloc<char>(1024*4);
            using var reader = src.AsciLineReader();
            while(reader.Next(out line))
            {
                var content = line.Codes;
                var i = SQ.index(content, sep);
                if(i == NotFound)
                    continue;

                var _name = text.format(SQ.left(content,i), buffer);
                var _value = text.format(SQ.right(content,i), buffer);
                dst.Add(new (_name, _value));
            }
            return dst.ToArray().Sort();
        }

        public static Settings settings(FS.FilePath src)
        {
            const char sep = Chars.Pipe;
            using var reader = src.AsciLineReader();
            var dst = list<Setting>();
            var line = AsciLineCover.Empty;
            if(reader.Next(out line))
            {
                while(reader.Next(out line))
                {
                    var content = line.Codes;
                    if(first(content) == AsciCode.Pipe)
                        content = slice(content,1);
                    var length = content.Length;
                    if(length != 0)
                    {
                        var i = SQ.index(content, sep);
                        if(i > 0)
                        {
                            var name = text.trim(text.format(SQ.left(content,i)));
                            var value = text.trim(text.format(SQ.right(content,i)));
                            dst.Add(new Setting(name, value));
                        }
                    }

                }
            }
            return new Settings(dst.ToArray());
        }

        public static Settings config(FS.FilePath src, char sep = Chars.Colon)
        {
            var dst = list<Setting>();
            var line = AsciLineCover.Empty;
            using var reader = src.AsciLineReader();
            while(reader.Next(out line))
            {
                var content = line.Codes;
                var length = content.Length;
                if(length != 0)
                {
                    if(SQ.hash(first(content)))
                        continue;

                    var i = SQ.index(content, sep);
                    if(i > 0)
                    {
                        var name = text.format(SQ.left(content,i));
                        var value = text.format(SQ.right(content,i));
                        dst.Add(new Setting(name,value));
                    }
                }
            }
            return new Settings(dst.ToArray());
        }

        [Op]
        public static bool search<K,T>(in Settings<K,T> src, K key, out Setting<K,T> value)
            where K : unmanaged, INamed<K>, IEquatable<K>
        {
            value = Setting<K,T>.Empty;
            var result = false;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var setting = ref src[i];
                if(setting.Name.Equals(key))
                {
                    value = setting;
                    result = true;
                }
            }
            return result;
        }

        [MethodImpl(Inline), Op]
        public static CmdFlagSpec flag(string name, string desc)
            => new CmdFlagSpec(name, desc);

        [MethodImpl(Inline), Op]
        static bool test(Base10 @base, byte c)
            => (DecimalDigitValue)c >= D.MinDigit && (DecimalDigitValue)c <= D.MaxDigit;

        [Op]
        public static bool number(ReadOnlySpan<byte> src, out uint j, out LineNumber dst)
        {
            j=0;
            dst = 0;
            const char Delimiter = Chars.Colon;
            const byte LastIndex = 8;
            const byte ContentLength = 9;

            var result = false;
            var storage = CharBlock8.Null;
            var buffer = storage.Data;

            while(j++ <= LastIndex)
            {
                ref readonly var c = ref skip(src, j);
                if(test(base10, c))
                    seek(buffer, j) = (char)c;
                else if(c == Delimiter && j==LastIndex)
                {
                    result = uint.TryParse(buffer, out var n);
                    if(result)
                        dst = n;
                    break;
                }
                else
                    break;
            }
            return result;
        }
    }
}