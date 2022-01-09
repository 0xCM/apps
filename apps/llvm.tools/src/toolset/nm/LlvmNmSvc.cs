//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    [Tool(ToolId)]
    public sealed class LlvmNmSvc : ToolService<LlvmNmSvc>
    {
        public const string ToolId = LlvmToolNames.llvm_nm;

        public LlvmNmSvc()
            : base(ToolId)
        {

        }

        public Outcome Collect(IProjectWs ws)
        {
            var result = Outcome.Success;
            var src = ws.OutFiles(FS.Sym).View;
            var dst = ProjectDb.ProjectTable<ObjSymRow>(ws);
            var symbols = Collect(src, dst);
            return result;
        }

        public ReadOnlySpan<ObjSymRow> Search(IProjectWs project, string match)
        {
            var result = Outcome.Success;
            var files = project.OutFiles(FS.Sym).View;
            var formatter = Tables.formatter<ObjSymRow>(ObjSymRow.RenderWidths);
            var tool = Wf.LlvmNm();
            var dst = list<ObjSymRow>();
            foreach(var f in files)
            {
                var records = tool.Read(f);
                var count= records.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var record = ref skip(records,i);
                    if(record.Name.Contains(match))
                        dst.Add(record);
                }
            }
            return dst.ViewDeposited();
        }

        public ReadOnlySpan<ObjSymRow> Read(FS.FilePath path)
        {
            var result = Outcome.Success;
            var count = FS.linecount(path).Lines;
            var buffer = span<ObjSymRow>(count);
            var counter = 0u;
            var j=0;
            using var reader = path.Utf8LineReader();
            while(reader.Next(out var line))
            {
                if(parse(line, ref counter, out var sym))
                    seek(buffer, j++) = sym;
            }
            return slice(buffer, 0,j);
        }

        public ReadOnlySpan<ObjSymRow> Collect(ReadOnlySpan<FS.FilePath> src, FS.FilePath outpath)
        {
            var result = Outcome.Success;
            var count = src.Length;
            var formatter = Tables.formatter<ObjSymRow>(ObjSymRow.RenderWidths);
            var buffer = list<ObjSymRow>();
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                using var reader = path.Utf8LineReader();
                var counter = 0u;
                while(reader.Next(out var line))
                {
                    if(parse(line, ref counter, out var sym))
                        buffer.Add(sym);
                }
            }
            var records = buffer.ViewDeposited();
            TableEmit(records, ObjSymRow.RenderWidths, outpath);
            return records;
        }

        static Outcome parse(TextLine src, ref uint seq, out ObjSymRow dst)
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
                    dst.Seq = seq++;
                    dst.Offset = hex;
                    var pos = k + 1 + 8 + 2;
                    dst.Kind = content[pos];
                    dst.Name = text.right(content, pos + 1).Trim();
                }
            }
            return result;
        }
    }
}