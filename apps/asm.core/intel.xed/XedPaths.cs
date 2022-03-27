//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static XedPatterns;

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

        public FS.FilePath Table<T>()
            where T : struct
                => Targets() + Tables.filename<T>();

        public FS.FilePath Table<T>(string scope)
            where T : struct
                =>  Targets(scope) + Tables.filename<T>();

        public FS.FilePath RuleTable<T>()
            where T : struct
                => RuleTargets() + Tables.filename<T>();

        public FS.FilePath IsaFormsPath(ChipCode chip)
            => Targets("isaforms") + FS.file(string.Format("xed.isa.{0}", chip), FS.Csv);

        public FS.FilePath ChipMapTarget()
            => Targets() + FS.file("xed.chipmap", FS.Csv);

        public FS.FilePath FormCatalogPath()
            => Targets() + FS.file(Tables.identify<FormImport>().Format(), FS.Csv);

        public FS.FilePath FieldDefsTarget()
            => Targets() + Tables.filename<XedFieldDef>();

        public FS.FilePath RulePatterns()
            => DocTarget(XedDocKind.RulePatterns);

        static FS.FileName EncInstDef = FS.file("all-enc-instructions", FS.Txt);

        static FS.FileName DecInstDef = FS.file("all-dec-instructions", FS.Txt);

        static FS.FileName EncRuleTable = FS.file("all-enc-patterns", FS.Txt);

        static FS.FileName DecRuleTable = FS.file("all-dec-patterns", FS.Txt);

        static FS.FileName EncDecRuleTable = FS.file("all-enc-dec-patterns", FS.Txt);

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
            => RuleTargets() + FS.folder(sig.TableKind.ToString().ToLower()) + TableFile(sig);

        public FS.FilePath TableDef(RuleTableKind kind)
            => RuleTargets() + FS.file(string.Format("{0}.{1}",RuleTableRow.TableId, kind.ToString().ToLower()), FS.Csv);

        public FS.FilePath RuleSpecs(RuleTableKind kind)
        {
            var name = kind switch
            {
                RuleTableKind.Enc => "xed.rules.specs.enc",
                RuleTableKind.Dec => "xed.rules.specs.dec",
                RuleTableKind.EncDec => "xed.rules.specs.encdec",
                _ => EmptyString
            };
            return RuleTargets() + FS.file(name,FS.Csv);
        }

        public FS.FilePath RuleSchemas()
            => RuleTargets() + Tables.filename<RuleSchema>();

        public FS.FolderPath InstIsaRoot()
            => Targets("instructions");
        public FS.FilePath InstIsaPath(InstPattern src)
            => InstIsaRoot() + instfolder(src.Isa) + FS.file(src.Classifier, FS.Txt);

        static FS.FolderName instfolder(InstIsa isa)
        {
            var name = isa.Format();
            var dst =  isa.IsEmpty ? FS.folder("OTHER") : FS.folder(name);
            switch(isa.Kind)
            {
                case IsaKind.AVX_GFNI:
                case IsaKind.AVX_VNNI:
                    dst = FS.folder(string.Format("AVX512/{0}", name));
                break;
                case IsaKind.ADOX_ADCX:
                case IsaKind.AMX_BF16:
                case IsaKind.AMX_INT8:
                case IsaKind.AMX_TILE:
                case IsaKind.AMD:
                case IsaKind.CLDEMOTE:
                case IsaKind.CLZERO:
                case IsaKind.CLWB:
                case IsaKind.CLFSH:
                case IsaKind.CLFLUSHOPT:
                case IsaKind.F16C:
                case IsaKind.FXSAVE:
                case IsaKind.FXSAVE64:
                case IsaKind.HRESET:
                case IsaKind.INVPCID:
                case IsaKind.LAHF:
                case IsaKind.LZCNT:
                case IsaKind.MONITOR:
                case IsaKind.MONITORX:
                case IsaKind.PCLMULQDQ:
                case IsaKind.PKU:
                case IsaKind.POPCNT:
                case IsaKind.PTWRITE:
                case IsaKind.PREFETCH_NOP:
                case IsaKind.PREFETCHWT1:
                case IsaKind.RDPMC:
                case IsaKind.RDRAND:
                case IsaKind.RDSEED:
                case IsaKind.SGX:
                case IsaKind.SGX_ENCLV:
                case IsaKind.VMFUNC:
                    dst = FS.folder(string.Format("OTHER/{0}", name));
                break;
                default:
                if(text.begins(name,"AVX512"))
                    dst = FS.folder(string.Format("AVX512/{0}", name));
                break;
            }

            return dst;
        }

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
                 XedDocKind.PatternInfo => Tables.filename<InstPatternInfo>(),
                 XedDocKind.RuleSeq => FS.file("xed.rules.seq", FS.Txt),
                 XedDocKind.MacroDefs => FS.file("xed.rules.macros", FS.Csv),
                 XedDocKind.PatternDetail => FS.file("xed.inst.patterns.detail", FS.Txt),
                 XedDocKind.PatternOps => Tables.filename<PatternOpInfo>(),
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