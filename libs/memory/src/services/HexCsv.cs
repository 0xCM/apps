//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static core;

    public class HexCsv : AppService<HexCsv>
    {
        public HexCsv()
        {
        }

        public static ByteSize write(ReadOnlySpan<byte> src, MemoryAddress @base, FS.FilePath dst, byte bpl = HexCsvRow.BPL)
        {
            var formatter = HexDataFormatter.create(@base, bpl);
            using var writer = dst.AsciWriter();
            writer.WriteLine(string.Concat($"Address".PadRight(12), RP.SpacedPipe, "Data"));
            var offset = MemoryAddress.Zero;
            var lines = 0;
            var blocks = src.Length/bpl;
            var cells = src.Length%bpl;
            for(var i=0; i<blocks; i++)
            {
                var data = slice(src,offset,bpl);
                writer.WriteLine(formatter.FormatLine(data, offset, Chars.Pipe));
                offset += bpl;
            }

            writer.WriteLine(formatter.FormatLine(slice(src,offset,cells), offset, Chars.Pipe));
            offset += cells;
            return (ulong)offset;
        }

        public ReadOnlySpan<HexCsvRow> Load(FS.FilePath src)
        {
            var buffer = list<HexCsvRow>();
            void Receive(in HexCsvRow src)
            {
                buffer.Add(src);
            }

            read(src, Receive);
            return buffer.ViewDeposited();
        }

        public static ReadOnlySpan<HexCsvRow> read(FS.FilePath src)
        {
            var buffer = list<HexCsvRow>();
            void Receive(in HexCsvRow src)
            {
                buffer.Add(src);
            }

            read(src, Receive);
            return buffer.ViewDeposited();
        }

        public static void read(FS.FilePath src, Receiver<HexCsvRow> dst)
        {
            var pos = 0u;

            if(!src.Exists)
                core.@throw(new FileNotFoundException(src.ToUri().Format()));

            using var reader = src.Utf8Reader();
            var size = src.Size;
            var header = reader.ReadLine();
            var record = default(HexCsvRow);
            var @continue = true;
            while(@continue)
            {
                if(read(reader, ref pos, ref record))
                    dst(record);
                else
                    @continue = false;
            }
        }

        static bool read(StreamReader src, ref uint pos, ref HexCsvRow data)
        {
            var line = src.ReadLine();
            if(line == null)
                return false;

            pos++;

            var parts = text.split(line, FieldDelimiter);
            if(parts.Length != 2)
                return false;

            DataParser.parse(skip(parts,0), out data.Address);
            DataParser.parse(skip(parts,1), out data.Data);

            return true;
        }
    }
}