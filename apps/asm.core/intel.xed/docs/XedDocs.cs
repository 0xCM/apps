//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;

    public partial class XedDocs : AppService<XedDocs>
    {
        IntelXed Xed => Service(Wf.IntelXed);

        XedPaths XedPaths => Service(Wf.XedPaths);

        public RuleDoc CalcRuleDoc(RuleTables tables)
            => new RuleDoc(tables);

        public InstDoc CalcInstDoc(RuleTables tables, Index<InstPattern> src)
            => new InstDoc(tables, src.Map(x => new InstDocPart(x)));

        public void EmitDocs(RuleTables tables, Index<InstPattern> patterns)
        {
            var inst = CalcInstDoc(tables, patterns);
            FileEmit(inst.Format(), inst.Parts.Count, XedPaths.Targets() + FS.file("xed.instructions", FS.Md), TextEncodingKind.Asci);
            var rules = CalcRuleDoc(tables);
            FileEmit(rules.Format(), inst.Parts.Count, XedPaths.Targets() + FS.file("xed.rules", FS.Md), TextEncodingKind.Asci);
        }
    }
}