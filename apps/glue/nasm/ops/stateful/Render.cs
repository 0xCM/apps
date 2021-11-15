//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using System;

    using static Root;
    using static core;

    partial class Nasm
    {
        const string RenderDelimiter = RP.SpacedPipe;

        public string FormatBitstring(in BinaryCode src)
            => BitFormat.Format(src.Storage.Reverse());

        [Op]
        public void RenderCodeBlock(in NasmCodeBlock src, ITextBuffer dst)
        {
            if(src.Label.IsNonEmpty)
            {
                RenderLabel(src.Label, dst);
                dst.AppendLine();
            }

            var encodings = src.Code.View;
            var count = encodings.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var encoding = ref skip(encodings,i);
                dst.AppendFormat("{0,-8}", encoding.LineNumber);
                dst.AppendFormat("{0}{1,-16}", RenderDelimiter, encoding.Offset);
                dst.AppendFormat("{0}{1,-46}", RenderDelimiter, encoding.SourceText);
                dst.AppendFormat("{0}{1,-24}", RenderDelimiter, encoding.Encoded);
                dst.AppendFormat("{0}{1,-48}", RenderDelimiter, FormatBitstring(encoding.Encoded));
                dst.AppendLine();
            }
        }

        [Op]
        public void RenderLabel(in NasmLabel src, ITextBuffer dst)
        {
            dst.AppendFormat("{0,-8}", src.LineNumber);
            dst.AppendFormat("{0}{1}", RenderDelimiter, src.Name);
        }

        [Op]
        public void RenderLabel(in Identifier src, ITextBuffer dst)
        {
            dst.AppendFormat("{0}{1,-16}", RenderDelimiter, EmptyString);
            dst.AppendFormat("{0}{1,-24}", RenderDelimiter, EmptyString);
            dst.AppendFormat("{0}{1,-48}", RenderDelimiter, EmptyString);
            dst.AppendFormat("{0}{1}", RenderDelimiter, src);
        }

        [Op]
        public void RenderListEntry(in NasmListEntry src, ITextBuffer dst)
        {
            dst.AppendFormat("{0,-8}", src.LineNumber);
            var kind = Nasm.kind(src);

            if(kind == NasmListLineKind.Label)
                RenderLabel(src.Label, dst);
            else
            {
                dst.AppendFormat("{0}{1,-16}", RenderDelimiter, src.Offset);
                dst.AppendFormat("{0}{1,-24}", RenderDelimiter, src.Encoding);

                if(kind == NasmListLineKind.Encoding)
                    dst.AppendFormat("{0}{1,-48}", RenderDelimiter, FormatBitstring(src.Encoding));
                else
                    dst.AppendFormat("{0}{1,-48}", RenderDelimiter, EmptyString);

                dst.AppendFormat("{0}{1}", RenderDelimiter, src.SourceText);
            }
        }
    }
}