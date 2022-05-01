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

        public void EmitDocs(Index<InstPattern> src)
        {
            var inst = new InstDoc(src.Map(x => new InstDocPart(x)));
            FileEmit(inst.Format(), inst.Parts.Count, XedPaths.Target("xed.instructions", FS.Md), TextEncodingKind.Asci);
            EmitDocs(src, XedPaths.Target("xed.inst.patterns.detail", FS.Txt));
        }

        public void EmitDocs(RuleTables src)
            => FileEmit(RuleDocFormatter.create(Rules.CalcRuleCells(src)).Format(), 1, XedPaths.Target("xed.rules", FS.Md), TextEncodingKind.Asci);

        void EmitDocs(Index<InstPattern> src, FS.FilePath dst)
        {
            src.Sort();
            var formatter = InstPageFormatter.create();

            XedPaths.InstIsaRoot().Delete();
            iter(formatter.GroupFormats(src), EmitIsaGroup, PllExec);

            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var j=0; j<src.Count; j++)
                writer.Write(formatter.Format(src[j]));

            EmittedFile(emitting, src.Count);
        }

        void EmitIsaGroup(InstIsaFormat src)
        {
            var dst = XedPaths.InstIsaPath(src.Isa);
            Require.invariant(!dst.Exists);
            FileEmit(src.Content, src.LineCount, dst, TextEncodingKind.Asci);
        }
    }
}