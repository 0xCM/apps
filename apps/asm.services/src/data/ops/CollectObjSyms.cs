//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ProjectDataServices
    {
        public Index<ObjSymRow> CollectObjSyms(WsContext context)
        {
            var result = Outcome.Success;
            var project = context.Project;
            var src = project.OutFiles(FS.Sym).View;
            var count = src.Length;
            var formatter = Tables.formatter<ObjSymRow>(ObjSymRow.RenderWidths);
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
                    if(ParseSymRow(line, ref counter, out var sym))
                    {
                        sym.Seq = seq++;
                        sym.OriginId = origin.DocId;
                        buffer.Add(sym);
                    }
                }
            }

            var rows = buffer.ToArray();
            TableEmit(@readonly(rows), ObjSymRow.RenderWidths, ProjectDb.ProjectTable<ObjSymRow>(project));
            context.Receiver.Collected(rows);
            return rows;
        }

        Outcome ParseSymRow(TextLine src, ref uint seq, out ObjSymRow dst)
        {
            var result = Outcome.Success;
            var content = src.Content;
            dst = default;
            var j = text.index(content, Chars.Colon);
            if(j > 0)
            {
                var k = text.index(content, j + 1, Chars.Colon);
                if(k > 0)
                {
                    dst.Source = FS.path(text.left(content,k));
                    var digits = text.slice(text.right(content,k),1,8).Trim();
                    var hex = Hex32.Max;
                    if(nonempty(digits))
                        DataParser.parse(digits, out hex);
                    dst.DocSeq = seq++;
                    dst.Offset = hex;
                    var pos = k + 1 + 8 + 2;
                    SymCodes.ExprKind(content[pos].ToString(), out dst.Code);
                    dst.Name = text.right(content, pos + 1).Trim();
                    if(dst.Code == ObjSymCode.t && dst.Name != ".text")
                        dst.Code = ObjSymCode.T;
                    else if(dst.Code == ObjSymCode.r && dst.Name != ".rdata")
                        dst.Code = ObjSymCode.R;
                    dst.Kind = ObjSymCalcs.kind(dst.Code);
                }
            }
            return result;
        }
    }
}