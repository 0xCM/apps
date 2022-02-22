//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    using static core;

    [Tool(ToolId)]
    public partial class LlvmMcSvc : ToolService<LlvmMcSvc>
    {
        public const string ToolId = ToolNames.llvm_mc;

        WsProjects Projects => Service(Wf.WsProjects);

        public LlvmMcSvc()
            : base(ToolId)
        {

        }

        Index<AsmCodeIndexRow> Correlate(IProjectWs project, ReadOnlySpan<AsmSyntaxRow> syntax, ReadOnlySpan<AsmInstructionRow> instructions)
        {
            var count = Require.equal(syntax.Length,instructions.Length);
            var buffer = alloc<AsmCodeIndexRow>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var a = ref skip(syntax,i);
                ref readonly var b = ref skip(instructions,i);
                ref var dst = ref seek(buffer,i);
                dst.Seq = Require.equal(a.Seq, b.Seq);
                dst.DocId = a.DocId;
                dst.DocSeq = a.DocSeq;
                dst.Id = a.Id;
                dst.AsmName = b.AsmName;
                dst.IP = a.IP;
                dst.Encoded = a.Encoded;
                dst.Size = a.Encoded.Size;
                dst.Asm = b.Asm;
                dst.Syntax = a.Syntax;
                dst.Source = a.Source;
            }
            TableEmit(@readonly(buffer), AsmCodeIndexRow.RenderWidths, Projects.AsmIndexTable(project));

            return buffer;
        }

        public Index<AsmCodeIndexRow> Collect(CollectionContext context)
        {
            var result = Outcome.Success;
            var project = context.Project;
            var syntax = CollectSyntaxLogs(context);
            var encodings = CollectEncodings(context);
            var instructions = CollectInstructions(context);
            return Correlate(project, syntax, instructions);
        }

        public McAsmDoc ParseMcAsmDoc(in FileRef src)
            => new LlvmAsmParser().ParseMcAsmDoc(src);

        public Index<McAsmDoc> ParseMcAsmDocs(IProjectWs project)
        {
            var files = project.FileCatalog().Entries(FileKind.McAsm);
            var count = files.Count;
            var dst = alloc<McAsmDoc>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = ParseMcAsmDoc(files[i]);
            return dst;
        }

        public Index<McAsmDoc> CollectSyntaxSources(CollectionContext collect)
        {
            var src = Projects.SynAsmSources(collect.Project).View;
            var count = src.Length;
            var dst = list<McAsmDoc>();
            for(var i=0; i<count; i++)
                dst.Add(ParseMcAsmDoc(collect.FileRef(skip(src,i))));
            return dst.Array();
        }

        public ReadOnlySpan<AsmInstructionRow> CollectInstructions(CollectionContext collect)
        {
            var project = collect.Project;
            var result = Outcome.Success;
            var docs = CollectSyntaxSources(collect);
            var buffer = list<AsmInstructionRow>();
            var counter = 0u;
            foreach(var doc in docs)
            {
                var path = doc.Path.ToUri();
                var fref = collect.FileRef(doc.Path);
                var srcid = doc.Path.SrcId(FileKind.SynAsm);
                var instructions = doc.Instructions;
                var srcLines = doc.SourceLines;
                var instLineNumbers = instructions.Keys.ToArray().Sort();
                var count = instLineNumbers.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var number = ref skip(instLineNumbers, i);
                    var instruction = instructions[number];
                    var expr = srcLines[number];
                    var record = new AsmInstructionRow();
                    record.Seq = counter++;
                    record.DocId = fref.DocId;
                    record.DocSeq = instruction.DocSeq;
                    record.AsmName = instruction.AsmName;
                    record.Asm = expr.Statement.Format().Trim();
                    record.Source = path.LineRef(number);
                    buffer.Add(record);
                    collect.EventReceiver.Collected(fref, record);
                }
            }

            var records = buffer.ViewDeposited();
            TableEmit(records, AsmInstructionRow.RenderWidths, Projects.AsmInstructionTable(project));
            return records;
        }

        public ConstLookup<FS.FilePath,Index<AsmEncodingRow>> CollectEncodings(CollectionContext collect)
        {
            var project = collect.Project;
            var result = Outcome.Success;
            var _docs = ParseEncAsmSources(collect);
            var paths = _docs.Keys.ToArray().Sort();
            var dst = Projects.AsmEncodingTable(collect.Project);
            var counter=0u;
            var record = AsmEncodingRow.Empty;
            var formatter = Tables.formatter<AsmEncodingRow>(AsmEncodingRow.RenderWidths);
            var emitting = EmittingTable<AsmEncodingRow>(dst);
            using var writer = dst.Utf8Writer();
            writer.WriteLine(formatter.FormatHeader());
            foreach(var path in paths)
            {
                var doc = _docs[path];
                var fref = collect.FileRef(path);
                var encoded = doc.View;
                var srcid = path.SrcId(FileKind.EncAsm);
                var count = encoded.Length;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var e = ref skip(encoded,i);

                    record = AsmEncodingRow.Empty;
                    record.Seq = counter++;
                    record.DocId = fref.DocId;
                    record.DocSeq = i;
                    record.IP = e.IP;
                    record.Id = e.Id;
                    record.Asm = e.Asm;
                    record.Size = e.Size;
                    record.Encoded = e.Encoded;
                    record.Source = e.Source;
                    writer.WriteLine(formatter.Format(record));
                    collect.EventReceiver.Collected(fref, record);
                }
            }
            EmittedTable(emitting, counter);
            return _docs;
        }

        public ReadOnlySpan<AsmSyntaxRow> CollectSyntaxLogs(CollectionContext collect)
        {
            var project = collect.Project;
            var logs = project.OutFiles(FileTypes.ext(FileKind.SynAsmLog)).View;
            var dst = Projects.AsmSyntaxTable(project);
            var count = logs.Length;
            var buffer = list<AsmSyntaxRow>();
            var tmp = list<AsmSyntaxRow>();
            var docs = dict<FS.FilePath,McAsmSyntaxDoc>();
            var seq = 0u;
            for(var i=0; i<count; i++)
            {
                tmp.Clear();
                ref readonly var path = ref skip(logs,i);

                ParseSynAsmLog(collect, collect.FileRef(path), ref seq, tmp);
                docs[path] = new McAsmSyntaxDoc(path, tmp.ToArray());
                buffer.AddRange(tmp);
            }
            var rows = buffer.ViewDeposited();
            TableEmit(rows, AsmSyntaxRow.RenderWidths, dst);
            return rows;
        }

        public Index<AsmCodeIndexRow> LoadAsmIndex(IProjectWs project)
        {
            var lines = Projects.AsmIndexTable(project).ReadLines(true);
            var count = lines.Count - 1;
            var buffer = alloc<AsmCodeIndexRow>(count);
            var i=0u;
            var reader = lines.Reader();
            reader.Next();
            while(reader.Next(out var line))
            {
                var data = line.Split(Chars.Pipe);
                Require.equal(data.Length, AsmCodeIndexRow.FieldCount);
                ref var dst = ref seek(buffer,i++);
                var cells = data.Reader();
                DataParser.parse(cells.Next(), out dst.Seq).Require();
                DataParser.parse(cells.Next(), out dst.Id).Require();
                DataParser.parse(cells.Next(), out dst.DocId).Require();
                DataParser.parse(cells.Next(), out dst.DocSeq).Require();
                DataParser.parse(cells.Next(), out dst.AsmName).Require();
                DataParser.parse(cells.Next(), out dst.IP).Require();
                DataParser.parse(cells.Next(), out dst.Size).Require();
                AsmParser.asmhex(cells.Next(), out dst.Encoded);
                AsmParser.expression(cells.Next(), out dst.Asm).Require();
                DataParser.parse(cells.Next(), out dst.Syntax).Require();
                DataParser.parse(cells.Next(), out dst.Source).Require();
            }
            return buffer;
        }

        public Index<AsmEncodingRow> LoadEncodings(IProjectWs project)
        {
            const byte FieldCount = AsmEncodingRow.FieldCount;
            var src = Projects.AsmEncodingTable(project);
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
                result = AsmParser.encid(skip(cells, j++), out dst.Id);
                result = DataParser.parse(skip(cells, j++), out dst.DocId);
                result = DataParser.parse(skip(cells, j++), out dst.DocSeq);
                result = DataParser.parse(skip(cells, j++), out dst.IP);
                result = AsmParser.asmhex(skip(cells, j++), out dst.Encoded);
                result = DataParser.parse(skip(cells, j++), out dst.Size);
                result = AsmParser.expression(skip(cells, j++), out dst.Asm);
                result = DataParser.parse(skip(cells, j++), out dst.Source);
            }
            return buffer;
        }

        public Index<AsmInstructionRow> LoadInstructions(IProjectWs project)
        {
            const byte FieldCount = AsmInstructionRow.FieldCount;
            var src = Projects.AsmInstructionTable(project);
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
                result = DataParser.parse(skip(cells, j++), out dst.DocId);
                result = DataParser.parse(skip(cells, j++), out dst.DocSeq);
                result = DataParser.parse(skip(cells, j++), out dst.AsmName);
                result = AsmParser.expression(skip(cells, j++), out dst.Asm);
                result = DataParser.parse(skip(cells, j++), out dst.Source);
            }
            return buffer;
        }

        public Index<AsmSyntaxRow> LoadSyntax(IProjectWs project)
            => LoadSyntaxRows(Projects.AsmSyntaxTable(project));

        static string syncontent(string src)
        {
            if(text.fenced(src, RenderFence.Paren))
                return text.trim(text.despace(text.unfence(src,RenderFence.Paren)));
            else
                return text.trim(text.despace(src));
        }

        public Index<Index<string>> ExtractSyntaxOpLists(ReadOnlySpan<AsmSyntaxRow> src)
        {
            var count = src.Length;
            var buffer = alloc<Index<string>>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(src,i);
                var syntax = row.Syntax.Format();
                if(syntax.Contains(Chars.Colon))
                    seek(buffer,i) = text.trim(text.split(syntax, Chars.Space));
                else
                    seek(buffer,i) = sys.empty<string>();

            }

            return buffer;
        }

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
                result = DataParser.parse(skip(cells,j++), out dst.Id);
                result = DataParser.parse(skip(cells,j++), out dst.DocId);
                result = DataParser.parse(skip(cells,j++), out dst.DocSeq);

                if(result.Fail)
                {
                    result = (false, string.Format("Line {0}, field {1}", line.LineNumber, nameof(dst.DocSeq)));
                    break;
                }

                dst.Asm = skip(cells, j++);
                dst.Syntax = skip(cells, j++);
                result = DataParser.parse(skip(cells,j++), out dst.IP);

                var hex = skip(cells, j++);
                if(empty(hex))
                {
                    dst.Encoded = AsmHexCode.Empty;
                    dst.Source = FS.FilePath.Empty;
                    continue;
                }

                result = AsmParser.asmhex(hex, out dst.Encoded);
                if(result.Fail)
                {
                    result = (false, string.Format("Line {0}, field {1}", line.LineNumber, nameof(dst.Encoded)));
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

        void ParseEncAsmSource(in FileRef file, out Index<AsmEncodingRow> dst)
        {
            const string EncodingMarker = "# encoding:";
            var src = file.Path;
            var result = Outcome.Success;
            dst = sys.empty<AsmEncodingRow>();
            var lines = FS.readlines(src,true).View;
            var count = (uint)lines.Length;
            var buffer = list<AsmEncodingRow>();
            var offset = Address32.Zero;
            var seq = 0u;
            var record = default(AsmEncodingRow);
            var origin = file.Path.FileName.Format();
            for(var i=0u; i<count; i++)
            {
                ref readonly var line = ref skip(lines,i);
                if(line.Contains(EncodingMarker))
                {
                    var content = line.Content.Replace(Chars.Tab, Chars.Space);
                    var j = text.index(content, Chars.Hash);
                    record.Asm = text.trim(text.left(content,j));

                    var enc = text.right(content, j + EncodingMarker.Length);
                    result = AsmParser.asmhex(enc, out record.Encoded);
                    if(result.Fail)
                        Errors.Throw(result.Message);

                    record.Size = record.Encoded.Size;
                    record.DocId = file.DocId;
                    record.DocSeq = seq++;
                    record.IP = offset;
                    record.Id = AsmBytes.instid(file.DocId, offset, record.Encoded.Bytes).EncodingId;
                    record.Source = ((FS.FileUri)src).LineRef(line.LineNumber);
                    buffer.Add(record);

                    offset += record.Size;
                    record = default(AsmEncodingRow);
                }
            }
            dst = buffer.ToArray();
        }

        ConstLookup<FS.FilePath,Index<AsmEncodingRow>> ParseEncAsmSources(CollectionContext collect)
        {
            var src = Projects.EncAsmSources(collect.Project).View;
            var count = src.Length;
            var dst = dict<FS.FilePath,Index<AsmEncodingRow>>();
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var fref = collect.FileRef(path);
                ParseEncAsmSource(fref, out var doc);
                var scount = doc.Count;
                var statements = doc.Edit;
                for(var j=0; j<scount; j++)
                    seek(statements,j).Seq = counter++;

                dst[path] = doc;
            }

            return dst;
        }

        void ParseSynAsmLog(CollectionContext collect, in FileRef fref, ref uint seq, List<AsmSyntaxRow> dst)
        {
            var src = fref.Path;
            var origin = src.FileName.Format();
            const string EntryMarker = "note: parsed instruction:";
            const string EncodingMarker = "# encoding:";
            const string ReplaceA = "{, ";
            const string ReplaceAWith = "{";
            const string ReplaceB = ", }";
            const string ReplaceBWith = "}";
            var ip = MemoryAddress.Zero;
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
                record.DocId = fref.DocId;
                record.DocSeq = docseq++;
                record.Syntax = syncontent(syntax.Replace(ReplaceA, ReplaceAWith).Replace(ReplaceB, ReplaceBWith).Replace("Memory: ", "Mem:"));
                AsmMnemonic.parse(record.Syntax, out var mx);
                if(mx >=0)
                {
                    var s = record.Syntax.Format();
                    var mi = text.index(s, mx, Chars.Space);
                    if(mi > 0)
                    {
                        record.Syntax = text.right(s,mi);
                    }
                }

                var ci = text.index(body, Chars.Hash);
                if (ci > 0)
                    record.Asm = AsmExpr.parse(text.left(body, ci));
                else
                    record.Asm = RP.Empty;

                var xi = text.index(body, EncodingMarker);
                if(xi > 0)
                {
                    var enc = text.right(body,xi + EncodingMarker.Length + 1);
                    if(AsmParser.asmhex(enc, out var encoding))
                    {
                        record.Encoded = encoding;
                        record.Id = AsmBytes.instid(fref.DocId, ip, encoding.Bytes).EncodingId;
                        record.IP = ip;
                        ip += encoding.Size;
                    }
                }

                record.Source = srcpath.ToUri().LineRef(point.Location.Line);
                dst.Add(record);
                collect.EventReceiver.Collected(fref, record);
            }
        }
    }
}