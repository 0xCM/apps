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

        public static AsmObjPaths ObjPaths
        {
            [MethodImpl(Inline)]
            get => new AsmObjPaths(GlobalSvc.Instance.AppDb);
        }

        public AsmCodeMap MapAsm(IProjectWs ws, Alloc dst)
        {
            var entries = map(ws, LoadRows(ws.Project), dst);
            TableEmit(entries, AppDb.ProjectTable<AsmCodeMapEntry>(ws.Project));
            return new AsmCodeMap(entries);
        }

        public void CollectCoffData(WsContext context)
            => Coff.Collect(context);

        public Index<ObjSymRow> LoadObjSyms(IProjectWs project)
            => LoadObjSyms(AppDb.DbProjects(project.Project).Table<ObjSymRow>());

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

        public void Emit(WsContext context, ReadOnlySpan<ObjSymRow> src)
            => TableEmit(src, ProjectDb.ProjectTable<ObjSymRow>(context.Project));

        public CoffSymIndex LoadSymbols(ProjectId id)
            => Coff.LoadSymIndex(id);

        public Index<ObjDumpRow> LoadRows(ProjectId id)
            => rows(AppDb.ProjectTable<ObjDumpRow>(id));

        public Index<ObjBlock> LoadBlocks(ProjectId id)
            => blocks(AppDb.ProjectTable<ObjBlock>(id));

        public Index<AsmInstructionRow> LoadInstructions(ProjectId project)
        {
            const byte FieldCount = AsmInstructionRow.FieldCount;
            var src = AppDb.ProjectTable<AsmInstructionRow>(project);
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

        public Index<ObjDumpRow> CalcObjRows(WsContext context)
        {
            var files = context.Catalog.Entries(FileKind.ObjAsm);
            var count = files.Count;
            var seq = 0u;
            var dst = list<ObjDumpRow>();
            var parser = new ObjDumpParser();
            for(var i=0; i<count; i++)
            {
                var result = parser.Parse(context, files[i], dst);
                if(result.Fail)
                     Errors.Throw(result.Message);
            }
            return dst.ToArray();
        }

        public Index<AsmCodeBlocks> EmitAsmCodeTables(WsContext context, Alloc alloc)
        {
            AppDb.AsmCsv(context.Project.Project).Clear();
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
                EmitAsmCodeTable(context, blocks, ObjPaths.AsmCodePath(context.Project.Project, file.Path.FileName.Format()));
            }
            return dst.ToArray();
        }

        public void EmitAsmCodeTable(WsContext context, in AsmCodeBlocks src, FS.FilePath dst)
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

        public void EmitRecoded(WsContext context)
        {
            using var alloc = Alloc.create();
            var code = EmitAsmCodeTables(context, alloc);
            AppDb.AsmSrc(context.Project.Project).Clear();
            for(var i=0; i<code.Count; i++)
                RecodeBlocks(context.Project, code[i]);
        }

        void RecodeBlocks(in IProjectWs ws, in AsmCodeBlocks src)
        {
            const string intel_syntax = ".intel_syntax noprefix";
            var asmpath = ObjPaths.RecodedPath(ws.Project, src.OriginName.Format());
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

        public ObjDumpBlocks CollectObjects(WsContext context)
        {
            var rows = ConsolidateRows(context);
            var blocks = AsmObjects.blocks(rows);
            TableEmit(blocks.View, AppDb.ProjectTable<ObjBlock>(context.Project.Project));
            EmitRecoded(context);
            return new ObjDumpBlocks(blocks,rows);
        }


        public Index<ObjDumpRow> ConsolidateRows(WsContext context)
        {
            var project = context.Project;
            var src = project.OutFiles(FileKind.ObjAsm.Ext()).Storage.Sort();
            var result = Outcome.Success;
            var count = src.Length;
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
                for(var j=0; j<records.Length; j++)
                {
                    ref var record = ref records[j];
                    if(record.IsBlockStart)
                        continue;

                    buffer.Add(record);
                }
            }, true);

            var data = buffer.ToArray().Sort();
            for(var i=0u; i<data.Length; i++)
                seek(data,i).Seq = i;

            TableEmit(data, AppDb.ProjectTable<ObjDumpRow>(project.Project));
            return data;
        }

        static Symbols<ObjSymCode> SymCodes;

        static Symbols<ObjSymKind> SymKinds;

        static AsmObjects()
        {
            SymCodes = Symbols.index<ObjSymCode>();
            SymKinds = Symbols.index<ObjSymKind>();
        }
    }
}