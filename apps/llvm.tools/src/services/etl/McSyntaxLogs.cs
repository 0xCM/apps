//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Collections.Generic;

    using Asm;
    using records;

    using static core;

    public class McSyntaxLogs : AppService<McSyntaxLogs>
    {
        public ReadOnlySpan<AsmSyntaxRow> Collect(ProjectId src)
        {
            return Collect(Ws.Project(src));
        }

        public ReadOnlySpan<AsmSyntaxRow> Collect(IProjectWs ws)
        {
            var rows = CollectRows(ws);
            return rows;
        }

        ReadOnlySpan<AsmSyntaxRow> CollectRows(IProjectWs ws)
        {
            var result = CollectLogs(ws);
            CollectSyntaxTrees(ws);
            return result;
        }

        ReadOnlySpan<AsmSyntaxRow> CollectLogs(IProjectWs ws)
        {
            var logs = ws.OutFiles(FileTypes.ext(FileKind.AsmSyntaxLog)).View;
            var dst = ws.Table<AsmSyntaxRow>(ws.Project.Format());
            var count = logs.Length;
            var buffer = list<AsmSyntaxRow>();
            for(var i=0; i<count; i++)
                ParseSyntaxLogRows(skip(logs,i), buffer);
            var rows = buffer.ViewDeposited();
            TableEmit(rows, AsmSyntaxRow.RenderWidths, dst);
            return rows;
        }

        Outcome CollectSyntaxTrees(IProjectWs ws)
        {
            var result = Outcome.Success;
            var src = ws.OutFiles(FileKind.AsmSyntax).View;
            var count = src.Length;
            var dst = ws.OutDir() + FS.file(ws.Name.Format() + ".syntax-trees", FS.Asm);
            using var writer = dst.AsciWriter();
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                result = AsmParser.document(path, out var doc);
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

                var m = text.index(a,EntryMarker);
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
                counter++;
                FS.point(locator, out var point);
                record.Location = point.Location;
                record.Expr = AsmExpr.parse(body);
                record.Syntax = syntax;
                record.Source = point.Path;
                dst.Add(record);
            }
            return counter;
        }
    }
}