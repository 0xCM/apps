//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    using System.IO;

    partial class XedImport
    {
        [Op]
        static ReadOnlySpan<string> lines(string src, bool keepblank = false, bool trim = true)
        {
            var lines = list<string>();
            var lineNumber = 0u;
            using(var reader = new StringReader(src))
            {
                var next = reader.ReadLine();
                while(next != null)
                {
                    if(text.blank(next))
                    {
                        if(keepblank)
                        {
                            lines.Add(next);
                            ++lineNumber;
                        }
                    }
                    else
                    {
                        lines.Add(trim ? text.trim(next) : next);
                        ++lineNumber;
                    }

                    next = reader.ReadLine();
                }
            }
            return lines.ViewDeposited();
        }

        public unsafe class InstBlockImporter : IDisposable
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

            public InstBlockImporter(FS.FilePath src)
            {
                Source = src;
                BlockSize = (uint)w.DataWidth/8;
                File = src.MemoryMap(true);
                FileSize = (uint)File.Size;
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

            void Decode()
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
            }

            ReadOnlySpan<string> ReadLines()
            {
                using var reader = new StreamReader(File.Stream);
                return lines(reader.ReadToEnd());
            }

            public LineMap<InstForm> CalcLineMap()
            {
                const string Pattern = "{0,-6} | {1,-6} | {2,-6} | {3,-6} | {4,-64}";
                const string Marker = "iform:";
                var data = ReadLines();
                var seq = 0u;
                var i0 = 0u;
                var buffer = list<LineInterval<InstForm>>();
                var form = InstForm.Empty;
                for(var i=0u; i<data.Length; i++)
                {
                    var line = text.trim(skip(data,i));
                    if(text.begins(line,FirstItemMarker))
                        i0 = i;
                    else if(text.begins(line, LastItemMarker))
                    {
                        var seg = new LineInterval<InstForm>(form, i0, i);
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

            public TextDocStats Run(IInstBlockReceiver dst)
            {
                distribute(dst);
                dst.Emit();
                return Stats;
            }

            void IDisposable.Dispose()
                => File.Dispose();

            [MethodImpl(Inline)]
            public static InstDataBlock block(uint seq, InstForm form, uint i0, uint i1, ReadOnlySpan<string> src)
                => new InstDataBlock(seq, i0, i1, form, segment(src, i0, i1));

            void distribute(IInstBlockReceiver dst)
            {
                const string Marker = "iform:";
                var lines = ReadLines();
                var seq = 0u;
                var i0 = 0u;
                var form = InstForm.Empty;
                for(var i=0u; i<lines.Length; i++)
                {
                    var line = text.trim(skip(lines,i));
                    if(text.begins(line,FirstItemMarker))
                        i0 = i;
                    else if(text.begins(line, LastItemMarker))
                        dst.Accept(block(seq++, form, i0, i, lines));
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
            }

            public LineMap<InstForm> EmitLineMap(FS.FilePath dst)
            {
                const string Pattern = "{0,-6} | {1,-6} | {2,-6} | {3,-6} | {4,-64}";
                var data = CalcLineMap();
                var seq = 0u;

                using var writer = dst.AsciWriter();
                writer.AppendLineFormat(Pattern,"Seq", "Min", "Max", "Lines", "Form");
                for(var i=0u; i<data.IntervalCount; i++)
                {
                    ref readonly var seg = ref data[i];
                    writer.AppendLineFormat(Pattern, seq++, seg.MinLine, seg.MaxLine, seg.LineCount, seg.Id);
                }

                return data;
            }
        }
    }
}