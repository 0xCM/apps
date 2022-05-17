//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    using static core;

    using SQ = SymbolicQuery;
    using C = AsciCode;

    using Asm;

    partial class DumpBin
    {
        public class DumpBinProcessor : AppService<DumpBinProcessor>
        {
            readonly Index<char> _LineBuffer;

            public DumpBinProcessor()
            {
                _LineBuffer = alloc<char>(256);
            }

            public uint LineCount(ReadOnlySpan<byte> src)
                => Lines.count(src);

            public uint MaxLineLength(ReadOnlySpan<byte> src)
                => AsciLines.maxlength(src);

            Span<char> StatementBuffer()
                => _LineBuffer.Clear().Edit;

            public static MsgPattern<C> MarkerCodeNotFound => "Markier '{0}' not found";

            Outcome ProcessLine(ref AsciLine src, out DumpBinDisasm dst)
            {
                dst = default;
                var i = SQ.index(src.Codes, C.Colon);
                if(i == NotFound)
                    return (false, MarkerCodeNotFound.Format(C.Colon));

                var left = slice(src.Codes, 0, i);
                var right = slice(src.Codes, i + 1);
                var j=0u;
                var result = Hex.parse(left,out ulong offset);
                if(result.Fail)
                    return result;

                var buffer = StatementBuffer();
                var count = text.render(right, ref j, buffer);
                dst = DumpBinDisasm.define(offset, text.format(slice(buffer,0,count)));
                return true;
            }

            public void ParseDisassembly(FS.FilePath src, FS.FilePath dst)
            {
                using var map = MemoryFiles.map(src);
                var flow = Wf.EmittingFile(dst);
                var outcome = TransformData(map.View<byte>(), dst);
                Wf.EmittedFile(flow, 0);
            }

            Outcome TransformData(ReadOnlySpan<byte> src, FS.FilePath dst)
            {
                var lines = LineCount(src);
                var size = (ByteSize)src.Length;
                var max = MaxLineLength(src);
                using var writer = dst.Writer(Encoding.ASCII);
                Span<char> buffer = alloc<char>(max);
                var pos = 0u;
                var length = 0u;
                var offset = 0u;
                var number = 0u;
                while(pos++ < size -1)
                {
                    ref readonly var a0 = ref skip(src, pos);
                    ref readonly var a1 = ref skip(src, pos + 1);
                    if(SQ.eol(a0,a1))
                    {
                        var line = AsciLines.line(src, offset, length + 1);
                        number++;
                        if(!SQ.contains(line.Codes, C.Colon) || number < 4)
                        {
                            pos++;
                            length = 0;
                            offset = pos;
                            continue;
                        }

                        var outcome = ProcessLine(ref line, out var content);
                        if(outcome.Fail)
                        {
                            Wf.Error(string.Format("Error processing line {0}:{1} - {2}", number, line.Format(), outcome.Message));
                            break;
                        }
                        buffer.Clear();
                        writer.WriteLine(DumpBinDisasm.format(content,buffer));
                        pos++;
                        length = 0;
                        offset = pos;
                    }
                    else
                        length++;
                }

                return true;
            }
        }
    }
}