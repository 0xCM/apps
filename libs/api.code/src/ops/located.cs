//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Arrays;

    partial class ApiCode
    {
        public static void located(IDbArchive src, IMemoryDispenser alloc)
        {
            var dst = bag<HexCsvRow>();        
            iter(src.Files(FileKind.LocatedHex), file => located(file, alloc), PllExec);   
        }

        static bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.get().PllExec();
        }

        public static void located(FS.FilePath src, IMemoryDispenser alloc)
        {
            var size = ByteSize.Zero;
            void calc(in HexCsvRow row)
            {
                size += row.Data.Size;
            }
            located(src, calc);            

            var memory = alloc.Memory(size);
            void fill(in HexCsvRow row)
            {
                
            }

        }

        public static void located(FS.FilePath src, Receiver<HexCsvRow> dst)
        {
            var pos = 0u;
            using var reader = src.AsciReader();
            var size = src.Size;
            var record = HexCsvRow.Empty;
            var @continue = true;
            while(@continue)
                @continue = read(reader, ref pos, dst);
        }

        static bool read(StreamReader src, ref uint pos, Receiver<HexCsvRow> dst)
        {
            var line = src.ReadLine();
            if(line == null)
                return false;

            pos++;

            var parts = text.split(line, FieldDelimiter);
            if(parts.Length != 2)
                return false;

            AddressParser.parse(skip(parts,0), out MemoryAddress location);
            Hex.code(skip(parts,1), out BinaryCode cde);

            return true;
        }
    }
}