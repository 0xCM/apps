//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    using static XedRules;
    using static XedPatterns;

    public partial class XedDocs : AppService<XedDocs>
    {
        IntelXed Xed => Service(Wf.IntelXed);

        XedPaths XedPaths => Service(Wf.XedPaths);

        RuleDoc CalcRuleDoc(RuleTables tables)
            => new RuleDoc(tables);

        InstDoc CalcInstDoc(RuleTables tables, Index<InstPattern> src)
            => new InstDoc(tables, src.Map(x => new InstDocPart(x)));

        public void EmitDocs(RuleTables tables, Index<InstPattern> patterns)
        {
            var inst = CalcInstDoc(tables, patterns);
            FileEmit(inst.Format(), inst.Parts.Count, XedPaths.Targets() + FS.file("xed.instructions", FS.Md), TextEncodingKind.Asci);
            var rules = CalcRuleDoc(tables);
            FileEmit(rules.Format(), 1, XedPaths.Targets() + FS.file("xed.rules", FS.Md), TextEncodingKind.Asci);
            EmitPatternDocs(patterns, XedPaths.DocTarget(XedDocKind.PatternDetail));
        }

        void EmitPatternDocs(Index<InstPattern> src, FS.FilePath dst)
        {
            src.Sort();
            var formatter = InstPageFormatter.create();
            EmitIsaPages(formatter, src);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var j=0; j<src.Count; j++)
                writer.Write(formatter.Format(src[j]));

            EmittedFile(emitting, src.Count);
        }

        void EmitIsaPages(InstPageFormatter formatter, Index<InstPattern> src)
        {
            XedPaths.InstIsaRoot().Delete();
            iter(formatter.FormatGroups(src), EmitIsaGroup, true);
        }

        void EmitIsaGroup(InstIsaFormat src)
        {
            var dst = XedPaths.InstIsaPath(src.Isa);
            Require.invariant(!dst.Exists);
            FileEmit(src.Content, src.LineCount, dst, TextEncodingKind.Asci);
        }
    }
}