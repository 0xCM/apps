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
        XedPaths XedPaths => Service(Wf.XedPaths);

        XedRules XedRules => Service(Wf.XedRules);

        RuleDoc CalcRuleDoc(RuleTables tables)
            => new RuleDoc(tables);

        InstDoc CalcInstDoc(Index<InstPattern> src)
            => new InstDoc(src.Map(x => new InstDocPart(x)));

        public void EmitDocs()
        {
            EmitRuleDocs(XedRules.CalcRules());
            EmitInstDocs(XedRules.CalcPatterns());
        }

        public void EmitInstDocs(Index<InstPattern> src)
        {
            var inst = CalcInstDoc(src);
            FileEmit(inst.Format(), inst.Parts.Count, XedPaths.Targets() + FS.file("xed.instructions", FS.Md), TextEncodingKind.Asci);
            EmitPatternDocs(src, XedPaths.DocTarget(XedDocKind.PatternDetail));
        }

        public void EmitRuleDocs(RuleTables src)
        {
            var rules = CalcRuleDoc(src);
            FileEmit(rules.Format(), 1, XedPaths.Targets() + FS.file("xed.rules", FS.Md), TextEncodingKind.Asci);
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
            iter(formatter.GroupFormats(src), EmitIsaGroup, true);
        }

        void EmitIsaGroup(InstIsaFormat src)
        {
            var dst = XedPaths.InstIsaPath(src.Isa);
            Require.invariant(!dst.Exists);
            FileEmit(src.Content, src.LineCount, dst, TextEncodingKind.Asci);
        }
    }
}