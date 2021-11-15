//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;

    using static Root;
    using static core;

    public class HexCsvReader : AppService<HexCsvReader>
    {
        uint CurrentIndex;

        public HexCsvReader()
        {
            CurrentIndex = 0;
        }

        public ReadOnlySpan<HexCsv> Load(FS.FilePath src)
        {
            var buffer = list<HexCsv>();
            void Receive(in HexCsv src)
            {
                buffer.Add(src);
            }

            Read(src, Receive);
            return buffer.ViewDeposited();
        }

        public void Read(FS.FilePath src, Receiver<HexCsv> dst)
        {
            CurrentIndex = 0;

            if(!src.Exists)
                core.@throw(new FileNotFoundException(src.ToUri().Format()));

            using var reader = src.Utf8Reader();
            var size = src.Size;
            var header = reader.ReadLine();
            var record = default(HexCsv);
            var @continue = true;
            while(@continue)
            {
                if(Read(reader, ref record))
                    dst(record);
                else
                    @continue = false;
            }
        }

        public bool Read(StreamReader src, ref HexCsv data)
        {
            var line = src.ReadLine();
            if(line == null)
                return false;

            CurrentIndex++;

            var parts = text.split(line, FieldDelimiter);
            if(parts.Length != 2)
                return false;

            DataParser.parse(skip(parts,0), out data.Address);
            DataParser.parse(skip(parts,1), out data.Data);

            return true;
        }
    }
}