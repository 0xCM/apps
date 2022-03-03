//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    public class XedPaths : AppService<XedPaths>
    {
        FS.FolderPath XedSources;

        FS.FolderPath XedTargets;

        protected override void OnInit()
        {
            XedSources = ProjectDb.Sources("intel/xed.primary");
            XedTargets = ProjectDb.Subdir("xed");
        }

        public FS.FolderPath Sources()
            => XedSources;

        public FS.FolderPath Targets()
            => XedTargets;

        public FS.FilePath IsaFormsPath(ChipCode chip)
            => XedTargets + FS.folder("isaforms") + FS.file(string.Format("xed.isa.{0}", chip), FS.Csv);

        public FS.FilePath ChipMapTarget()
            => XedTargets + FS.file("xed.chipmap", FS.Csv);

        public FS.FilePath FormCatalogPath()
            => XedTargets + FS.file(Tables.identify<XedFormImport>().Format(), FS.Csv);

        public FS.FilePath FieldDefsTarget()
            => XedTargets + Tables.filename<XedFieldDef>();

        public FS.FilePath RuleTableExp(RuleSetKind kind)
            => kind switch {
                 RuleSetKind.Enc => DocTarget(XedDocKind.EncRuleTableExp),
                 RuleSetKind.Dec => DocTarget(XedDocKind.DecRuleTableExp),
                 RuleSetKind.EncDec => DocTarget(XedDocKind.EncDecRuleTableExp),
                 _ => FS.FilePath.Empty
            };

        public FS.FilePath RulePatterns(RuleSetKind kind)
            => kind switch {
                 RuleSetKind.Enc => DocTarget(XedDocKind.EncRulePatterns),
                 RuleSetKind.Dec => DocTarget(XedDocKind.DecRulePatterns),
                 _ => FS.FilePath.Empty
            };

        public FS.FilePath DocSource(XedDocKind kind)
            => Sources() + (kind switch{
                XedDocKind.EncInstDef => FS.file("all-enc-instructions", FS.Txt),
                XedDocKind.DecInstDef => FS.file("all-dec-instructions", FS.Txt),
                XedDocKind.EncRuleTable => FS.file("all-enc-patterns", FS.Txt),
                XedDocKind.DecRuleTable => FS.file("all-dec-patterns", FS.Txt),
                XedDocKind.EncDecRuleTable => FS.file("all-enc-dec-patterns", FS.Txt),
                XedDocKind.Widths => FS.file("all-widths", FS.Txt),
                XedDocKind.PointerWidths => FS.file("all-pointer-names", FS.Txt),
                XedDocKind.Fields => FS.file("all-fields", FS.Txt),
                XedDocKind.FormData => FS.file("xed-idata", FS.Txt),
                XedDocKind.ChipData => FS.file("xed-cdata", FS.Txt),
                XedDocKind.RuleSeq => FS.file("all-enc-patterns", FS.Txt),
                _ => FS.FileName.Empty
            });

        public FS.FilePath DocTarget(XedDocKind kind)
            => Targets() + ( kind switch{
                 XedDocKind.EncInstDef => FS.file("xed.rules.enc", FS.Txt),
                 XedDocKind.DecInstDef=> FS.file("xed.rules.dec", FS.Txt),
                 XedDocKind.EncRuleTable => FS.file("xed.rules.enc.tables", FS.Txt),
                 XedDocKind.DecRuleTable => FS.file("xed.rules.dec.tables", FS.Txt),
                 XedDocKind.EncDecRuleTable => FS.file("xed.rules.encdec.tables", FS.Txt),
                 XedDocKind.Widths => FS.file("xed.rules.widths", FS.Csv),
                 XedDocKind.PointerWidths => Tables.filename<PointerWidthInfo>(),
                 XedDocKind.EncRulePatterns => FS.file("xed.rules.enc.patterns", FS.Csv),
                 XedDocKind.DecRulePatterns => FS.file("xed.rules.dec.patterns", FS.Csv),
                 XedDocKind.OpCodeKinds => Tables.filename<OcMapKind>(),
                 XedDocKind.OpCodes => Tables.filename<RuleOpCode>(),
                 XedDocKind.OpEnc =>  FS.file("xed.rules.enc.operands", FS.Csv),
                 XedDocKind.OpDec => FS.file("xed.rules.dec.operands", FS.Csv),
                 XedDocKind.RuleSeq => FS.file("xed.rules.seq", FS.Txt),
                 XedDocKind.EncRuleTableExp => FS.file("xed.rules.enc.tables.exp", FS.Txt),
                 XedDocKind.DecRuleTableExp => FS.file("xed.rules.dec.tables.exp", FS.Txt),
                 XedDocKind.EncDecRuleTableExp => FS.file("xed.rules.encdec.tables.exp", FS.Txt),
                 _ => FS.FileName.Empty
            });
    }
}