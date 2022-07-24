//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public partial class AsmObjects : WfSvc<AsmObjects>
    {
        CoffServices Coff => Wf.CoffServices();

        public AsmCodeMap MapAsm(IWsProject ws, Alloc dst)
        {
            var entries = map(ws, LoadRows(ws.Project), dst);
            TableEmit(entries, AppDb.EtlTable<AsmCodeMapEntry>(ws.Project));
            return new AsmCodeMap(entries);
        }

        IDbTargets EtlTargets(ProjectId project)
            => AppDb.EtlTargets(project);

        public void RunEtl(WsContext context)
        {
            var project = context.Project.Id;
            EtlTargets(project).Delete();
            TableEmit(context.Catalog.Entries(), AppDb.EtlTable(project,"sources.catalog"));
            var objects = CalcObjRows(context);
            var blocks = AsmObjects.blocks(objects);
            TableEmit(blocks, AppDb.EtlTable<ObjBlock>(project));
            using var alloc = Alloc.create();
            var asmrows = EmitAsmRows(context, alloc);
            EmitRecoded(context, asmrows);
            var syms = CalcObjSyms(context);
            EmitObjSyms(context, syms);
            Coff.Collect(context);
            CollectAsmSyntax(context);
            CollectMcInstructions(context);
        }

        public McAsmDoc CalcMcAsmDoc(in FileRef src)
            => new LlvmAsmParser().ParseMcAsmDoc(src);

        public Index<McAsmDoc> CollectSyntaxDocs(WsContext context)
        {
            var src = SynAsmSources(context.Project).View;
            var count = src.Length;
            var dst = list<McAsmDoc>();
            for(var i=0; i<count; i++)
                dst.Add(CalcMcAsmDoc(context.Ref(skip(src,i))));
            return dst.ToArray();
        }

        public Index<McAsmDoc> CalcMcAsmDocs(IWsProject src)
        {
            var files = WsCatalog.load(src).Entries(FileKind.McAsm);
            var count = files.Count;
            var dst = alloc<McAsmDoc>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = CalcMcAsmDoc(files[i]);
            return dst;
        }

        public Index<ObjSymRow> LoadObjSyms(IWsProject project)
            => LoadObjSyms(AppDb.EtlTable<ObjSymRow>(project.Project));

        public Index<ObjSymRow> LoadObjSyms(FS.FilePath src)
        {
            const byte FieldCount = ObjSymRow.FieldCount;
            var result = Outcome.Success;
            var lines = src.ReadLines(true);
            var count = lines.Count - 1;
            var dst = alloc<ObjSymRow>(count);
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i+1];
                var cells = text.trim(text.split(line, Chars.Pipe));
                Require.equal(cells.Length,FieldCount);
                var reader = cells.Reader();
                ref var row = ref seek(dst,i);
                DataParser.parse(reader.Next(), out row.Seq).Require();
                DataParser.parse(reader.Next(), out row.DocSeq).Require();
                DataParser.parse(reader.Next(), out row.OriginId).Require();
                DataParser.parse(reader.Next(), out row.Offset).Require();
                SymCodes.ExprKind(reader.Next(), out row.Code);
                SymKinds.ExprKind(reader.Next(), out row.Kind);
                DataParser.parse(reader.Next(), out row.Name).Require();
                DataParser.parse(reader.Next(), out row.Source).Require();
            }

            return dst;
        }

        public FS.Files SynAsmSources(IWsProject src)
            => src.OutFiles(FileKind.SynAsm.Ext());

        public CoffSymIndex LoadSymbols(ProjectId id)
            => Coff.LoadSymIndex(id);

        public Index<ObjDumpRow> LoadRows(ProjectId id)
            => rows(AppDb.EtlTable<ObjDumpRow>(id));

        public Index<ObjBlock> LoadBlocks(ProjectId id)
            => blocks(AppDb.EtlTable<ObjBlock>(id));

        public Index<AsmInstructionRow> LoadInstructions(ProjectId project)
        {
            const byte FieldCount = AsmInstructionRow.FieldCount;
            var src = AppDb.EtlTable<AsmInstructionRow>(project);
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
                result = DataParser.parse(skip(cells, j++), out dst.OriginId);
                result = DataParser.parse(skip(cells, j++), out dst.OriginName);
                result = DataParser.parse(skip(cells, j++), out dst.AsmName);
                result = AsmExpr.parse(skip(cells, j++), out dst.Asm);
                result = DataParser.parse(skip(cells, j++), out dst.Source);
            }
            return buffer;
        }

        // public Index<AsmCodeBlocks> EmitAsmCodeTables(WsContext context, Alloc alloc)
        // {
        //     var files = context.Catalog.Entries(FileKind.ObjAsm);
        //     var count = files.Count;
        //     var seq = 0u;
        //     var dst = list<AsmCodeBlocks>();
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var file = ref files[i];
        //         var result = parse(context, file, out var rows);
        //         if(result.Fail)
        //             Errors.Throw(result.Message);

        //         var blocks = AsmObjects.blocks(context, file, ref seq, rows, alloc);
        //         dst.Add(blocks);
        //         EmitAsmCodeTable(context, blocks, ObjPaths.AsmCodePath(context.Project.Project, file.Path.FileName.Format()));
        //     }
        //     return dst.ToArray();
        // }

        // public void EmitAsmCodeTable(WsContext context, in AsmCodeBlocks src, FS.FilePath dst)
        // {
        //     var buffer = alloc<AsmCodeRow>(src.LineCount);
        //     var k=0u;
        //     var distinct = hashset<Hex64>();
        //     for(var i=0; i<src.Count; i++)
        //     {
        //         ref readonly var block = ref src[i];
        //         var count = block.Count;
        //         for(var j=0; j<count; j++, k++)
        //         {
        //             ref readonly var code = ref block[j];
        //             ref var record = ref seek(buffer,k);
        //             record.Seq = k;
        //             record.DocSeq = code.DocSeq;
        //             record.EncodingId = code.EncodingId;
        //             record.OriginId = code.OriginId;
        //             record.InstructionId = InstructionId.define(code.OriginId, code.IP, code.Encoding);
        //             record.OriginName = src.OriginName;
        //             record.BlockBase = block.Label.Location;
        //             record.BlockName = block.Label.Name;
        //             record.IP = code.IP;
        //             record.Size = code.Encoded.Size;
        //             record.Encoded = code.Encoded;
        //             record.Asm = code.Asm;
        //             if(!distinct.Add(record.EncodingId))
        //                 Warn(string.Format("Duplicate identifier:{0}", record.EncodingId));
        //         }
        //     }

        //     TableEmit(buffer, dst);
        // }

        // public void EmitRecoded(WsContext context)
        // {
        //     using var alloc = Alloc.create();
        //     var code = EmitAsmCodeTables(context, alloc);
        //     ObjPaths.AsmSrc(context.Project.Project).Clear();
        //     for(var i=0; i<code.Count; i++)
        //         RecodeBlocks(context.Project, code[i]);
        // }

        public FS.FilePath AsmInstructionTable(ProjectId project)
            => Flows.table<AsmInstructionRow>(project);

        public Index<AsmInstructionRow> CollectMcInstructions(WsContext context)
        {
            var project = context.Project;
            var result = Outcome.Success;
            var docs = CollectSyntaxDocs(context);
            var buffer = list<AsmInstructionRow>();
            var counter = 0u;
            foreach(var doc in docs)
            {
                var uri = doc.Path.ToUri();
                var origin = context.Root(doc.Path);
                var fref = context.Ref(doc.Path);
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
                    record.OriginName = origin.DocName;
                    record.DocSeq = instruction.DocSeq;
                    record.AsmName = instruction.AsmName;
                    record.Asm = expr.Statement.Format().Trim();
                    record.Source = uri.LineRef(number);
                    buffer.Add(record);
                }
            }

            var records = buffer.ToArray();
            TableEmit(records, AsmInstructionTable(project.Project));
            return records;
        }

        // void RecodeBlocks(in IProjectWsObsolete ws, in AsmCodeBlocks src)
        // {
        //     const string intel_syntax = ".intel_syntax noprefix";
        //     var asmpath = ObjPaths.RecodedPath(ws.Project, src.OriginName.Format());
        //     var emitting = EmittingFile(asmpath);
        //     var counter = 0u;
        //     using var writer = asmpath.AsciWriter();
        //     writer.WriteLine(intel_syntax);
        //     for(var i=0; i<src.Count; i++)
        //     {
        //         ref readonly var block = ref src[i];
        //         var label = new AsmBlockLabel(block.Label.Name.Format());
        //         writer.WriteLine();
        //         writer.WriteLine(label.Format());
        //         counter++;
        //         var count = block.Count;
        //         for(var j=0; j<count; j++)
        //         {
        //             ref readonly var asmcode = ref block[j];
        //             writer.WriteLine(string.Format("    {0,-48} # {1}", asmcode.Asm, asmcode.Encoding.FormatHex(Chars.Space, false)));
        //         }
        //     }

        //     EmittedFile(emitting,counter);
        // }

        public IDbTargets RecodedTargets(ProjectId id)
            => AppDb.EtlTargets("mc.recoded").Targets(id.Format());

        public FS.FilePath RecodedTarget(ProjectId project, string origin)
            => RecodedTargets(project).Path(origin, FileKind.Asm);

        public FS.FilePath AsmRowPath(ProjectId project, string origin)
            => AppDb.EtlTargets(project).Targets("asm.csv").Path(origin, FileKind.Csv);

        public void EmitObjSyms(WsContext context, ReadOnlySpan<ObjSymRow> src)
            => TableEmit(src, AppDb.EtlTargets(context.Project.Id).Table<ObjSymRow>());

        public Index<ObjSymRow> CalcObjSyms(WsContext context)
        {
            var result = Outcome.Success;
            var project = context.Project;
            var src = project.OutFiles(FS.Sym).View;
            var count = src.Length;
            var formatter = Tables.formatter<ObjSymRow>();
            var buffer = list<ObjSymRow>();
            var seq = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var origin = context.Root(path);
                var fref = context.Ref(path);
                using var reader = path.Utf8LineReader();
                var counter = 0u;
                while(reader.Next(out var line))
                {
                    if(AsmObjects.parse(line.Content, ref counter, out var sym))
                    {
                        sym.Seq = seq++;
                        sym.OriginId = origin.DocId;
                        buffer.Add(sym);
                    }
                }
            }

            return buffer.ToArray();
        }

        public Index<ObjDumpRow> CalcObjRows(WsContext context)
        {
            var project = context.Project;
            var src = project.OutFiles(FileKind.ObjAsm.Ext()).Storage.Sort().Index();
            var result = Outcome.Success;
            var formatter = Tables.formatter<ObjDumpRow>();
            var buffer = bag<ObjDumpRow>();

            iter(src, path => {
                result = parse(context, context.Ref(path), out var records);
                if(result.Fail)
                {
                    Error(result.Message);
                    return;
                }

                var docseq = 0u;
                for(var j=0; j<records.Count; j++)
                {
                    ref var record = ref records[j];
                    if(record.IsBlockStart)
                        continue;

                    buffer.Add(record);
                }
            }, PllExec);

            var data = buffer.ToArray().Sort();
            for(var i=0u; i<data.Length; i++)
                seek(data,i).Seq = i;

            TableEmit(data, AppDb.EtlTable<ObjDumpRow>(project.Project));
            return data;
        }

        public void EmitRecoded(WsContext context, ReadOnlySeq<AsmCodeBlocks> blocks)
        {
            RecodedTargets(context.Project.Project).Clear();
            for(var i=0; i<blocks.Count; i++)
                RecodeBlocks(context.Project.Id, blocks[i]);
        }

        void RecodeBlocks(ProjectId project, in AsmCodeBlocks src)
        {
            const string intel_syntax = ".intel_syntax noprefix";
            var asmpath = RecodedTarget(project, src.OriginName.Format());
            var emitting = EmittingFile(asmpath);
            var counter = 0u;
            using var writer = asmpath.AsciWriter();
            writer.WriteLine(intel_syntax);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var block = ref src[i];
                var label = new AsmBlockLabel(block.Label.Name.Format());
                writer.WriteLine();
                writer.WriteLine(label.Format());
                counter++;
                var count = block.Count;
                for(var j=0; j<count; j++)
                {
                    ref readonly var asmcode = ref block[j];
                    writer.WriteLine(string.Format("    {0,-48} # {1}", asmcode.Asm, asmcode.Encoding.FormatHex(Chars.Space, false)));
                }
            }

            EmittedFile(emitting,counter);
        }

        public Index<AsmCodeBlocks> EmitAsmRows(WsContext context, Alloc alloc)
        {
            var files = context.Catalog.Entries(FileKind.ObjAsm);
            var count = files.Count;
            var seq = 0u;
            var dst = list<AsmCodeBlocks>();
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                var result = parse(context, file, out var rows);
                if(result.Fail)
                    Errors.Throw(result.Message);

                var blocks = AsmObjects.blocks(context, file, ref seq, rows, alloc);
                dst.Add(blocks);
                EmitAsmRows(context, blocks, AsmRowPath(context.Project.Project, file.Path.FileName.Format()));
            }
            return dst.ToArray();
        }

        public void EmitAsmRows(WsContext context, in AsmCodeBlocks src, FS.FilePath dst)
        {
            var buffer = alloc<AsmCodeRow>(src.LineCount);
            var k=0u;
            var distinct = hashset<Hex64>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var block = ref src[i];
                var count = block.Count;
                for(var j=0; j<count; j++, k++)
                {
                    ref readonly var code = ref block[j];
                    ref var record = ref seek(buffer,k);
                    record.Seq = k;
                    record.DocSeq = code.DocSeq;
                    record.EncodingId = code.EncodingId;
                    record.OriginId = code.OriginId;
                    record.InstructionId = InstructionId.define(code.OriginId, code.IP, code.Encoding);
                    record.OriginName = src.OriginName;
                    record.BlockBase = block.Label.Location;
                    record.BlockName = block.Label.Name;
                    record.IP = code.IP;
                    record.Size = code.Encoded.Size;
                    record.Encoded = code.Encoded;
                    record.Asm = code.Asm;
                    if(!distinct.Add(record.EncodingId))
                        Warn(string.Format("Duplicate identifier:{0}", record.EncodingId));
                }
            }

            TableEmit(buffer, dst);
        }

        public FS.FilePath AsmSyntaxTable(ProjectId project)
            => Flows.table<AsmSyntaxRow>(project);

        public Index<AsmSyntaxRow> CollectAsmSyntax(WsContext context)
        {
            var project = context.Project;
            var logs = project.OutFiles(FileTypes.ext(FileKind.SynAsmLog)).View;
            var dst = AsmSyntaxTable(project.Project);
            var count = logs.Length;
            var buffer = list<AsmSyntaxRow>();
            var seq = 0u;
            for(var i=0; i<count; i++)
                ParseAsmSyntaxRows(context, context.Ref(skip(logs,i)), buffer);
            var rows = buffer.ToArray().Sort();
            for(var i=0u; i<rows.Length; i++)
                seek(rows,i).Seq = i;
            TableEmit(@readonly(rows), dst);
            return rows;
        }

        public Index<Index<string>> CalcAsmSyntaxOps(ReadOnlySpan<AsmSyntaxRow> src)
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

        static string syncontent(string src)
        {
            if(Fenced.test(src, Fenced.Paren))
                return text.trim(text.despace(Fenced.unfence(src, Fenced.Paren)));
            else
                return text.trim(text.despace(src));
        }

        void ParseAsmSyntaxRows(WsContext context, in FileRef src, List<AsmSyntaxRow> dst)
        {
            const string EntryMarker = "note: parsed instruction:";
            const string EncodingMarker = "# encoding:";
            const string ReplaceA = "{, ";
            const string ReplaceAWith = "{";
            const string ReplaceB = ", }";
            const string ReplaceBWith = "}";
            var ip = MemoryAddress.Zero;
            var lines = src.Path.ReadNumberedLines();
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
                Lines.parse(locator, out FilePoint point);
                var srcpath = point.Path;
                var syntax = text.right(a, m + EntryMarker.Length);
                syntax = Fenced.unfence(syntax, Brackets, out var semantic) ? RpOps.parenthetical(semantic) : syntax;
                var body = b.Replace(Chars.Tab, Chars.Space);
                var record = new AsmSyntaxRow();
                var orign = context.Root(src);
                record.OriginId = orign.DocId;
                record.OriginName = orign.DocName;
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
                    AsmExpr.parse(text.left(body, ci), out record.Asm);
                else
                    record.Asm = RpOps.Empty;

                var xi = text.index(body, EncodingMarker);
                if(xi > 0)
                {
                    var enc = text.right(body,xi + EncodingMarker.Length + 1);
                    if(AsmHexCode.parse(enc, out var encoding))
                    {
                        record.Encoded = encoding;
                        ip += encoding.Size;
                    }
                }

                record.Source = srcpath.ToUri().LineRef(point.Location.Line);
                dst.Add(record);
            }
        }

        public static readonly Symbols<ObjSymCode> SymCodes;

        public static readonly Symbols<ObjSymKind> SymKinds;

        static AsmObjects()
        {
            SymCodes = Symbols.index<ObjSymCode>();
            SymKinds = Symbols.index<ObjSymKind>();
        }
    }
}