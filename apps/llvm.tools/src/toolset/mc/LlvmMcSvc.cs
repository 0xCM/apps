//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Collections.Generic;

    using Asm;

    using static core;

    [Tool(ToolId)]
    public partial class LlvmMcSvc : ToolService<LlvmMcSvc>
    {
        public const string ToolId = LlvmNames.Tools.llvm_mc;

        public LlvmMcSvc()
            : base(ToolId)
        {

        }

        public void Collect(IProjectWs ws)
        {
            var logs = CollectSyntaxLogs(ws);
            var encodings = CollectEncodings(ws);
            var trees = CollectSyntaxTrees(ws);
            var instructions = CollectInstructions(ws);
        }

        public Index<AsmDocument> SyntaxSourceDocs(IProjectWs ws)
        {
            var src = SyntaxSourcePaths(ws).View;
            var count = src.Length;
            var dst = list<AsmDocument>();
            for(var i=0; i<count; i++)
                dst.Add(LlvmMcParser.asmdoc(skip(src,i)));
            return dst.Array();
        }

        public Index<AsmDocInstruction> CollectInstructions(IProjectWs project)
        {
            var result = Outcome.Success;

            var docs = SyntaxSourceDocs(project);
            var buffer = list<AsmDocInstruction>();
            var counter = 0u;
            foreach(var doc in docs)
            {
                var path = doc.Path.ToUri();
                var inst = doc.Instructions;
                var lines = doc.SourceLines.Map(x => (x.LineNumber, x.Statement.Format().Trim())).ToDictionary();
                var count = inst.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var instruction = ref skip(inst,i);
                    var expr = lines[instruction.Line];
                    var loc = path.LineRef(instruction.Line);

                    var record = new AsmDocInstruction();
                    record.Seq = counter++;
                    record.DocSeq = instruction.Seq;
                    record.Instruction = instruction.Name;
                    record.Statement = expr;
                    record.Doc = loc;
                    buffer.Add(record);
                }
            }

            var records = buffer.ToArray();
            TableEmit(@readonly(records), AsmDocInstruction.RenderWidths, InstructionTable(project));
            return records;
        }

        public ConstLookup<FS.FileUri,AsmEncodingDoc> CollectEncodings(IProjectWs project)
        {
            var result = Outcome.Success;
            var docs = DeriveEncodings(project);
            var dst = ProjectDb.TablePath<AsmDocEncoding>("projects", project.Project.Format());

            var counter=0u;
            var record = AsmDocEncoding.Empty;
            var formatter = Tables.formatter<AsmDocEncoding>(AsmDocEncoding.RenderWidths);
            var emitting = EmittingTable<AsmDocEncoding>(dst);
            using var writer = dst.Utf8Writer();
            writer.WriteLine(formatter.FormatHeader());
            foreach(var doc in docs.Values)
            {
                var encoded = doc.Statements;
                var count = encoded.Length;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var e = ref skip(encoded,i);
                    record = AsmDocEncoding.Empty;
                    record.Seq = counter++;
                    record.DocSeq = i;
                    record.Asm = e.Asm;
                    record.Size = e.Encoding.Size;
                    record.Offset = e.Offset;
                    record.Code = e.Encoding;
                    record.Doc = doc.Source.LineRef(e.Line);
                    writer.WriteLine(formatter.Format(record));
                }
            }
            EmittedTable(emitting, counter);
            return docs;
        }

        public ConstLookup<FS.FileUri,AsmSyntaxDoc> CollectSyntaxLogs(IProjectWs project)
        {
            var logs = project.OutFiles(FileTypes.ext(FileKind.AsmSyntaxLog)).View;
            var dst = SyntaxTable(project);
            var count = logs.Length;
            var buffer = list<AsmSyntaxRow>();
            var tmp = list<AsmSyntaxRow>();
            var docs = lookup<FS.FileUri,AsmSyntaxDoc>();
            for(var i=0; i<count; i++)
            {
                tmp.Clear();
                ref readonly var path = ref skip(logs,i);
                ParseSyntaxLogRows(path, tmp);
                docs.Include(path, new AsmSyntaxDoc(path, tmp.ToArray()));
                buffer.AddRange(tmp);
            }
            var rows = buffer.ViewDeposited();
            TableEmit(rows, AsmSyntaxRow.RenderWidths, dst);
            return docs.Seal();
        }

        public ConstLookup<FS.FileUri,AsmDocument> CollectSyntaxTrees(IProjectWs project)
        {
            var result = Outcome.Success;
            var src = SyntaxSourcePaths(project).View;
            var count = src.Length;
            var dst = ProjectDb.ProjectData() + FS.file("asm.syntax.tree." + project.Name.Format(), FS.Asm);
            var docs = lookup<FS.FileUri,AsmDocument>();
            using var writer = dst.AsciWriter();
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var doc = LlvmMcParser.asmdoc(path);

                docs.Include(path,doc);

                var lines = doc.SourceLines;
                writer.WriteLine(string.Format("# Source: {0}", path.ToUri()));
                for(var j=0; j<lines.Length; j++)
                {
                    ref readonly var line = ref skip(lines,j);
                    writer.WriteLine(line);
                }
            }

            return docs.Seal();
        }

        public Index<AsmSyntaxRow> LoadSyntaxRows(IProjectWs project)
            => LoadSyntaxRows(SyntaxTable(project));

        public Index<AsmSyntaxRow> LoadSyntaxRows(FS.FilePath src)
        {
            const byte FieldCount = AsmSyntaxRow.FieldCount;
            using var reader = src.Utf8LineReader();
            var rowcount = FS.linecount(src).Lines - 1;
            var counter = 0u;
            var result = Outcome.Success;
            var buffer = alloc<AsmSyntaxRow>(rowcount);
            while(reader.Next(out var line))
            {
                if(counter == 0)
                {
                    counter++;
                    continue;
                }

                var cells = text.trim(text.split(line.Content, Chars.Pipe));
                var count = cells.Length;
                if(count != FieldCount)
                {
                    result = (false,Tables.FieldCountMismatch.Format(count,FieldCount));
                    break;
                }

                ref var dst = ref seek(buffer,counter++);
                var j=0;

                result = DataParser.parse(skip(cells,j++), out dst.Seq);
                if(result.Fail)
                {
                    result = (false, string.Format("Line {0}, field {1}", line.LineNumber, nameof(dst.Seq)));
                    break;
                }

                result = DataParser.parse(skip(cells,j++), out dst.Location);
                if(result.Fail)
                {
                    result = (false, string.Format("Line {0}, field {1}", line.LineNumber, nameof(dst.Location)));
                    break;
                }

                dst.Expr = skip(cells,j++);
                dst.Syntax = skip(cells,j++);

                var hex = skip(cells,j++);
                if(empty(hex))
                {
                    dst.Encoding = AsmHexCode.Empty;
                    dst.Source = FS.FilePath.Empty;
                    continue;
                }

                result = AsmHexCode.parse(hex, out dst.Encoding);
                if(result.Fail)
                {
                    result = (false, string.Format("Line {0}, field {1}", line.LineNumber, nameof(dst.Encoding)));
                    break;
                }

                result = DataParser.parse(skip(cells,j++), out dst.Source);
                if(result.Fail)
                {
                    result = (false, string.Format("Line {0}, field {1}", line.LineNumber, nameof(dst.Source)));
                    break;
                }
            }

            if(result)
            {
                return buffer;
            }
            else
            {
                Error(result.Message);
                return sys.empty<AsmSyntaxRow>();
            }
        }

        ConstLookup<FS.FileUri,AsmEncodingDoc> DeriveEncodings(IProjectWs project)
        {
            var src = EncodingSourcePaths(project).View;
            var count = src.Length;
            var dst = lookup<FS.FileUri,AsmEncodingDoc>();
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var result = LlvmMcParser.encoding(path, out var doc);
                if(result.Fail)
                {
                    Error(result.Message);
                    break;
                }

                var scount = doc.StatmentCount;
                var statements = doc.Statements;
                for(var j=0; j<scount; j++)
                    seek(statements,j).Seq = counter++;

                dst.Include(doc.Source, doc);
            }

            return dst.Seal();
        }

        uint ParseSyntaxLogRows(FS.FilePath src, List<AsmSyntaxRow> dst)
        {
            const string EntryMarker = "note: parsed instruction:";
            const string EncodingMarker = "# encoding:";
            const string ReplaceA = "{, ";
            const string ReplaceAWith = "{";
            const string ReplaceB = ", }";
            const string ReplaceBWith = "}";
            var lines = src.ReadNumberedLines();
            var count = lines.Length;
            var counter = 0u;
            for(var i=0; i<count-1; i++)
            {
                ref readonly var a = ref lines[i].Content;
                ref readonly var b = ref lines[i+1].Content;

                var m = text.index(a, EntryMarker);
                if(!a.Contains(EntryMarker))
                    continue;

                Fence<char> Brackets = (Chars.LBracket, Chars.RBracket);
                var locator = text.left(a,m).Trim();
                locator = text.slice(locator,0, locator.Length - 1);

                var syntax = text.right(a, m + EntryMarker.Length);
                syntax = text.unfence(syntax, Brackets, out var semantic) ? RP.parenthetical(semantic) : syntax;
                var body = b.Replace(Chars.Tab, Chars.Space);
                var record = new AsmSyntaxRow();
                record.Seq = counter++;

                var ci = text.index(body, Chars.Hash);
                if (ci > 0)
                    record.Expr = AsmExpr.parse(text.left(body, ci));
                else
                    record.Expr = RP.Empty;

                var xi = text.index(body, EncodingMarker);
                if(xi > 0)
                {
                    var enc = text.right(body,xi + EncodingMarker.Length + 1);
                    if(AsmHexCode.parse(enc, out var encoding))
                        record.Encoding = encoding;
                }

                FS.point(locator, out var point);
                record.Location = point.Location;
                record.Syntax = syntax.Replace(ReplaceA, ReplaceAWith).Replace(ReplaceB, ReplaceBWith);
                record.Source = point.Path.ToUri().LineRef(point.Location.Line);
                dst.Add(record);
            }
            return counter;
        }

        FS.FilePath SyntaxTable(IProjectWs project)
            => ProjectDb.TablePath<AsmSyntaxRow>("projects", project.Name);

        FS.FilePath InstructionTable(IProjectWs project)
            => ProjectDb.TablePath<AsmDocInstruction>("projects", project.Name);

        FS.Files EncodingSourcePaths(IProjectWs project)
            => project.OutFiles(FS.ext("encoding.asm"));

        FS.Files SyntaxSourcePaths(IProjectWs project)
            => project.OutFiles(FileKind.AsmSyntax);

    }
}