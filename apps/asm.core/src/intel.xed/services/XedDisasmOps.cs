//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using Asm;
    using static Root;
    using static core;

    using static XedModels;

    public readonly struct XedDisasmOps
    {
        const string XDIS = "XDIS ";

        const string YDIS = "YDIS:";

        public static Outcome ParseEncodings(FS.FilePath src, List<AsmStatementEncoding> dst)
            => ParseEncodings(LoadBlocks(src), dst);

        public static Outcome ParseEncodings(ReadOnlySpan<DisasmLineBlock> blocks, List<AsmStatementEncoding> dst)
        {
            var summaries = SummaryLines(blocks);
            var expr = expressions(blocks);
            var counter = 0u;
            var count = summaries.Length;
            var result = Outcome.Success;
            if(expr.Length != count)
                return (false, string.Format("{0} != {1}", expr.Length - 1, count));

            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(summaries,i);
                ref readonly var content = ref line.Content;
                var record = new AsmStatementEncoding();
                ref readonly var expression = ref skip(expr,i);
                record.DocSeq = counter++;
                record.Asm = expression;
                record.Line = line.LineNumber;
                result = ParseIP(content, out record.Offset);
                if(result.Fail)
                    return result;

                result = ParseHexCode(line, out record.Encoding);
                if(result.Fail)
                    return result;

                dst.Add(record);
            }

            return true;
        }

        public static Outcome ParseEncodings(FS.FilePath src, out SourceEncodings dst)
        {
            var buffer = list<AsmStatementEncoding>();
            var result = ParseEncodings(src,buffer);
            if(result)
                dst = new SourceEncodings(src, buffer.ToArray());
            return result;
        }

        public static ConstLookup<FS.FilePath,DisasmFileBlocks> LoadFileBlocks(FS.Files src)
        {
            var dst = dict<FS.FilePath,DisasmFileBlocks>();
            var blocks = list<DisasmLineBlock>();
            foreach(var path in src)
            {
                blocks.Clear();
                LoadBlocks(path,blocks);
                dst[path] = new DisasmFileBlocks(path, blocks.ToArray());
            }
            return dst;
        }

        public static Index<DisasmLineBlock> LoadBlocks(FS.FilePath src)
        {
            var lines = src.ReadNumberedLines();
            var count = lines.Length;
            var dst = list<DisasmLineBlock>();
            LoadBlocks(src,dst);
            return dst.ToArray();
        }

        public static void LoadBlocks(FS.FilePath src, List<DisasmLineBlock> dst)
        {
            var lines = src.ReadNumberedLines();
            var count = lines.Length;
            var blocklines = list<TextLine>();
            var imax = count-1;
            for(var i=0; i<imax; i++)
            {
                blocklines.Clear();

                ref readonly var l0 = ref lines[i];
                ref readonly var l1 = ref lines[i+1];
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
                            ref readonly var l = ref lines[i];
                            blocklines.Add(l);
                            if(l.StartsWith(XDIS))
                                break;
                        }
                        dst.Add(blocklines.ToArray());
                    }
                }
            }
        }

        public static Outcome ParseIP(string src, out Address32 dst)
        {
            var result = Outcome.Failure;
            var i = text.index(src, XDIS);
            var j = XDIS.Length;
            var k = text.index(src, Chars.Colon);
            var length = k-j;
            dst = 0;
            if(j >= 0 && length > 0)
                result = DataParser.parse(text.slice(src,j,length).Trim(), out dst);
            return result;
        }

        static ReadOnlySpan<TextLine> SummaryLines(ReadOnlySpan<DisasmLineBlock> src)
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

        static ReadOnlySpan<AsmExpr> expressions(ReadOnlySpan<DisasmLineBlock> src)
        {
            var dst = list<AsmExpr>();
            foreach(var block in src)
            {
                foreach(var line in block.Lines)
                {
                    var i = text.index(line.Content, YDIS);
                    if(i >= 0)
                        dst.Add(text.trim(text.right(line.Content, i + YDIS.Length)));
                }
            }
            return dst.ViewDeposited();
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