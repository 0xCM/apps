//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static XedModels.ChipCode;
    using static core;
    using Asm;

    public partial class XedImport : AppService<XedImport>
    {
        XedPaths XedPaths => Service(Wf.XedPaths);

        AppServices AppSvc => Service(Wf.AppServices);

        AppDb AppDb => Service(Wf.AppDb);

        DbTargets Targets() => XedPaths.Imports();

        DbTargets Targets(string scope) => Targets().Targets(scope);

        InstBlockImporter BlockImporter => Service(() => new InstBlockImporter(AppSvc));

        XedRuntime Xed;

        bool PllExec
        {
            [MethodImpl(Inline)]
            get => Xed.PllExec;
        }

        public XedImport With(XedRuntime xed)
        {
            Xed = xed;
            return this;
        }

        public void Run()
        {
            exec(PllExec,
                ImportInstBlocks,
                EmitChipMap,
                EmitFormImports,
                EmitIsaForms,
                EmitIsaImports,
                EmitCpuIdImports,
                EmitBroadcastDefs
            );
        }

        public InstImportBlocks CalcInstImports()
            => BlockImporter.CalcImports();

        public CpuIdImporter.Output CalcCpuIdImports()
            => CpuIdImporter.calc();

        public Index<FormImport> CalcFormImports()
            => FormImporter.calc(XedPaths.DocSource(XedDocKind.FormData));

        void EmitBroadcastDefs()
            => AppSvc.TableEmit(XedOperands.Views.BroadcastDefs, Targets().Table<BroadcastDef>());

        void EmitIsaImports()
            => AppSvc.TableEmit(Xed.Views.IsaImport, Targets().Table<IsaImport>());

        void EmitCpuIdImports()
            => AppSvc.TableEmit(Xed.Views.CpuIdImport, Targets().Table<CpuIdImport>());

        public static ref readonly Index<InstBlockField> BlockFields
        {
            [MethodImpl(Inline)]
            get => ref _BlockFields;
        }

        void EmitFormImports()
            => Emit(Xed.Views.FormImports);

        public void Emit(ReadOnlySpan<FormImport> src)
            => AppSvc.TableEmit(src, Targets().Table<FormImport>());

        public void ImportInstBlocks()
            => BlockImporter.Import(Xed.Views.InstImports);

        FS.FilePath ChipMapTarget()
            => Targets().Path(FS.file("xed.chipmap", FS.Csv));

        public void EmitChipMap()
        {
            const string RowFormat = "{0,-12} | {1,-24} | {2}";
            var map = Xed.Views.ChipMap;
            var dst = text.emitter();
            var counter = 0u;
            dst.WriteLine(string.Format(RowFormat, "Sequence", "ChipCode", "Isa"));
            var codes = map.Codes;
            foreach(var code in codes)
            {
                var mapped = map[code];
                foreach(var kind in mapped)
                    dst.WriteLine(string.Format(RowFormat, counter++ , code, kind));
            }
            AppSvc.FileEmit(dst.Emit(),counter, ChipMapTarget());
        }

        public void EmitIsaForms()
        {
            var codes = new ChipCode[]{
                I86,
                I186,
                I286,
                I386,
                I486,
                PENTIUM,
                PENTIUM2,
                PENTIUM3,
                PENTIUM4,
                PENRYN,
                NEHALEM,
                P4PRESCOTT,
                IVYBRIDGE,
                BROADWELL,
                SKYLAKE,
                SKYLAKE_SERVER,
                TIGER_LAKE,
                CASCADE_LAKE,
                KNL,
                SAPPHIRE_RAPIDS
                };

            EmitIsaForms(codes);
        }

        public void EmitIsaForms(ReadOnlySpan<ChipCode> codes)
        {
            var map = Xed.Views.ChipMap;
            iter(codes, code => EmitIsaForms(map, code), PllExec);
        }

        FS.FilePath IsaTarget(ChipCode chip)
            => Targets("isaforms").Path(FS.file(string.Format("xed.isa.{0}", chip), FS.Csv));

        void EmitIsaForms(ChipMap map, ChipCode chip)
        {
            var forms = Xed.Views.FormImports;
            var kinds = map[chip].ToHashSet();
            var matches = list<FormImport>();
            var count = forms.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref forms[i];
                if(kinds.Contains(form.IsaKind))
                    matches.Add(form);
            }

            AppSvc.TableEmit(matches.ToArray().Sort().Resequence(), IsaTarget(chip));
        }

        static Index<InstBlockField> _BlockFields;

        static XedImport()
        {
            _BlockFields = Symbols.index<InstBlockField>().Kinds.ToArray();
        }
    }
}