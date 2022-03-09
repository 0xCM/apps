//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDisasmSvc
    {
        Index<DisasmDetail> EmitDisasmDetails(Index<DisasmDetail> src, FS.FilePath dst)
        {
            var emitting = EmittingFile(dst);
            var formatter = Tables.formatter<DisasmDetail>(DisasmDetail.RenderWidths);
            var headerBase = formatter.FormatHeader();
            var j = text.lastindex(headerBase, Chars.Pipe);
            headerBase = text.left(headerBase,j);
            var opheader = text.buffer();
            for(var k=0; k<6; k++)
            {
                opheader.Append("| ");
                opheader.Append(DisasmOpDetail.Header(k));
            }

            var header = string.Format("{0}{1}", headerBase, opheader.Emit());
            using var writer = dst.AsciWriter();
            writer.WriteLine(header);
            for(var i=0; i<src.Length; i++)
                writer.WriteLine(formatter.Format(src[i]));

            EmittedFile(emitting, src.Length);
            return src;
        }
    }
}