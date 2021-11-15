//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using records;

    using static core;

    public sealed class LlvmNm : ToolService<LlvmNm>
    {
        public override ToolId Id
            => LlvmNames.Tools.llvm_nm;

        public ReadOnlySpan<ObjSymRow> Read(FS.FilePath path)
        {
            var result = Outcome.Success;
            var count = FS.linecount(path).Lines;
            var buffer = span<ObjSymRow>(count);
            var counter = 0u;
            using var reader = path.Utf8LineReader();
            while(reader.Next(out var line))
            {
                if(parse(line, out var sym))
                    seek(buffer,counter++) = sym;
            }
            return slice(buffer, 0,counter);
        }

        static Outcome parse(TextLine src, out ObjSymRow dst)
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

                    dst.Offset = hex;
                    var pos = k + 1 + 8 + 2;
                    dst.Kind = content[pos];
                    dst.Name = text.right(content, pos + 1).Trim();
                }
            }
            return result;
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
                while(reader.Next(out var line))
                {
                    if(parse(line, out var sym))
                        buffer.Add(sym);
                }
            }
            var records = buffer.ViewDeposited();
            TableEmit(records, ObjSymRow.RenderWidths, outpath);
            return records;
        }
    }
}