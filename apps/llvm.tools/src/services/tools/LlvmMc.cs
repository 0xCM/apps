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

        public ConstLookup<FS.FileUri,AsmSyntaxDoc> Collect(IProjectWs ws)
        {
            var result = CollectLogs(ws);
            CollectSyntaxTrees(ws);
            return result;
        }

        public Index<AsmDocument> SyntaxSources(IProjectWs ws)
        {
            var src = SyntaxSourcePaths(ws).View;
            var count = src.Length;
            var dst = list<AsmDocument>();
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var result = LlvmMcParser.parse(path, out var doc);
                if(result.Fail)
                {
                    Error(result.Message);
                    break;
                }
                dst.Add(doc);
            }
            return dst.Array();
        }

        FS.Files SyntaxSourcePaths(IProjectWs ws)
            => ws.OutFiles(FileKind.AsmSyntax);

        ConstLookup<FS.FileUri,AsmSyntaxDoc> CollectLogs(IProjectWs ws)
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

        Outcome CollectSyntaxTrees(IProjectWs ws)
        {
            var result = Outcome.Success;
            var src = SyntaxSourcePaths(ws).View;
            var count = src.Length;
            var dst = ws.OutDir() + FS.file(ws.Name.Format() + ".syntree", FS.Asm);
            using var writer = dst.AsciWriter();
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                result = LlvmMcParser.parse(path, out var doc);
                if(result.Fail)
                    break;

                var lines = doc.SourceLines;
                writer.WriteLine(string.Format("# Source: {0}", path.ToUri()));
                for(var j=0; j<lines.Length; j++)
                    writer.WriteLine(skip(lines,j));
            }

            return result;
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