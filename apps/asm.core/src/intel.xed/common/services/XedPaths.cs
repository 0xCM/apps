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

        public FS.FolderPath Targets(string scope)
            => Targets() + FS.folder(scope);

        public FS.FolderPath RuleTables()
            => Targets("rules.tables");

        public FS.FilePath Table<T>()
            where T : struct
                => Targets() + Tables.filename<T>();

        public FS.FilePath IsaFormsPath(ChipCode chip)
            => Targets("isaforms") + FS.file(string.Format("xed.isa.{0}", chip), FS.Csv);

        public FS.FilePath ChipMapTarget()
            => Targets() + FS.file("xed.chipmap", FS.Csv);

        public FS.FilePath FormCatalogPath()
            => Targets() + FS.file(Tables.identify<XedFormImport>().Format(), FS.Csv);

        public FS.FilePath FieldDefsTarget()
            => Targets() + Tables.filename<XedFieldDef>();

        public FS.FilePath RulePatterns()
            => DocTarget(XedDocKind.RulePatterns);

        static FS.FileName EncInstDef = FS.file("all-enc-instructions", FS.Txt);

        static FS.FileName DecInstDef = FS.file("all-dec-instructions", FS.Txt);

        static FS.FileName EncRuleTable = FS.file("all-enc-patterns", FS.Txt);

        static FS.FileName DecRuleTable = FS.file("all-dec-patterns", FS.Txt);

        static FS.FileName EncDecRuleTable = FS.file("all-enc-dec-patterns", FS.Txt);

        public FS.FilePath TableSigs()
            => RuleTables() + FS.file("rules.tables.sigs", FileKind.Csv.Ext());

        public FS.FilePath TableInfo(RuleTableKind kind)
            => kind switch
            {
                RuleTableKind.Enc => RuleTables() + FS.file("rules.tables.info.enc", FS.Txt),
                RuleTableKind.Dec => RuleTables() + FS.file("rules.tables.info.dec", FS.Txt),
                RuleTableKind.EncDec => RuleTables() + FS.file("rules.tables.info.encdec", FS.Txt),
                _ => FS.FilePath.Empty
            };

        public static RuleTableKind tablekind(FS.FileName src)
        {
            return srckind(src) switch
            {
                XedDocKind.EncRuleTable => RuleTableKind.Enc,
                XedDocKind.DecRuleTable => RuleTableKind.Dec,
                XedDocKind.EncDecRuleTable => RuleTableKind.EncDec,
                _ => 0
            };
        }

        public FS.FileName TableFile(RuleSig sig)
            => FS.file(string.Format("{0}.{1}",RuleTableRow.TableId, sig.Name), FS.Csv);

        public FS.FilePath TableDef(RuleSig sig)
            => Targets("rules.tables") + FS.folder(sig.TableKind.ToString().ToLower()) + TableFile(sig);

        public FS.FilePath TableDef(RuleTableKind kind)
            => Targets("rules.tables") + FS.file(string.Format("{0}.{1}",RuleTableRow.TableId, kind.ToString().ToLower()), FS.Csv);

        public FS.FilePath RuleSource(RuleTableKind kind)
        {
            var name = kind switch
            {
                RuleTableKind.Enc => EncRuleTable,
                RuleTableKind.Dec => DecRuleTable,
                RuleTableKind.EncDec => EncDecRuleTable,
                _ => FS.FileName.Empty
            };

            return Sources() + name;
        }

        public static XedDocKind srckind(FS.FileName src)
        {
            if(src == EncInstDef)
                return XedDocKind.EncInstDef;
            else if(src == DecInstDef)
                return XedDocKind.DecInstDef;
            else if(src == EncRuleTable)
                return XedDocKind.EncRuleTable;
            else if(src == DecRuleTable)
                return XedDocKind.DecRuleTable;
            else if(src == EncDecRuleTable)
                return XedDocKind.EncDecRuleTable;
            else
                return 0;
        }

        public FS.FilePath DocSource(XedDocKind kind)
            => Sources() + (kind switch{
                XedDocKind.EncInstDef => EncInstDef,
                XedDocKind.DecInstDef => DecInstDef,
                XedDocKind.EncRuleTable => EncRuleTable,
                XedDocKind.DecRuleTable => DecRuleTable,
                XedDocKind.EncDecRuleTable => EncDecRuleTable,
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
                 XedDocKind.RuleTable => FS.file("xed.rules.tables", FS.Txt),
                 XedDocKind.EncInstDef => FS.file("xed.rules.enc", FS.Txt),
                 XedDocKind.DecInstDef=> FS.file("xed.rules.dec", FS.Txt),
                 XedDocKind.EncRuleTable => FS.file("xed.rules.enc.tables", FS.Txt),
                 XedDocKind.DecRuleTable => FS.file("xed.rules.dec.tables", FS.Txt),
                 XedDocKind.EncDecRuleTable => FS.file("xed.rules.encdec.tables", FS.Txt),
                 XedDocKind.Widths => FS.file("xed.rules.widths", FS.Csv),
                 XedDocKind.PointerWidths => Tables.filename<PointerWidthInfo>(),
                 XedDocKind.RulePatterns => FS.file("xed.rules.patterns", FS.Csv),
                 XedDocKind.DecRulePatterns => FS.file("xed.rules.dec.patterns", FS.Csv),
                 XedDocKind.OpCodeKinds => Tables.filename<OcMapKind>(),
                 XedDocKind.PatternInfo => Tables.filename<PatternInfo>(),
                 XedDocKind.OpEnc =>  FS.file("xed.rules.enc.operands", FS.Csv),
                 XedDocKind.OpDec => FS.file("xed.rules.dec.operands", FS.Csv),
                 XedDocKind.RuleSeq => FS.file("xed.rules.seq", FS.Txt),
                 XedDocKind.EncRuleTableExp => FS.file("xed.rules.enc.tables.exp", FS.Txt),
                 XedDocKind.DecRuleTableExp => FS.file("xed.rules.dec.tables.exp", FS.Txt),
                 XedDocKind.EncDecRuleTableExp => FS.file("xed.rules.encdec.tables.exp", FS.Txt),
                 XedDocKind.MacroDefs => FS.file("xed.rules.macros", FS.Csv),
                 XedDocKind.PatternDetail => FS.file("xed.patterns.detail", FS.Txt),
                 XedDocKind.PatternOps => Tables.filename<PatternOpDetail>(),
                 _ => FS.FileName.Empty
            });
    }
}