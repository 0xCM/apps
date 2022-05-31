//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class HexEmitter : AppService<HexEmitter>
    {
        public static BinaryCode compact(HexDataRow[] src)
        {
            var count = src.Length;
            if(count == 0)
                return BinaryCode.Empty;

            var size = src.TotalSize();
            var dst = alloc<byte>(size);
            var offset = 0u;
            for(var i=0; i<count; i++)
            {
                var data = skip(src,i).Data.View;
                for(var j=0; j<data.Length; j++)
                    seek(dst,offset++) = skip(data,j);

            }
            return dst;
        }

        [MethodImpl(Inline)]
        public static uint size(Index<BinaryCode> src)
            => src.Storage.Select(x => x.Count).Sum();

        public static BinaryCode compact(Index<BinaryCode> src)
        {
            var count = src.Count;
            if(count == 0)
                return BinaryCode.Empty;
            var dst = alloc<byte>(size(src));
            var k = 0u;
            for(var i=0u; i<count; i++)
            {
                var data = src[i].View;
                for(var j=0u; j<data.Length; j++, k++)
                    seek(dst, k) = skip(data, j);
            }
            return dst;
        }

        public ByteSize EmitBasedRows(ReadOnlySpan<byte> src, ushort rowsize, FS.FilePath dst)
        {
            const char Delimiter = Chars.Pipe;
            var @base = MemoryAddress.Zero;
            var size = src.Length;
            var flow = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var formatter = HexDataFormatter.create(@base, rowsize, false);
            var buffer = alloc<byte>(rowsize);
            var parts = size/rowsize;
            var offset = @base;
            var data = default(ReadOnlySpan<byte>);
            for(var i=0; i<parts; i++)
            {
                data = slice(src, offset, rowsize);
                writer.WriteLine(formatter.FormatLine(data, offset, Delimiter));
                offset += rowsize;
            }

            var remainder = size % rowsize;
            if(remainder != 0)
            {
                data = slice(src, offset, remainder);
                writer.WriteLine(formatter.FormatLine(data, offset, Delimiter));
            }

            EmittedFile(flow,size);
            return size;
        }

        public ByteSize EmitHexArray(byte[] src, FS.FilePath dst)
        {
            var array = Hex.hexarray(src);
            var size = src.Length;
            var flow = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            writer.WriteLine(array.Format(false));
            EmittedFile(flow, size);
            return size;
        }

        public Outcome EmitHexArrays(ReadOnlySpan<FS.FilePath> src, FS.FolderPath dir)
        {
            var result = Outcome.Success;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var dst = dir + FS.file(path.FileName.Format(), FS.XArray);
                var data = HexArray.cover(path.ReadBytes());
                var size = data.Length;
                using var writer = dst.AsciWriter();
                writer.WriteLine(data.Format(true));
                Write(string.Format("({0} bytes)[{1} -> {2}]", size, path.ToUri(), dst.ToUri()));
            }

            return result;
        }
    }
}