//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

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

        public FS.FilePath FieldDefSource()
            => XedSources + FS.file("all-fields", FS.Txt);

        public FS.FilePath FormSourcePath()
            => XedSources + FS.file("xed-idata", FS.Txt);

        public FS.FilePath ChipSourcePath()
            => XedSources + FS.file("xed-cdata", FS.Txt);

        public FS.FilePath IsaFormsPath(ChipCode chip)
            => XedTargets + FS.folder("isaforms") + FS.file(string.Format("xed.isa.{0}", chip), FS.Csv);

        public FS.FilePath ChipMapTarget()
            => XedTargets + FS.file("xed.chipmap", FS.Csv);

        public FS.FilePath FormCatalogPath()
            => XedTargets + FS.file(Tables.identify<XedFormImport>().Format(), FS.Csv);

        public FS.FilePath FieldDefsTarget()
            => XedTargets + Tables.filename<XedFieldDef>();

        public FS.FilePath RuleSource(RuleDocKind kind)
            => Sources() + FS.file(Symbols.format(kind), FS.Txt);

        public FS.FilePath RuleTarget(RuleDocKind kind)
            => Targets() + ( kind switch{
                 RuleDocKind.EncInstDef => FS.file("xed.rules.encoding", FS.Txt),
                 RuleDocKind.DecInstDef=> FS.file("xed.rules.decoding", FS.Txt),
                 RuleDocKind.EncRuleTable => FS.file("xed.rules.encoding.tables", FS.Txt),
                 RuleDocKind.DecRuleTable => FS.file("xed.rules.decoding.tables", FS.Txt),
                 RuleDocKind.EncDecRuleTable => FS.file("xed.rules.encdec.tables", FS.Txt),
                 RuleDocKind.Widths => FS.file("xed.rules.widths", FS.Csv),
                 RuleDocKind.PointerWidths => Tables.filename<PointerWidthInfo>(),
                 RuleDocKind.RulePatterns => Tables.filename<RulePattern>(),
                 RuleDocKind.OpCodePatterns => Tables.filename<OpCodePattern>(),
                 RuleDocKind.OpCodes => Tables.filename<XedOpCodeRecord>(),
                 RuleDocKind.OperandEncoding =>  FS.file("xed.rules.encoding.operands", FS.Csv),
                 RuleDocKind.OperandDecoding => FS.file("xed.rules.decoding.operands", FS.Csv),
                 _ => FS.FileName.Empty
            });
    }
}