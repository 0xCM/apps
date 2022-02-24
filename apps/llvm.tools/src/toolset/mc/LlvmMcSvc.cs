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

        public void Collect(WsContext context)
        {
            var result = Outcome.Success;
            var project = context.Project;
            CollectSyntaxLogs(context);
            CollectEncodings(context);
            CollectInstructions(context);
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

        public Index<McAsmDoc> CollectSyntaxSources(WsContext collect)
        {
            var src = Projects.SynAsmSources(collect.Project).View;
            var count = src.Length;
            var dst = list<McAsmDoc>();
            for(var i=0; i<count; i++)
                dst.Add(ParseMcAsmDoc(collect.FileRef(skip(src,i))));
            var records = dst.ToArray();
            return records;
        }

        public Index<AsmInstructionRow> CollectInstructions(WsContext context)
        {
            var project = context.Project;
            var result = Outcome.Success;
            var docs = CollectSyntaxSources(context);
            var buffer = list<AsmInstructionRow>();
            var counter = 0u;
            foreach(var doc in docs)
            {
                var uri = doc.Path.ToUri();
                context.Root(doc.Path, out var origin);
                var fref = context.FileRef(doc.Path);
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
                    record.OriginId = origin.DocId;
                    record.DocSeq = instruction.DocSeq;
                    record.AsmName = instruction.AsmName;
                    record.Asm = expr.Statement.Format().Trim();
                    record.Source = uri.LineRef(number);
                    buffer.Add(record);
                }
            }

            var records = buffer.ToArray();
            TableEmit(@readonly(records), AsmInstructionRow.RenderWidths, Projects.AsmInstructionTable(project));
            context.Receiver.Collected(records);
            return records;
        }

        public ConstLookup<FS.FilePath,Index<AsmEncodingRow>> CollectEncodings(WsContext context)
        {
            var project = context.Project;
            var result = Outcome.Success;
            var _docs = ParseEncAsmSources(context);
            var paths = _docs.Keys.ToArray().Sort();
            var dst = Projects.AsmEncodingTable(context.Project);
            var counter=0u;
            var record = AsmEncodingRow.Empty;
            var formatter = Tables.formatter<AsmEncodingRow>(AsmEncodingRow.RenderWidths);
            var emitting = EmittingTable<AsmEncodingRow>(dst);
            using var writer = dst.Utf8Writer();
            writer.WriteLine(formatter.FormatHeader());
            foreach(var path in paths)
            {
                var doc = _docs[path];
                var fref = context.FileRef(path);
                var encoded = doc.View;
                var count = encoded.Length;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var e = ref skip(encoded,i);

                    record = AsmEncodingRow.Empty;
                    if(context.Root(path, out var source))
                    {
                        record.OriginId = source.DocId;
                        record.OriginName = source.Path.FileName.Format();
                    }
                    record.Seq = counter++;
                    record.DocSeq = i;
                    record.IP = e.IP;
                    record.EncodingId = e.EncodingId;
                    record.InstructionId = (record.OriginId, record.EncodingId);
                    Require.equal(record.InstructionId, e.InstructionId);
                    record.Asm = e.Asm;
                    record.Size = e.Size;
                    record.Encoded = e.Encoded;
                    record.Source = e.Source;
                    writer.WriteLine(formatter.Format(record));
                }
            }
            EmittedTable(emitting, counter);
            context.Receiver.Collected(_docs);
            return _docs;
        }

        public Index<AsmSyntaxRow> CollectSyntaxLogs(WsContext context)
        {
            var project = context.Project;
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
                ParseSynAsmLog(context, context.FileRef(path), ref seq, tmp);
                docs[path] = new McAsmSyntaxDoc(path, tmp.ToArray());
                buffer.AddRange(tmp);
            }
            var rows = buffer.ToArray();
            TableEmit(@readonly(rows), AsmSyntaxRow.RenderWidths, dst);
            context.Receiver.Collected(rows);
            return rows;
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
                result = AsmParser.encid(skip(cells, j++), out dst.EncodingId);
                result = DataParser.parse(skip(cells, j++), out dst.OriginId);
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
                result = DataParser.parse(skip(cells, j++), out dst.OriginId);
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
                result = DataParser.parse(skip(cells,j++), out dst.OriginId);
                result = DataParser.parse(skip(cells,j++), out dst.OriginName);
                result = DataParser.parse(skip(cells,j++), out dst.DocSeq);

                if(result.Fail)
                {
                    result = (false, string.Format("Line {0}, field {1}", line.LineNumber, nameof(dst.DocSeq)));
                    break;
                }

                dst.Asm = skip(cells, j++);
                dst.Syntax = skip(cells, j++);

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

        void ParseEncAsmSource(WsContext context, in FileRef file, out Index<AsmEncodingRow> dst)
        {
            const string EncodingMarker = "# encoding:";
            var src = file.Path;
            var result = Outcome.Success;
            dst = sys.empty<AsmEncodingRow>();
            var lines = FS.readlines(src,true).View;
            var count = (uint)lines.Length;
            var buffer = list<AsmEncodingRow>();
            var ip = Address32.Zero;
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

                    if(context.Root(file.Path, out var o))
                    {
                        record.OriginId = o.DocId;
                        record.OriginName = o.Path.FileName.Format();
                    }

                    record.Size = record.Encoded.Size;
                    record.DocSeq = seq++;
                    record.IP = ip;
                    record.InstructionId = AsmBytes.instid(record.OriginId, ip, record.Encoded.Bytes);
                    record.EncodingId = record.InstructionId.EncodingId;
                    record.Source = ((FS.FileUri)src).LineRef(line.LineNumber);
                    buffer.Add(record);

                    ip += record.Size;
                    record = default(AsmEncodingRow);
                }
            }
            dst = buffer.ToArray();
        }

        ConstLookup<FS.FilePath,Index<AsmEncodingRow>> ParseEncAsmSources(WsContext context)
        {
            var src = Projects.EncAsmSources(context.Project).View;
            var count = src.Length;
            var dst = dict<FS.FilePath,Index<AsmEncodingRow>>();
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var fref = context.FileRef(path);
                ParseEncAsmSource(context, fref, out var doc);
                var scount = doc.Count;
                var statements = doc.Edit;
                for(var j=0; j<scount; j++)
                    seek(statements,j).Seq = counter++;

                dst[path] = doc;
            }

            return dst;
        }

        void ParseSynAsmLog(WsContext context, in FileRef fref, ref uint seq, List<AsmSyntaxRow> dst)
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
                if(context.Root(fref.Path, out var source))
                {
                    record.OriginId = source.DocId;
                    record.OriginName = source.Path.FileName.Format();
                }
                record.DocSeq = docseq++;
                record.Syntax = syncontent(syntax.Replace(ReplaceA, ReplaceAWith).Replace(ReplaceB, ReplaceBWith).Replace("Memory: ", "Mem:"));
                AsmMnemonic.parse(record.Syntax, out var mx);
                if(mx >=0)
                {
                    var s = record.Syntax.Format();
                    var mi = text.index(s, mx, Chars.Space);
                    if(mi > 0)
                        record.Syntax = text.right(s,mi);
                }

                var ci = text.index(body, Chars.Hash);
                if (ci > 0)
                    AsmParser.expression(text.left(body, ci), out record.Asm);
                else
                    record.Asm = RP.Empty;

                var xi = text.index(body, EncodingMarker);
                if(xi > 0)
                {
                    var enc = text.right(body,xi + EncodingMarker.Length + 1);
                    if(AsmParser.asmhex(enc, out var encoding))
                    {
                        record.Encoded = encoding;
                        ip += encoding.Size;
                    }
                }

                record.Source = srcpath.ToUri().LineRef(point.Location.Line);
                dst.Add(record);
            }
        }
    }
}