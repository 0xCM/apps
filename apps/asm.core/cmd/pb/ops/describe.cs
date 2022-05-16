//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PolyBits
    {
        static void describe(BitPattern src, uint seq, ITextEmitter dst)
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
            render(src.Segments, dst);
        }
    }
}