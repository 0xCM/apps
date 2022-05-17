//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class PolyBits
    {
        public readonly struct PbRender
        {
            public static void render(BitPattern src, uint seq, ITextEmitter dst)
            {
                const string RenderPattern = "{0,-12} | {1}";
                dst.WriteLine();
                dst.AppendLineFormat(RenderPattern, "BitPattern", seq.ToString("D2"));
                dst.WriteLine(RP.PageBreak120);
                dst.AppendLineFormat(RenderPattern,  nameof(BitPattern.Origin), src.Origin);
                dst.AppendLineFormat(RenderPattern,  nameof(BitPattern.Name), src.Name);
                dst.AppendLineFormat(RenderPattern,  nameof(BitPattern.Content), src.Content);
                dst.AppendLineFormat(RenderPattern,  nameof(BitPattern.DataWidth), src.DataWidth);
                dst.AppendLineFormat(RenderPattern,  nameof(BitPattern.MinSize), src.MinSize);
                dst.AppendLineFormat(RenderPattern,  nameof(BitPattern.DataType), src.DataType.DisplayName());
                dst.AppendLineFormat(RenderPattern,  nameof(BitPattern.Descriptor), src.Descriptor);
                dst.AppendLineFormat(RenderPattern, "Segments", EmptyString);
                dst.AppendLine(RP.PageBreak120);
                render(src.Segs, dst);
            }

            public static void render(ReadOnlySpan<BfSegModel> src, ITextEmitter dst, bool header = true)
            {
                var formatter = Tables.formatter<BfSegModel>();
                if(header)
                    dst.AppendLine(formatter.FormatHeader());
                for(var i=0; i<src.Length; i++)
                    dst.AppendLine(formatter.Format(skip(src,i)));
            }

        }
    }
}