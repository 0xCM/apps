//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;
    using static XedPatterns;

    public partial class XedDocs : AppService<XedDocs>
    {
        static XedPaths XedPaths => XedPaths.Service;

        static AppData AppData => AppData.get();

        static bool PllExec => AppData.PllExec();

        XedRules Rules => Service(Wf.XedRules);

        public void EmitDocs()
        {
            exec(AppData.PllExec(),
                EmitRuleDocs,
                EmitInstDocs
            );
        }

        public void EmitInstDocs(Index<InstPattern> src)
        {
            var inst = new InstDoc(src.Map(x => new InstDocPart(x)));
            FileEmit(inst.Format(), inst.Parts.Count, XedPaths.Targets() + FS.file("xed.instructions", FS.Md), TextEncodingKind.Asci);
            EmitPatternDocs(src, XedPaths.DocTarget(XedDocKind.PatternDetail));
        }

        public void EmitRuleDocs(RuleTables src)
            => FileEmit(RuleDocFormatter.create(Rules.CaclcRuleCells(src)).Format(), 1, XedPaths.Targets() + FS.file("xed.rules", FS.Md), TextEncodingKind.Asci);

        void EmitInstDocs()
            => EmitInstDocs(Rules.CalcPatterns());

        void EmitRuleDocs()
            => EmitRuleDocs(Rules.CalcRules());

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
            iter(formatter.GroupFormats(src), EmitIsaGroup, PllExec);
        }

        void EmitIsaGroup(InstIsaFormat src)
        {
            var dst = XedPaths.InstIsaPath(src.Isa);
            Require.invariant(!dst.Exists);
            FileEmit(src.Content, src.LineCount, dst, TextEncodingKind.Asci);
        }
    }
}