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
        public Index<AsmEncodingRow> LoadAsmEncodings(IProjectWs project)
        {
            const byte FieldCount = AsmEncodingRow.FieldCount;
            var src = Projects.AsmEncodingTable(project);
            var lines = slice(src.ReadNumberedLines().View,1);
            var count = lines.Length;
            var buffer = alloc<AsmEncodingRow>(count);
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
                result = AsmParser.encid(skip(cells, j++), out dst.EncodingId);
                result = DataParser.parse(skip(cells, j++), out dst.OriginId);
                result = DataParser.parse(skip(cells, j++), out dst.DocSeq);
                result = DataParser.parse(skip(cells, j++), out dst.IP);
                result = AsmParser.asmhex(skip(cells, j++), out dst.Encoded);
                result = DataParser.parse(skip(cells, j++), out dst.Size);
                result = AsmParser.expression(skip(cells, j++), out dst.Asm);
                result = DataParser.parse(skip(cells, j++), out dst.Source);
            }
            return buffer;
        }

    }
}