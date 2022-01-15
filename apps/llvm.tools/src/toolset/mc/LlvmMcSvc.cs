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
        public const string ToolId = ToolNames.llvm_mc;

        ProjectScriptSvc ScriptSvc => Service(Wf.ProjectScriptSvc);

        AsmSourceDocs AsmDocs => Service(Wf.AsmSourceDocs);

        EnumParser<AsmId> AsmIdParser => Service(() => new EnumParser<AsmId>());

        BuildResponseHandler ResponseHandler => Service(() => BuildResponseHandler.create(Wf));

        public Outcome<Index<ToolCmdFlow>> Build(IProjectWs project, bool runexe = false)
            => ScriptSvc.RunScript(project, "mc-build", "asm", flow => ResponseHandler.HandleBuildResponse(flow,runexe));

        public LlvmMcSvc()
            : base(ToolId)
        {

        }

        public void Collect(IProjectWs ws)
        {
            var result = Outcome.Success;
            CollectSyntaxLogs(ws);
            CollectEncodings(ws);
            CollectSyntaxTrees(ws);
            result = CollectInstructions(ws);
            if(result.Fail)
                Error(result.Message);
        }

        public Index<AsmDocument> SyntaxSourceDocs(IProjectWs project)
        {
            var src = SyntaxSourcePaths(project).View;
            var count = src.Length;
            var dst = list<AsmDocument>();
            for(var i=0; i<count; i++)
                dst.Add(AsmDocs.ParseAsmDoc(skip(src,i)));
            return dst.Array();
        }

        public Outcome CollectInstructions(IProjectWs project)
        {
            var result = Outcome.Success;
            var docs = SyntaxSourceDocs(project);
            var buffer = list<AsmInstructionRow>();
            var counter = 0u;
            foreach(var doc in docs)
            {
                var path = doc.Path.ToUri();
                var srcid = doc.Path.SrcId(FileKind.AsmSyntax);
                var inst = doc.Instructions;
                var lines = doc.SourceLines.Map(x => (x.LineNumber, x.Statement.Format().Trim())).ToDictionary();
                var count = inst.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var instruction = ref skip(inst,i);
                    var expr = lines[instruction.Line];
                    var record = new AsmInstructionRow();
                    record.Seq = counter++;
                    record.DocSeq = instruction.Seq;
                    record.SrcId = srcid;
                    record.AsmId = instruction.AsmId;
                    record.Asm = expr;
                    record.Source = path.LineRef(instruction.Line);
                    if(result.Fail)
                        break;
                    buffer.Add(record);
                }

                if(result.Fail)
                    break;
            }

            if(result)
                TableEmit(buffer.ViewDeposited(), AsmInstructionRow.RenderWidths, InstructionTable(project));
            return result;
        }

        public ConstLookup<FS.FilePath,Index<AsmEncodingRow>> CollectEncodings(IProjectWs project)
        {
            var result = Outcome.Success;
            //var docs = ParseEncodingSources(project);
            var _docs = ParseEncodingSources(project);
            var paths = _docs.Keys.ToArray().Sort();
            var dst = EncodingTable(project);
            var counter=0u;
            var record = AsmEncodingRow.Empty;
            var formatter = Tables.formatter<AsmEncodingRow>(AsmEncodingRow.RenderWidths);
            var emitting = EmittingTable<AsmEncodingRow>(dst);
            using var writer = dst.Utf8Writer();
            writer.WriteLine(formatter.FormatHeader());
            foreach(var path in paths)
            {
                var doc = _docs[path];
                var encoded = doc.View;
                var srcid = path.SrcId(FileKind.EncodingAsm);
                var count = encoded.Length;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var e = ref skip(encoded,i);

                    record = AsmEncodingRow.Empty;
                    record.Seq = counter++;
                    record.DocSeq = i;
                    record.SrcId = srcid;
                    record.Asm = e.Asm;
                    record.Size = e.Size;
                    record.IP = e.IP;
                    record.HexCode = e.HexCode;
                    record.Source = e.Source;
                    writer.WriteLine(formatter.Format(record));
                }
            }
            EmittedTable(emitting, counter);
            return _docs;
        }

        public AsmSyntaxDocs CollectSyntaxLogs(IProjectWs project)
        {
            var logs = project.OutFiles(FileTypes.ext(FileKind.AsmSyntaxLog)).View;
            var dst = SyntaxTable(project);
            var count = logs.Length;
            var buffer = list<AsmSyntaxRow>();
            var tmp = list<AsmSyntaxRow>();
            var docs = dict<FS.FilePath,AsmSyntaxDoc>();
            var seq = 0u;
            for(var i=0; i<count; i++)
            {
                tmp.Clear();
                ref readonly var path = ref skip(logs,i);
                ParseSyntaxLogRows(path, ref seq, tmp);
                docs[path] = new AsmSyntaxDoc(path, tmp.ToArray());
                buffer.AddRange(tmp);
            }
            var rows = buffer.ViewDeposited();
            TableEmit(rows, AsmSyntaxRow.RenderWidths, dst);
            return docs;
        }

        public ConstLookup<FS.FilePath,AsmDocument> CollectSyntaxTrees(IProjectWs project)
        {
            var result = Outcome.Success;
            var src = SyntaxSourcePaths(project).View;
            var count = src.Length;
            var dst = ProjectDb.ProjectDataFile(project, "asm.syntax.tree", FS.Asm);
            var docs = lookup<FS.FilePath,AsmDocument>();
            using var writer = dst.AsciWriter();

            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var doc = AsmDocs.ParseAsmDoc(path);

                docs.Include(path,doc);

                var lines = doc.SourceLines;
                writer.WriteLine(string.Format("# Source: {0}", path.ToUri()));
                for(var j=0; j<lines.Length; j++)
                    writer.WriteLine(skip(lines,j));
            }

            return docs.Seal();
        }

        public Index<AsmEncodingRow> LoadEncodings(IProjectWs project)
        {
            const byte FieldCount = AsmEncodingRow.FieldCount;
            var src = EncodingTable(project);
            var lines = slice(src.ReadNumberedLines().View,1);
            var count = lines.Length;
            var buffer = alloc<AsmEncodingRow>(count);
            var result = Outcome.Success;
            for(var i=0; i<count; i++)
            {
                var cells = text.trim(skip(lines,i).Content.Split(Chars.Pipe));
                if(cells.Length != FieldCount)
                {
                    result = (false, Tables.FieldCountMismatch.Format(cells.Length, FieldCount));
                    break;
                }

                ref var dst = ref seek(buffer,i);

                var j = 0;
                result = DataParser.parse(skip(cells, j++), out dst.Seq);
                result = DataParser.parse(skip(cells, j++), out dst.DocSeq);
                result = DataParser.parse(skip(cells, j++), out dst.SrcId);
                result = DataParser.parse(skip(cells, j++), out dst.IP);
                result = DataParser.parse(skip(cells, j++), out dst.Asm);
                result = DataParser.parse(skip(cells, j++), out dst.Size);
                result = DataParser.parse(skip(cells, j++), out dst.HexCode);
                result = DataParser.parse(skip(cells, j++), out dst.Source);
            }
            return buffer;
        }

        public Index<AsmInstructionRow> LoadInstructions(IProjectWs project)
        {
            const byte FieldCount = AsmInstructionRow.FieldCount;
            var src = InstructionTable(project);
            var lines = slice(src.ReadNumberedLines().View,1);
            var count = lines.Length;
            var buffer = alloc<AsmInstructionRow>(count);
            var result = Outcome.Success;
            for(var i=0; i<count; i++)
            {
                var cells = text.trim(skip(lines,i).Content.Split(Chars.Pipe));
                if(cells.Length != FieldCount)
                {
                    result = (false, Tables.FieldCountMismatch.Format(cells.Length, FieldCount));
                    break;
                }

                ref var dst = ref seek(buffer,i);
                var j = 0;
                result = DataParser.parse(skip(cells, j++), out dst.Seq);
                result = DataParser.parse(skip(cells, j++), out dst.DocSeq);
                result = DataParser.parse(skip(cells, j++), out dst.SrcId);
                result = AsmIdParser.Parse(skip(cells, j++), out dst.AsmId);
                result = DataParser.parse(skip(cells, j++), out dst.Asm);
                result = DataParser.parse(skip(cells, j++), out dst.Source);
            }
            return buffer;

        }

        public Index<AsmSyntaxRow> LoadSyntax(IProjectWs project)
            => LoadSyntaxRows(SyntaxTable(project));

        Index<AsmSyntaxRow> LoadSyntaxRows(FS.FilePath src)
        {
            const byte FieldCount = AsmSyntaxRow.FieldCount;
            using var reader = src.Utf8LineReader();
            var rowcount = FS.linecount(src).Lines - 1;
            var counter = 0u;
            var result = Outcome.Success;
            var buffer = alloc<AsmSyntaxRow>(rowcount);
            reader.Next(out _);
            while(reader.Next(out var line))
            {
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

                result = DataParser.parse(skip(cells,j++), out dst.DocSeq);
                if(result.Fail)
                {
                    result = (false, string.Format("Line {0}, field {1}", line.LineNumber, nameof(dst.DocSeq)));
                    break;
                }

                result = DataParser.parse(skip(cells,j++), out dst.SrcId);
                if(result.Fail)
                {
                    result = (false, string.Format("Line {0}, field {1}", line.LineNumber, nameof(dst.SrcId)));
                    break;
                }

                result = DataParser.parse(skip(cells,j++), out dst.Location);
                if(result.Fail)
                {
                    result = (false, string.Format("Line {0}, field {1}", line.LineNumber, nameof(dst.Location)));
                    break;
                }

                dst.Expr = skip(cells, j++);
                dst.Syntax = skip(cells, j++);

                var hex = skip(cells, j++);
                if(empty(hex))
                {
                    dst.HexCode = AsmHexCode.Empty;
                    dst.Source = FS.FilePath.Empty;
                    continue;
                }

                result = AsmHexCode.parse(hex, out dst.HexCode);
                if(result.Fail)
                {
                    result = (false, string.Format("Line {0}, field {1}", line.LineNumber, nameof(dst.HexCode)));
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

        Outcome ParseEncodingSource(FS.FilePath src, out Index<AsmEncodingRow> dst)
        {
            const string EncodingMarker = "# encoding:";

            var result = Outcome.Success;
            dst = sys.empty<AsmEncodingRow>();
            var lines = FS.readlines(src).View;
            var count = (uint)lines.Length;
            var buffer = list<AsmEncodingRow>();
            var offset = Address32.Zero;
            var seq = 0u;
            var record = default(AsmEncodingRow);
            for(var i=0u; i<count; i++)
            {
                ref readonly var line = ref skip(lines,i);
                if(line.Contains(EncodingMarker))
                {
                    var content = line.Content.Replace(Chars.Tab, Chars.Space);
                    var j = text.index(content, Chars.Hash);
                    result = AsmParser.asmxpr(text.left(content,j), out record.Asm);
                    if(result.Fail)
                        return result;

                    var enc = text.right(content, j + EncodingMarker.Length);
                    result = AsmHexCode.parse(enc, out record.HexCode);
                    if(result.Fail)
                        return result;

                    record.Size = record.HexCode.Size;
                    record.DocSeq = seq++;
                    record.SrcId = src.SrcId(FileKind.EncodingAsm);
                    record.IP = offset;
                    record.Source = ((FS.FileUri)src).LineRef(line.LineNumber);
                    buffer.Add(record);

                    offset += record.Size;
                    record = default(AsmEncodingRow);
                }
            }
            dst = buffer.ToArray();
            return result;
        }

        ConstLookup<FS.FilePath,Index<AsmEncodingRow>> ParseEncodingSources(IProjectWs project)
        {
            var src = EncodingSourcePaths(project).View;
            var count = src.Length;
            var dst = dict<FS.FilePath,Index<AsmEncodingRow>>();
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var result = ParseEncodingSource(path, out var doc);
                if(result.Fail)
                {
                    Error(result.Message);
                    break;
                }

                var scount = doc.Count;
                var statements = doc.Edit;
                for(var j=0; j<scount; j++)
                    seek(statements,j).Seq = counter++;

                dst[path] = doc;
            }

            return dst;
        }

        void ParseSyntaxLogRows(FS.FilePath src, ref uint seq, List<AsmSyntaxRow> dst)
        {
            const string EntryMarker = "note: parsed instruction:";
            const string EncodingMarker = "# encoding:";
            const string ReplaceA = "{, ";
            const string ReplaceAWith = "{";
            const string ReplaceB = ", }";
            const string ReplaceBWith = "}";
            var lines = src.ReadNumberedLines();
            var count = lines.Length;
            var docseq = 0u;
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
                FS.point(locator, out var point);
                var srcpath = point.Path;
                var syntax = text.right(a, m + EntryMarker.Length);
                syntax = text.unfence(syntax, Brackets, out var semantic) ? RP.parenthetical(semantic) : syntax;
                var body = b.Replace(Chars.Tab, Chars.Space);
                var record = new AsmSyntaxRow();
                record.Seq = seq++;
                record.DocSeq = docseq++;
                record.SrcId = srcpath.SrcId(FileKind.EncodingAsm);
                record.Location = point.Location;
                record.Syntax = syntax.Replace(ReplaceA, ReplaceAWith).Replace(ReplaceB, ReplaceBWith);

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
                        record.HexCode = encoding;
                }

                record.Source = srcpath.ToUri().LineRef(point.Location.Line);
                dst.Add(record);
            }
        }

        FS.FilePath SyntaxTable(IProjectWs project)
            => ProjectDb.ProjectTable<AsmSyntaxRow>(project);

        FS.FilePath InstructionTable(IProjectWs project)
            => ProjectDb.ProjectTable<AsmInstructionRow>(project);

        FS.FilePath EncodingTable(IProjectWs project)
            => ProjectDb.ProjectTable<AsmEncodingRow>(project);

        FS.Files EncodingSourcePaths(IProjectWs project)
            => project.OutFiles(FileKind.EncodingAsm);

        FS.Files SyntaxSourcePaths(IProjectWs project)
            => project.OutFiles(FileKind.AsmSyntax);
    }
}