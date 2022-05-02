//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    public class XedPaths //: GlobalService<XedPaths, XedPaths.SvcState>
    {
        public static XedPaths Service => Instance;

        public readonly struct SvcState
        {
            public readonly FS.FolderPath XedSources;

            public readonly FS.FolderPath XedTargets;

            public SvcState(FS.FolderPath src, FS.FolderPath dst)
            {
                XedSources = src;
                XedTargets = dst;
            }
        }

        readonly SvcState State;

        public FS.FolderPath Sources()
            => State.XedSources;

        public FS.FolderPath Targets()
            => State.XedTargets;

        public FS.FolderPath Targets(string scope)
            => Targets() + FS.folder(scope);

        public FS.FolderPath RuleTargets()
            => Targets("rules.tables");

        public FS.FolderPath RuleTableDefs()
            => RuleTargets() + FS.folder("defs");

        public FS.FilePath Table<T>()
            where T : struct
                => Targets() + Tables.filename<T>();

        public FS.FilePath Table<T>(string suffix)
            where T : struct
                => Targets() + Tables.filename<T>().ChangeExtension(FS.ext(string.Format("{0}.{1}", suffix, FS.Csv)));

        public FS.FilePath RuleTable<T>()
            where T : struct
                => RuleTargets() + Tables.filename<T>();

        public FS.FilePath IsaFormsPath(ChipCode chip)
            => Targets("isaforms") + FS.file(string.Format("xed.isa.{0}", chip), FS.Csv);

        public FS.FilePath ChipMapTarget()
            => Targets() + FS.file("xed.chipmap", FS.Csv);

        public FS.FilePath FormCatalogPath()
            => Targets() + FS.file(Tables.identify<FormImport>().Format(), FS.Csv);

        static FS.FileName EncInstDef = FS.file("all-enc-instructions", FS.Txt);

        static FS.FileName DecInstDef = FS.file("all-dec-instructions", FS.Txt);

        static FS.FileName EncRuleTable = FS.file("all-enc-patterns", FS.Txt);

        static FS.FileName DecRuleTable = FS.file("all-dec-patterns", FS.Txt);

        static FS.FileName EncDecRuleTable = FS.file("all-enc-dec-patterns", FS.Txt);

        public static RuleTableKind tablekind(FS.FileName src)
        {
            return srckind(src) switch
            {
                XedDocKind.EncRuleTable => RuleTableKind.ENC,
                XedDocKind.DecRuleTable => RuleTableKind.DEC,
                _ => 0
            };
        }

        public FS.FileUri TableDef(RuleTableKind kind, Nonterminal nt)
            => RuleTargets() + FS.folder("defs") + FS.file(string.Format("{0}.{1}", nt.Name, kind), FS.Csv);

        public FS.FileUri TableDef(RuleSig sig)
            => RuleTargets() + FS.folder("defs") + FS.file(sig.Format(), FS.Csv);

        public FS.FileUri CheckedTableDef(RuleSig sig)
        {
            var uri = TableDef(sig);
            return uri.Path.Exists ? uri : FS.FileUri.Empty;
        }

        public FS.FileUri CheckedTableDef(RuleName rule, bit decfirst, out RuleSig sig)
        {
            var dst = FS.FileUri.Empty;
            if(decfirst)
            {
                sig = new RuleSig(RuleTableKind.DEC, rule);
                dst = CheckedTableDef(sig);
                if(dst.IsEmpty)
                {
                    sig = new RuleSig(RuleTableKind.ENC,rule);
                    dst = CheckedTableDef(sig);
                }
            }
            else
            {
                sig = new RuleSig(RuleTableKind.ENC,rule);
                dst = CheckedTableDef(sig);
                if(dst.IsEmpty)
                {
                    sig = new RuleSig(RuleTableKind.DEC,rule);
                    dst = CheckedTableDef(sig);
                }
            }
            return dst;
        }

        public FS.FilePath RuleSpecs()
            => RuleTargets() + FS.file("xed.rules.specs", FS.Csv);

        public FS.FolderPath InstIsaRoot()
            => Targets("instructions");

        public FS.FilePath InstIsaPath(InstIsa isa)
            => InstIsaRoot() + FS.file(text.ifempty(isa.Format(), "UNKNOWN"), FS.Txt);

        public FS.FilePath RuleSource(RuleTableKind kind)
        {
            var name = kind switch
            {
                RuleTableKind.ENC => EncRuleTable,
                RuleTableKind.DEC => DecRuleTable,
                _ => FS.FileName.Empty
            };

            return Sources() + name;
        }

        public FS.FilePath RuleTarget(string name, FS.FileExt ext)
            => RuleTargets() + FS.file("xed.rules." + name, ext);

        public FS.FilePath Target(string name, FS.FileExt ext)
            => Targets() + FS.file(name, ext);

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
                 XedDocKind.PatternInfo => Tables.filename<InstPatternRecord>(),
                 XedDocKind.RuleSeq => FS.file("xed.rules.seq", FS.Txt),
                 XedDocKind.MacroDefs => FS.file("xed.rules.macros", FS.Csv),
                 XedDocKind.PatternDetail => FS.file("xed.inst.patterns.detail", FS.Txt),
                 XedDocKind.PatternOps => Tables.filename<InstOperandRow>(),
                 XedDocKind.RuleSigs => FS.file("rules.tables.sigs", FileKind.Csv.Ext()),
                 _ => FS.FileName.Empty
            });


        XedPaths()
        {
            var data = AppData.get();
            var db = data.ProjectDb;
            State = new (db.Sources("intel/xed.primary"), db.Subdir("xed"));
        }

        static XedPaths Instance = new();
    }
}