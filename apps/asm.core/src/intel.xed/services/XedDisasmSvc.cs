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
    using static XedModels;
    using static XedDisasm;

    public class XedDisasmSvc : AppService<XedDisasmSvc>
    {
        Symbols<IFormType> Forms;

        Symbols<IClass> Classes;

        public XedDisasmSvc()
        {
            Forms = Symbols.index<IFormType>();
            Classes = Symbols.index<IClass>();
        }

        public FS.Files DisasmFiles(IProjectWs ws)
            => ws.OutFiles(FS.ext("xed.txt"));

        public FS.FilePath DisasmTable(IProjectWs project)
            => ProjectDb.ProjectData() + FS.file(string.Format("xed.disasm.{0}", project.Project), FS.Csv);

        public Outcome ParseInstructions(ReadOnlySpan<Block> src, out Index<Instruction> dst)
        {
            var count = src.Length;
            var result = Outcome.Success;
            dst = alloc<Instruction>(count);
            for(var i=0; i<count; i++)
            {
                result = ParseInstruction(skip(src,i), out dst[i]);
                if(result.Fail)
                    break;
            }
            return result;
        }

        public Index<AsmStatementEncoding> Collect(IProjectWs project)
        {
            var result = Outcome.Success;
            var paths = DisasmFiles(project);
            var records = ParseEncodings(paths);
            var count = paths.Length;
            TableEmit(records.View, AsmStatementEncoding.RenderWidths, DisasmTable(project));
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

        public ConstLookup<FS.FilePath,StatementEncodings> ParseEncodings(IProjectWs project)
        {
            var src = project.OutFiles(FS.ext("xed.txt"));
            var count = src.Count;
            var dst = dict<FS.FilePath,StatementEncodings>();
            for(var i=0; i<count; i++)
                dst[src[i]] =(ParseEncodings(src[i]));
            return dst;
        }

        public StatementEncodings ParseEncodings(FS.FilePath src)
        {
            var dst = list<AsmStatementEncoding>();
            var result = ParseEncodings(src,dst);
            if(result.Fail)
                Error(result);
            return new StatementEncodings(src,dst.ToArray());
        }

        public ConstLookup<FS.FilePath,FileBlocks> ParseBlocks(IProjectWs project)
        {
            var src = project.OutFiles(FS.ext("xed.txt"));
            var dst = dict<FS.FilePath,FileBlocks>();
            var blocks = list<Block>();
            foreach(var path in src)
            {
                blocks.Clear();
                Blocks(path,blocks);
                dst[path] =new FileBlocks(path, blocks.ToArray());
            }
            return dst;
        }

        /// <summary>
        /// Transforms the source document into a sequence of blocks, each of which describe a single decoded instruction
        /// </summary>
        /// <param name="src">And xed-emitted disassemly file</param>
        public Index<Block> ParseBlocks(FS.FilePath src)
            => Blocks(src);

        Outcome ParseInstruction(in Block block, out Instruction inst)
        {
            var result = Outcome.Success;
            inst = default(Instruction);
            ref readonly var content = ref block.Instruction.Content;
            if(text.nonempty(content))
            {
                var j = text.index(content, Chars.Space);
                if(j > 0)
                {
                    var expr = text.left(content,j);
                    if(Classes.Lookup(expr, out var @class))
                        inst.Class = @class;
                    else
                    {
                        result = (false,string.Format("IClass not found in '{0}'", content));
                        return result;
                    }

                    var k = text.index(content, j+1, Chars.Space);
                    if(k > 0)
                    {
                        expr = text.inside(content, j, k);
                        if(Forms.Lookup(expr, out var form))
                            inst.Form = form;
                        else
                        {
                            result = (false,string.Format("IFormType not found in '{0}'", expr));
                            return result;
                        }
                    }

                    var props = text.words(text.right(content,k), Chars.Comma);
                    var kP = props.Count;
                    inst.Props = alloc<Facet<string>>(kP);
                    for(var m=0; m<kP; m++)
                    {
                        ref readonly var p = ref props[m];
                        if(p.Contains(Chars.Colon))
                        {
                            var kv = text.split(p, Chars.Colon);
                            if(kv.Length == 2)
                                inst.Props[m] = (skip(kv,0).Trim(), skip(kv,1).Trim());
                        }
                        else
                        {
                            inst.Props[m] = (p.Trim(), EmptyString);
                        }
                    }
                }
            }
            return result;
        }

        const string XDIS = "XDIS ";

        const string YDIS = "YDIS:";

        static Index<Block> Blocks(FS.FilePath src)
        {
            var lines = src.ReadNumberedLines();
            var count = lines.Length;
            var dst = list<Block>();
            Blocks(src,dst);
            return dst.ToArray();
        }

        static void Blocks(FS.FilePath src, List<Block> dst)
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

        static Outcome ParseEncodings(FS.FilePath src, List<AsmStatementEncoding> dst)
            => ParseEncodings(Blocks(src), dst);

        static Outcome ParseEncodings(ReadOnlySpan<Block> blocks, List<AsmStatementEncoding> dst)
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
                result = ParseOffset(content, out record.Offset);
                if(result.Fail)
                    return result;

                result = ParseHexCode(line, out record.Encoding);
                if(result.Fail)
                    return result;

                dst.Add(record);
            }

            return true;
        }

        static ReadOnlySpan<TextLine> SummaryLines(ReadOnlySpan<Block> src)
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

        static ReadOnlySpan<AsmExpr> expressions(ReadOnlySpan<Block> src)
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

        static Outcome ParseOffset(string src, out Address32 dst)
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