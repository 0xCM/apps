//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedPatterns;

    public partial class XedDocs : AppService<XedDocs>
    {
        static XedPaths XedPaths => XedPaths.Service;

        XedRules Rules => Service(Wf.XedRules);

        static AppData AppData
        {
            [MethodImpl(Inline)]
            get => AppData.get();
        }

        bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.PllExec();
        }

        public void Emit(Index<InstPattern> patterns, RuleTables rules)
        {
            exec(PllExec,
                () => EmitPatternDocs(patterns),
                () => EmitRuleDocs(rules)
            );
        }

        void EmitPatternDocs(Index<InstPattern> src)
        {
            EmitDetails(src);
            EmitSummary(src);
        }

        void EmitSummary(Index<InstPattern> src)
        {
            var dst = XedPaths.DocTarget("instructions", FileKind.Md);
            var inst = new InstDoc(src.Map(x => new InstDocPart(x)));
            FileEmit(inst.Format(), inst.Parts.Count, dst, TextEncodingKind.Asci);
        }

        void EmitDetails(Index<InstPattern> src)
        {
            var dst = XedPaths.DocTarget("instructions.detail", FileKind.Txt);
            var formatter = InstPageFormatter.create();
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var j=0; j<src.Count; j++)
                writer.Write(formatter.Format(src[j]));
            EmittedFile(emitting, src.Count);
        }

        void EmitRuleDocs(RuleTables src)
            => FileEmit(RuleDocFormatter.create(Rules.CalcRuleCells(src)).Format(), 1, XedPaths.DocTarget("rules", FileKind.Md), TextEncodingKind.Asci);
    }
}