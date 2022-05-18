//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static Markdown;

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

        public FS.FolderPath Output()
            => State.XedTargets;

        public DbTargets Imports()
            => new DbTargets(Output(), "imports");

        public DbTargets Targets(string scope)
            => new DbTargets(Output(), scope);

        public DbTargets Targets()
            => new DbTargets(Output());

        public DbTargets RuleTargets()
            => Targets("rules");

        FS.FolderPath RuleOutput()
            => Output() + FS.folder("rules");

        public FS.FilePath Table<T>()
            where T : struct
                => Output() + Tables.filename<T>();

        public FS.FilePath Table<T>(string suffix)
            where T : struct
                => Output() + Suffixed<T>(suffix);

        FS.FileName Suffixed<T>(string suffix)
            where T : struct
                => Tables.filename<T>().ChangeExtension(FS.ext(string.Format("{0}.{1}", suffix, FS.Csv)));

        public FS.FilePath RuleTable<T>()
            where T : struct
                => RuleOutput() + Tables.filename<T>();

        public FS.FilePath FormCatalogPath()
            => RefTargets() + FS.file(Tables.identify<FormImport>().Format(), FS.Csv);

        static FS.FileName EncInstDef = FS.file("all-enc-instructions", FS.Txt);

        static FS.FileName DecInstDef = FS.file("all-dec-instructions", FS.Txt);

        static FS.FileName EncRuleTable = FS.file("all-enc-patterns", FS.Txt);

        static FS.FileName DecRuleTable = FS.file("all-dec-patterns", FS.Txt);

        static FS.FileName EncDecRuleTable = FS.file("all-enc-dec-patterns", FS.Txt);

        public FS.FolderPath DbTargets()
            => Output() + FS.folder("db");

        public FS.FilePath DbTable<T>()
            where T : struct
                 => DbTargets() + Tables.filename<T>("xed.db");

        public FS.FilePath DbTarget(string name, FileKind kind)
            => DbTargets() + FS.file(string.Format("xed.db.{0}",name), kind.Ext());

        public AbsoluteLink MarkdownLink(RuleSig sig)
            => Markdown.link(string.Format("{0}::{1}()", sig.TableKind, sig.TableName), RulePage(sig));

        public static RuleTableKind tablekind(FS.FileName src)
        {
            return srckind(src) switch
            {
                XedDocKind.EncRuleTable => RuleTableKind.ENC,
                XedDocKind.DecRuleTable => RuleTableKind.DEC,
                _ => 0
            };
        }

        public FS.FilePath InstDumpSource()
            => Sources()  +  FS.file("xed-dump",FileKind.Txt.Ext());

        public FS.FolderPath DisasmTargets(IProjectWs project)
            => Ws.ProjectData(project, "xed.disasm");

        public FS.FolderPath RefTargets()
            => Output() + FS.folder("refs");

        public FS.FolderPath RulePages()
            => RuleOutput() + FS.folder("pages");

        public FS.FileUri RulePage(RuleSig sig)
            => RulePages() + FS.file(sig.Format(), FS.Csv);

        public FS.FileUri CheckedRulePage(RuleSig sig)
        {
            var uri = RulePage(sig);
            return uri.Path.Exists ? uri : FS.FileUri.Empty;
        }

        public FS.FileUri CheckedTableDef(RuleName rule, bit decfirst, out RuleSig sig)
        {
            var dst = FS.FileUri.Empty;
            if(decfirst)
            {
                sig = new RuleSig(RuleTableKind.DEC, rule);
                dst = CheckedRulePage(sig);
                if(dst.IsEmpty)
                {
                    sig = new RuleSig(RuleTableKind.ENC,rule);
                    dst = CheckedRulePage(sig);
                }
            }
            else
            {
                sig = new RuleSig(RuleTableKind.ENC,rule);
                dst = CheckedRulePage(sig);
                if(dst.IsEmpty)
                {
                    sig = new RuleSig(RuleTableKind.DEC,rule);
                    dst = CheckedRulePage(sig);
                }
            }
            return dst;
        }

        public FS.FilePath RuleSpecs()
            => RuleOutput() + FS.file("xed.rules.specs", FS.Csv);

        public FS.FolderPath InstTargets()
            => Output() + FS.folder("instructions");

        public FS.FilePath InstTable<T>()
            where T : struct
                => InstTargets() + Tables.filename<T>();

        public FS.FilePath InstTable<T>(string suffix)
            where T : struct
                => InstTargets() + Suffixed<T>(suffix);

        public FS.FilePath InstTarget(string name, FileKind kind)
            => InstTargets() + FS.file(string.Format("xed.inst.{0}", name), kind.Ext());

        public FS.FolderPath InstPageRoot()
            => InstTargets() + FS.folder("pages");

        public FS.FilePath InstPagePath(InstIsa src)
            => InstPageRoot() + FS.file(text.ifempty(src.Format(), "UNKNOWN"), FS.Txt);

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
            => RuleOutput() + FS.file("xed.rules." + name, ext);

        public FS.FilePath Target(string name, FS.FileExt ext)
            => Output() + FS.file(name, ext);

        public FS.FolderPath DocTargets()
            => Output() + FS.folder("docs");

        public FS.FilePath DocTarget(string name, FileKind kind)
            => DocTargets() + FS.file(string.Format("xed.docs.{0}", name), kind.Ext());

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


        public FS.FilePath SourcePath(string name, FileKind kind)
            => Sources() + FS.file(name,kind.Ext());

        public FS.FilePath CpuIdSource()
            => SourcePath("all-cpuid", FileKind.Txt);

        public FS.FilePath ChipModelSource()
            => SourcePath("all-chip-models", FileKind.Txt);

        public FS.FilePath ConversionSource()
            => SourcePath("all-conversion-table", FileKind.Txt);

        public FS.FilePath ChipMapSource()
            => SourcePath("xed-cdata", FileKind.Txt);

        public FS.FilePath FormSource()
            => SourcePath("xed-idata", FileKind.Txt);

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

        WsUnserviced Ws;

        XedPaths()
        {
            var data = AppData.get();
            var db = data.ProjectDb;
            State = new (db.Sources("intel/xed.primary"), db.Subdir("xed"));
            Ws = WsUnserviced.create();
        }

        static XedPaths Instance = new();
    }
}