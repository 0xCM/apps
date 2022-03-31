//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedPatterns;
    using static core;

    partial class XedRules
    {

        void EmitPatternDetails(RuleTableSet tables, Index<InstPattern> src, FS.FilePath dst)
        {
            src.Sort();
            const string LabelPattern = "{0,-18} {1}";
            var emitting = EmittingFile(dst);
            Span<string> rbuffer = alloc<string>(42);

            using var writer = dst.AsciWriter();
            for(var j=0; j<src.Count; j++)
            {
                ref readonly var pattern = ref src[j];

                writer.AppendLine(FormatIsaHeader(pattern));
                writer.AppendLine(FormatIsaBody(pattern));
                writer.AppendLineFormat(LabelPattern, nameof(pattern.Mode), XedRender.format(pattern.Mode));
                writer.AppendLineFormat(LabelPattern, nameof(pattern.OpCode), string.Format("{0,-8} {1}", pattern.OpCode.Kind, AsmOcValue.format(pattern.OpCode.Value)));

                if(pattern.Attributes.IsNonEmpty)
                    writer.AppendLineFormat(LabelPattern, nameof(pattern.Attributes), XedRender.format(pattern.Attributes));

                if(pattern.Effects.IsNonEmpty)
                    writer.AppendLineFormat(LabelPattern, nameof(pattern.Effects), XedRender.format(pattern.Effects));

                writer.AppendLine(XedPatterns.FieldTitle);
                var fcount = XedPatterns.RenderFields(tables, pattern, rbuffer);
                for(var k=0; k<fcount;k++)
                    writer.AppendLine(skip(rbuffer,k));

                writer.AppendLine(XedPatterns.OpsTitle);
                var opscount = XedPatterns.RenderOps(tables, pattern, rbuffer);
                for(var k=0; k<opscount;k++)
                    writer.AppendLine(skip(rbuffer,k));

                writer.AppendLine(RP.PageBreak120);
            }

            EmittedFile(emitting, src.Count);
        }
    }
}