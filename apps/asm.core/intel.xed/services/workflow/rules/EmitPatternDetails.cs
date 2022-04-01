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
            var formatter = InstPageFormatter.create(tables);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var j=0; j<src.Count; j++)
                writer.Write(formatter.Format(src[j]));

            EmittedFile(emitting, src.Count);
        }

        void EmitIsaPages(RuleTableSet tables, Index<InstPattern> src)
        {
            XedPaths.InstIsaRoot().Delete();
            var groups = InstPageFormatter.FormatGroups(tables, src);
            iter(groups, EmitIsaGroup, PllExec);
        }

        void EmitIsaGroup(InstIsaFormat src)
        {
            var dst = XedPaths.InstIsaPath(src.Isa);
            Require.invariant(!dst.Exists);
            FileEmit(src.Content, src.LineCount, dst, TextEncodingKind.Asci);
        }
    }
}