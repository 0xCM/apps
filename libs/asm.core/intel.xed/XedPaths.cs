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

    public class XedPaths
    {
        public static XedPaths Service => Instance;

        static AppDb AppDb => GlobalSvc.Instance.AppDb;

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

        public DbTargets Targets()
            => new DbTargets(State.XedTargets);

        public DbTargets Targets(string scope)
            => new DbTargets(State.XedTargets, scope);

        public FS.FolderPath DbTargets()
            => Targets().Targets("db");

        public DbTargets Imports()
            => Targets("imports");

        public DbTargets RuleTargets()
            => Targets("rules");

        public DbTargets Refs()
            => Targets("refs");

        public DbTargets InstTargets()
            => Targets("instructions");

        public DbTargets InstPages()
            => InstTargets().Targets("pages");

        public DbTargets RulePages()
            => RuleTargets().Targets("pages");

        public FS.FilePath Table<T>()
            where T : struct
                => Targets().Table<T>();

        public FS.FilePath Table<T>(string suffix)
            where T : struct
                => Targets().Path(Suffixed<T>(suffix));

        public FS.FilePath RuleTable<T>()
            where T : struct
                => RuleTargets().Table<T>();

        public FS.FilePath FormCatalogPath()
            => Imports().Path(FS.file(Tables.identify<FormImport>().Format(), FS.Csv));

        static FS.FileName EncInstDef = FS.file("all-enc-instructions", FS.Txt);

        static FS.FileName DecInstDef = FS.file("all-dec-instructions", FS.Txt);

        static FS.FileName EncRuleTable = FS.file("all-enc-patterns", FS.Txt);

        static FS.FileName DecRuleTable = FS.file("all-dec-patterns", FS.Txt);

        static FS.FileName EncDecRuleTable = FS.file("all-enc-dec-patterns", FS.Txt);

        static FS.FileName Suffixed<T>(string suffix)
            where T : struct
                => Tables.filename<T>().ChangeExtension(FS.ext(string.Format("{0}.{1}", suffix, FS.Csv)));

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

        public FS.FolderPath DisasmTargets(IProjectWs project)
            => CmdFlows.data(project.Project, "xed.disasm");

        public FS.FilePath DisasmFieldsPath(IProjectWs project, in FileRef src)
            => DisasmTargets(project) + FS.file(string.Format("{0}.fields", src.Path.FileName.WithoutExtension), FS.Txt);

        public FS.FilePath DisasmChecksPath(IProjectWs project, in FileRef src)
            => DisasmTargets(project) + FS.file(string.Format("{0}.checks", src.Path.FileName.WithoutExtension), FS.Txt);

        public FS.FilePath DisasmOpsPath(IProjectWs project, in FileRef src)
            => DisasmTargets(project) + FS.file(string.Format("{0}.ops", src.Path.FileName.WithoutExtension.Format()), FS.Txt);

        public FS.FileUri RulePage(RuleSig sig)
            => RulePages().Path(FS.file(sig.Format(), FS.Csv));

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
            => RuleTargets().Path(FS.file("xed.rules.specs", FS.Csv));

        public FS.FilePath InstTable<T>()
            where T : struct
                => InstTargets().Path(Tables.filename<T>());

        public FS.FilePath InstTable<T>(string suffix)
            where T : struct
                => InstTargets().Path(Suffixed<T>(suffix));

        public FS.FilePath InstTarget(string name, FileKind kind)
            => InstTargets().Path(FS.file(string.Format("xed.inst.{0}", name), kind.Ext()));

        public FS.FilePath InstPagePath(InstIsa src)
            => InstPages().Path(FS.file(text.ifempty(src.Format(), "UNKNOWN"), FS.Txt));

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
            => RuleTargets().Path(FS.file("xed.rules." + name, ext));

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

        public FS.FilePath ChipMapSource()
            => SourcePath("xed-cdata", FileKind.Txt);

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


        XedPaths()
        {
            State = new (AppDb.ProjectSources("intel/xed.primary"), AppDb.ProjectTargets("xed"));
        }

        static XedPaths Instance = new();
    }
}