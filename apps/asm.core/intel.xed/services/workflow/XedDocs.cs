//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedPatterns;
    using static XedRules;

    public partial class XedDocs : AppService<XedDocs>
    {
        IntelXed Xed => Service(Wf.IntelXed);

        XedPaths XedPaths => Service(Wf.XedPaths);

        public InstDoc CalcInstDoc(Index<InstPattern> src)
            => new InstDoc(src.Map(x => new InstDocPart(x)));

        public void EmitDocs(RuleTableSet tables, Index<InstPattern> patterns)
        {
            var doc = CalcInstDoc(patterns);
            FileEmit(doc.Format(), doc.Parts.Count, XedPaths.Targets() + FS.file("xed.instructions", FS.Md), TextEncodingKind.Asci);
        }
    }
}