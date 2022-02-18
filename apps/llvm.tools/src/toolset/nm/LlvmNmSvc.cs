//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{

    using static core;

    [Tool(ToolId)]
    public sealed class LlvmNmSvc : ToolService<LlvmNmSvc>
    {
        public const string ToolId = ToolNames.llvm_nm;

        Symbols<ObjSymCode> SymCodes;

        Symbols<ObjSymKind> SymKinds;

        public LlvmNmSvc()
            : base(ToolId)
        {
            SymCodes = Symbols.index<ObjSymCode>();
            SymKinds = Symbols.index<ObjSymKind>();
        }

        public Outcome Collect(ProjectCollection collect)
        {
            var result = Outcome.Success;
            var project = collect.Project;
            var src = project.OutFiles(FS.Sym).View;
            var dst = ProjectDb.ProjectTable<ObjSymRow>(project);
            var count = src.Length;
            var formatter = Tables.formatter<ObjSymRow>(ObjSymRow.RenderWidths);
            var buffer = list<ObjSymRow>();
            var seq = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var fref = collect.FileRef(path);
                using var reader = path.Utf8LineReader();
                var counter = 0u;
                while(reader.Next(out var line))
                {
                    if(ParseSymRow(line, ref counter, out var sym))
                    {
                        sym.Seq = seq++;
                        sym.DocId = fref.DocId;
                        buffer.Add(sym);
                    }
                }
            }
            TableEmit(buffer.ViewDeposited(), ObjSymRow.RenderWidths, dst);
            return result;
        }

        public Index<ObjSymRow> LoadSymRows(IProjectWs project)
            => LoadSymRows(ProjectDb.ProjectTable<ObjSymRow>(project));

        public Index<ObjSymRow> LoadSymRows(FS.FilePath src)
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
                DataParser.parse(reader.Next(), out row.DocId).Require();
                DataParser.parse(reader.Next(), out row.DocSeq).Require();
                DataParser.parse(reader.Next(), out row.Offset).Require();
                SymCodes.ExprKind(reader.Next(), out row.Code);
                SymKinds.ExprKind(reader.Next(), out row.Kind);
                DataParser.parse(reader.Next(), out row.Name).Require();
                DataParser.parse(reader.Next(), out row.Source).Require();
            }

            return dst;
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
                    dst.Kind = ObjSymCalcs.kind(dst.Code);
                    dst.Name = text.right(content, pos + 1).Trim();
                }
            }
            return result;
        }
    }
}