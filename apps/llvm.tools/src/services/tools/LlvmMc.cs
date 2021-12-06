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
    public partial class LlvmMc : ToolService<LlvmMc>
    {
        public const string ToolId = LlvmNames.Tools.llvm_mc;

        public LlvmMc()
            : base(ToolId)
        {

        }

        public void Collect(IProjectWs ws)
        {
            var result = CollectSyntaxLogs(ws);
            var encodings = CollectEncoding(ws);
            var docs = CollectSyntaxTrees(ws);
            var instructions = CollectInstructions(ws);
        }

        public FS.Files EncodingSourcePaths(IProjectWs ws)
            => ws.OutFiles(FS.ext("encoding.asm"));

        public FS.Files SyntaxSourcePaths(IProjectWs ws)
            => ws.OutFiles(FileKind.AsmSyntax);

        public Index<AsmDocument> SyntaxSourceDocs(IProjectWs ws)
        {
            var src = SyntaxSourcePaths(ws).View;
            var count = src.Length;
            var dst = list<AsmDocument>();
            for(var i=0; i<count; i++)
                dst.Add(LlvmMcParser.asmdoc(skip(src,i)));
            return dst.Array();
        }

        public Index<AsmEncodingDoc> EncodingDocs(IProjectWs ws)
        {
            var src = EncodingSourcePaths(ws).View;
            var count = src.Length;
            var dst = list<AsmEncodingDoc>();
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var result = LlvmMcParser.encoding(path, out var doc);
                if(result.Fail)
                {
                    Error(result.Message);
                    break;
                }
                dst.Add(doc);
            }

            return dst.Array();
        }

        Index<AsmDocInstruction> CollectInstructions(IProjectWs ws)
        {
            var result = Outcome.Success;

            var docs = SyntaxSourceDocs(ws);
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
            var dst = ws.Table<AsmDocInstruction>(ws.Project.Format());
            TableEmit(@readonly(records), AsmDocInstruction.RenderWidths, dst);
            return records;
        }

        Index<AsmEncodingDoc> CollectEncoding(IProjectWs ws)
        {
            var result = Outcome.Success;
            var docs = EncodingDocs(ws);
            var dst = ws.Table<AsmDocEncoding>(ws.Project.Format());
            var counter=0u;
            var record = AsmDocEncoding.Empty;
            var formatter = Tables.formatter<AsmDocEncoding>(AsmDocEncoding.RenderWidths);
            var emitting = EmittingTable<AsmDocEncoding>(dst);
            using var writer = dst.Utf8Writer();
            writer.WriteLine(formatter.FormatHeader());
            foreach(var doc in docs)
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

        ConstLookup<FS.FileUri,AsmSyntaxDoc> CollectSyntaxLogs(IProjectWs ws)
        {
            var logs = ws.OutFiles(FileTypes.ext(FileKind.AsmSyntaxLog)).View;
            var dst = ws.Table<AsmSyntaxRow>(ws.Project.Format());
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

        Index<AsmDocument> CollectSyntaxTrees(IProjectWs ws)
        {
            var result = Outcome.Success;
            var src = SyntaxSourcePaths(ws).View;
            var count = src.Length;
            var dst = ws.OutDir() + FS.file(ws.Name.Format() + ".syntree", FS.Asm);
            var docs = list<AsmDocument>();
            using var writer = dst.AsciWriter();
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var doc = LlvmMcParser.asmdoc(path);

                docs.Add(doc);

                var lines = doc.SourceLines;
                writer.WriteLine(string.Format("# Source: {0}", path.ToUri()));
                for(var j=0; j<lines.Length; j++)
                {
                    ref readonly var line = ref skip(lines,j);
                    writer.WriteLine(line);
                }
            }

            return docs.ToArray();
        }

        uint ParseSyntaxLogRows(FS.FilePath src, List<AsmSyntaxRow> dst)
        {
            const string EntryMarker = "note: parsed instruction:";
            var lines = src.ReadNumberedLines();
            var count = lines.Length;
            var counter = 0u;
            for(var i=0; i<count-1; i++)
            {
                ref readonly var a = ref skip(lines, i).Content;
                ref readonly var b = ref skip(lines, i+1).Content;

                var m = text.index(a, EntryMarker);
                if(!a.Contains(EntryMarker))
                    continue;

                Fence<char> Brackets = (Chars.LBracket, Chars.RBracket);
                var locator = text.left(a,m).Trim();
                locator = text.slice(locator,0, locator.Length - 1);

                var syntax = text.right(a, m + EntryMarker.Length);
                var semfound = text.unfence(syntax, Brackets, out var semantic);
                syntax = semfound ? RP.parenthetical(semantic) : syntax;
                var body = b.Replace(Chars.Tab, Chars.Space);
                var ci = text.index(body, Chars.Hash);
                if (ci > 0)
                    body = text.left(body, ci);

                var record = new AsmSyntaxRow();
                record.Seq = counter++;
                FS.point(locator, out var point);
                record.Location = point.Location;
                record.Expr = AsmExpr.parse(body);
                record.Syntax = syntax;
                record.Source = point.Path.ToUri().LineRef(point.Location.Line);
                dst.Add(record);
            }
            return counter;
        }
    }
}