//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    using Asm;

    using static Root;
    using static core;

    public class XedDisasmSvc : AppService<XedDisasmSvc>
    {
        public FS.Files DisasmFiles(IProjectWs ws)
            => ws.OutFiles(FS.ext("xed.txt"));

        public Index<AsmStatementEncoding> Collect(IProjectWs project)
        {
            var result = Outcome.Success;
            var paths = DisasmFiles(project);
            var records = ParseEncodings(paths);
            var count = paths.Length;
            var dst = ProjectDb.ProjectData() + FS.file(string.Format("xed.disasm.{0}", project.Project), FS.Csv);
            TableEmit(records.View, AsmStatementEncoding.RenderWidths, dst);
            return records;
        }

        public Index<AsmStatementEncoding> ParseEncodings(ReadOnlySpan<FS.FilePath> src)
        {
            var dst = list<AsmStatementEncoding>();
            var counter = 0u;
            var count = src.Length;

            for(var i=0; i<count; i++)
            {
                var result = ParseEncodings(skip(src,i), dst);
                if(result.Fail)
                {
                    Error(result.Message);
                    return sys.empty<AsmStatementEncoding>();
                }
            }

            var encodings = dst.ToArray();
            for(var i=0u; i<encodings.Length; i++)
                seek(encodings,i).Seq = i;

            return encodings;
        }

        public Index<AsmStatementEncoding> ParseEncodings(FS.FilePath src)
        {
            var dst = list<AsmStatementEncoding>();
            var result = ParseEncodings(src,dst);
            if(result.Fail)
                Error(result);
            return dst.ToArray();
        }

        public Index<XedDisasmBlock> ParseBlocks(FS.FilePath src)
        {
            var lines = src.ReadNumberedLines();
            var count = lines.Length;
            var dst = list<XedDisasmBlock>();
            var blocklines = list<TextLine>();
            var imax = count-1;
            for(var i=0; i<imax; i++)
            {
                blocklines.Clear();

                ref readonly var l0 = ref skip(lines,i);
                ref readonly var l1 = ref skip(lines,i+1);
                if(l0.IsNonEmpty && l1.IsNonEmpty)
                {
                    ref readonly var c0 = ref l0.Content;
                    ref readonly var c1 = ref l1.Content;
                    if(c1[0] == '0')
                    {
                        blocklines.Add(l0);
                        blocklines.Add(l1);
                        i++;
                        while(i++ < imax)
                        {
                            ref readonly var l = ref skip(lines,i);
                            blocklines.Add(l);
                            if(l.StartsWith("XDIS"))
                                break;
                        }
                        dst.Add(blocklines.ToArray());
                    }
                }
            }

            return dst.ToArray();
        }

        ReadOnlySpan<TextLine> SummaryLines(ReadOnlySpan<XedDisasmBlock> src)
        {
            var dst = list<TextLine>();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                var lines = skip(src,i).Lines;
                var lcount = lines.Count;
                for(var j=0; j<lcount; j++)
                {
                    ref readonly var line = ref lines[j];
                    if(j == lcount-1)
                        dst.Add(line);
                }
            }
            return dst.ViewDeposited();
        }

        ReadOnlySpan<AsmExpr> Expressions(ReadOnlySpan<XedDisasmBlock> src)
        {
            const string Marker = "YDIS:";
            var dst = list<AsmExpr>();
            foreach(var block in src)
            {
                foreach(var line in block.Lines)
                {
                    var i = text.index(line.Content,"YDIS:");
                    if(i >= 0)
                        dst.Add(text.trim(text.right(line.Content, i + Marker.Length)));
                }
            }
            return dst.ViewDeposited();
        }

        Outcome ParseEncodings(FS.FilePath src, List<AsmStatementEncoding> dst)
        {
            var blocks = ParseBlocks(src);
            var summaries = SummaryLines(blocks);
            var expressions = Expressions(blocks);
            var counter = 0u;
            var count = summaries.Length;
            var result = Outcome.Success;
            if(expressions.Length != count)
            {
                return (false, string.Format("{0} != {1}", expressions.Length - 1, count));
            }

            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(summaries,i);
                ref readonly var content = ref line.Content;
                var record = new AsmStatementEncoding();
                ref readonly var expression = ref skip(expressions,i);
                record.DocSeq = counter++;
                record.Asm = expression;
                record.Line = line.LineNumber;
                result = ParseXedOffset(content, out record.Offset);
                if(result.Fail)
                    return result;

                result = ParseHexCode(line, out record.Encoding);
                if(result.Fail)
                    return result;

                dst.Add(record);
            }

            return true;
        }

        const string XDIS = "XDIS ";

        static Outcome ParseXedOffset(string src, out Address32 dst)
        {
            const string Marker = "XDIS ";
            var i = text.index(src,XDIS);
            var j = XDIS.Length;
            var k = text.index(src, Chars.Colon);
            var length = k-j;
            var result = Outcome.Failure;
            dst = 0;
            if(j >= 0 && length > 0)
            {
                var spec = text.slice(src,j,length).Trim();
                result = DataParser.parse(spec, out dst);
            }
            return result;
        }

        static Outcome ParseHexCode(TextLine src, out AsmHexCode dst)
        {
            var result = Outcome.Failure;
            dst = AsmHexCode.Empty;
            var buffer = span<byte>(16);

            if(src.StartsWith(XDIS))
            {
                ref readonly var content = ref src.Content;
                var k = text.index(content, Chars.Colon);
                if(k > 0)
                {
                    var parts = text.words(text.right(content,k));
                    if(parts.Length >=3)
                    {
                        var count = HexParser.parse(parts[2], buffer);
                        if(count)
                        {
                            dst = slice(buffer,0,count).ToArray();
                            result = Outcome.Success;
                        }
                    }
                }
            }

            return result;
        }
    }
}