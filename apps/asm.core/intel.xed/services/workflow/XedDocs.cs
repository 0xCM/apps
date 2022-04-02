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

        public InstDoc CalcInstDoc(RuleTables tables, Index<InstPattern> src)
            => new InstDoc(tables, src.Map(x => new InstDocPart(x)));

        public void EmitDocs(RuleTables tables, Index<InstPattern> patterns)
        {
            var doc = CalcInstDoc(tables,patterns);
            FileEmit(doc.Format(), doc.Parts.Count, XedPaths.Targets() + FS.file("xed.instructions", FS.Md), TextEncodingKind.Asci);
        }
    }
}