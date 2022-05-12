//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    public struct TextDocStats
    {
        public long InputSize;

        public long OutputSize;

        public uint LineCount;
    }

    unsafe class XedDumpImporter : IDisposable
    {
        FS.FilePath Source;

        MemoryFile File;

        MemoryAddress Base;

        const uint Partition = 128;

        readonly uint FileSize;

        readonly uint BlockSize;

        readonly uint BlockCount;

        readonly uint Remainder;

        readonly uint Continuous;

        readonly uint Parts;

        readonly uint PartRemainder;

        TextDocStats Stats;

        static W256 w => default;

        const string FirstItemMarker = "amd_3dnow_opcode:";
        const string LastItemMarker = "EOSZ_LIST:";

        public XedDumpImporter(FS.FilePath src)
        {
            Source = src;
            BlockSize = (uint)w.DataWidth/8;
            File = src.MemoryMap();
            FileSize = File.Size;
            Base = File.BaseAddress;
            BlockCount = FileSize/BlockSize;
            Remainder = FileSize%BlockSize;
            Continuous = BlockCount*BlockSize;
            Parts = BlockCount/Partition;
            PartRemainder = BlockCount%Partition;
        }

        void Decode(MemoryAddress src, uint size)
        {
            var data = core.cover(src.Pointer<byte>(), size);
            add(ref Stats.InputSize, data.Length);
            for(var i=0; i<size; i++)
            {
                if(SQ.nl(skip(data,i)))
                    inc(ref Stats.LineCount);
            }

            var storage = CharBlock32.Null;
            var buffer = recover<ushort>(storage.Data);
            if(size == 32)
            {
                var decoded = Asci.decode(cpu.vload(w256,data));
                add(ref Stats.OutputSize, buffer.Length);
            }
            else
            {
                for(var i=0; i<size; i++)
                {
                    seek(buffer,i) = skip(data,i);
                    add(ref Stats.OutputSize,2);
                }
            }
        }

        public TextDocStats Run()
        {
            var counter = 0u;
            var seg = File.Segment();
            var offset = Base;
            for(var i=0u; i<BlockCount; i++)
            {
                Decode(offset,BlockSize);
                offset = offset + BlockSize;
            }
            Decode(offset, Remainder);

            return Stats;
        }

        public void Dispose()
            => File.Dispose();

        public static LineMap<InstForm> map(FS.FilePath src, FS.FilePath dst)
        {
            const string Pattern = "{0,-6} | {1,-6} | {2,-6} | {3,-6} | {4,-64}";
            const string Marker = "iform:";
            var data = src.ReadLines();
            var seq = 0u;
            var i0 = 0u;
            var buffer = list<LineInterval<InstForm>>();
            using var writer = dst.AsciWriter();
            writer.AppendLineFormat(Pattern,"Seq", "Min", "Max", "Lines", "Form");
            var form = InstForm.Empty;
            for(var i=0u; i<data.Length; i++)
            {
                var line = text.trim(data[i]);
                if(text.begins(line,FirstItemMarker))
                    i0 = i;
                else if(text.begins(line, LastItemMarker))
                {
                    var seg = new LineInterval<InstForm>(form, i0, i);
                    writer.AppendLineFormat(Pattern, seq++, i0, i, (i - i0 + 1), form);
                    buffer.Add(seg);
                }
                else
                {
                    var j = text.index(line,Marker);
                    if(j >= 0)
                    {
                        var k = text.index(line,Chars.Colon);
                        XedParsers.parse(text.trim(text.right(line,k)), out form);
                    }
                }
            }

            return buffer.ToArray();
        }

        public static Index<Point<uint>> LogSegments(FS.FilePath src, FS.FilePath dst)
        {
            const string Pattern = "{0,-6} | {1,-6} | {2,-6}";
            var buffer = list<Point<uint>>();
            var data = src.ReadLines();
            using var writer = dst.AsciWriter();
            writer.AppendLineFormat(Pattern, "Seq", "Min", "Max");
            var seq = 0u;
            var i0 = 0u;
            for(var i=0u; i<data.Length; i++)
            {
                var line = text.trim(data[i]);
                if(text.begins(line,FirstItemMarker))
                    i0 = i;
                else if(text.begins(line, LastItemMarker))
                {
                    buffer.Add((i0,i));
                    writer.AppendLineFormat(Pattern, seq++, i0,  i);
                }
            }
            return buffer.ToArray();
        }
    }
}