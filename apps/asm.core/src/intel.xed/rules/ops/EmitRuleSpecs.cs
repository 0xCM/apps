//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public void EmitRuleSpecs()
            => exec(PllWf,
                () => EmitRuleSpecs(RuleTableKind.Enc),
                () => EmitRuleSpecs(RuleTableKind.Dec),
                () => EmitRuleSpecs(RuleTableKind.EncDec)
            );

        void EmitRuleSpecs(RuleTableKind kind)
        {
            var src = RuleTableParser.specs(XedPaths.RuleSource(kind));
            var name = kind switch
            {
                RuleTableKind.Enc => "xed.rules.enc",
                RuleTableKind.Dec => "xed.rules.dec",
                RuleTableKind.EncDec => "xed.rules.encdec",
                _ => EmptyString
            };
            var dst = AppDb.XedPath("rules.tables", name, FileKind.Txt);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<src.Length; i++)
                writer.WriteLine(src[i]);
            EmittedFile(emitting,src.Length);
        }
    }
}