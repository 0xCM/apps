//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public partial class AsmObjects : AppService<AsmObjects>
    {
        AppDb AppDb => Service(Wf.AppDb);

        AppSvcOps AppSvc => Service(Wf.AppSvc);

        CoffServices Coff => Service(Wf.CoffServices);

        public Index<AsmCodeMapEntry> MapAsm(IProjectWs ws, Alloc dispenser)
        {
            var map = AsmObjects.map(ws, LoadRows(ws), dispenser);
            AppSvc.TableEmit(map, Paths.CodeMap(ws));
            return map;
        }

        public void CollectCoffData(WsContext context)
        {
            Coff.Collect(context);
        }

        public new AsmObjPaths Paths
        {
            [MethodImpl(Inline)]
            get => AppDb;
        }

        public Index<ObjSymRow> LoadObjSyms(IProjectWs project)
            => LoadObjSyms(ProjectDb.ProjectTable<ObjSymRow>(project));

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
        public Index<ObjSymRow> CollectObjSyms(WsContext context)
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

            var rows = buffer.ToArray();
            AppSvc.TableEmit(rows, ProjectDb.ProjectTable<ObjSymRow>(project));
            return rows;
        }

        public CoffSymIndex LoadSymbols(IProjectWs ws)
            => Coff.LoadSymIndex(ws);

        public Index<ObjDumpRow> LoadRows(IProjectWs project)
            => rows(Paths.ObjRowsPath(project));

        public Index<ObjBlock> LoadBlocks(IProjectWs ws)
            => blocks(Paths.ObjBlockPath(ws));

        public Index<AsmInstructionRow> LoadInstructions(IProjectWs project)
        {
            const byte FieldCount = AsmInstructionRow.FieldCount;
            var src = Paths.InstructionTable(project);
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
                result = AsmParser.expression(skip(cells, j++), out dst.Asm);
                result = DataParser.parse(skip(cells, j++), out dst.Source);
            }
            return buffer;
        }

        public void EmitRecoded(WsContext context)
        {
            using var alloc = Alloc.create();
            var code = EmitAsmCode(context, alloc);
            Paths.RecodedTargets(context.Project).Clear();
            for(var i=0; i<code.Count; i++)
                RecodeBlocks(context.Project, code[i]);
        }

        public ObjDumpBlocks CollectObjects(WsContext context)
        {
            var rows = ConsolidateRows(context);
            var blocks = AsmObjects.blocks(rows);
            AppSvc.TableEmit(blocks.View, Paths.ObjBlockPath(context.Project));
            EmitRecoded(context);
            return new ObjDumpBlocks(blocks,rows);
        }

        void RecodeBlocks(in IProjectWs ws, in AsmCodeBlocks src)
        {
            const string intel_syntax = ".intel_syntax noprefix";
            var asmpath = Paths.RecodedPath(ws, src.OriginName.Format());
            var emitting = EmittingFile(asmpath);
            var counter = 0u;
            using var writer = asmpath.AsciWriter();
            writer.WriteLine(intel_syntax);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var block = ref src[i];
                var label = asm.label(block.Label.Name.Format());
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

        Index<AsmCodeBlocks> EmitAsmCode(WsContext context, Alloc alloc)
        {
            Paths.AsmTargets(context.Project).Clear();
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
                EmitAsmCode(context, blocks, Paths.AsmCode(context.Project, file.Path.FileName.Format()));
            }
            return dst.ToArray();
        }

        public void EmitAsmCode(WsContext context, in AsmCodeBlocks src, FS.FilePath dst)
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
                    record.InstructionId = AsmBytes.instid(code.OriginId, code.IP, code.Encoding);
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

            TableEmit(@readonly(buffer), AsmCodeRow.RenderWidths, dst);
        }

        public Index<ObjDumpRow> ConsolidateRows(WsContext context)
        {
            var project = context.Project;
            var src = project.OutFiles(FileKind.ObjAsm).Storage.Sort();
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

            AppSvc.TableEmit(data, Paths.ObjRowsPath(project));
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