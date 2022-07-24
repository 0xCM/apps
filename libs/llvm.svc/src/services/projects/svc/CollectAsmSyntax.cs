//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ProjectSvc
    {
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
    }
}