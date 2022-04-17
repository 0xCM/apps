//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasm
    {
        static string FormatDetailHeader(IRecordFormatter<DetailBlockRow> formatter)
        {
            var headerBase = formatter.FormatHeader();
            var j = text.lastindex(headerBase, Chars.Pipe);
            headerBase = text.left(headerBase,j);
            var opheader = text.buffer();
            for(var k=0; k<6; k++)
            {
                opheader.Append("| ");
                opheader.Append(DisasmRender.OpDetailHeader(k));
            }

            return string.Format("{0}{1}", headerBase, opheader.Emit());
        }

        static void render(IRecordFormatter<DetailBlockRow> formatter, in DetailBlockRow src, ITextBuffer dst)
            => dst.AppendLine(formatter.Format(src));
    }
}