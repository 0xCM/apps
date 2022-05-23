//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;
    using static core;

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
                EmitBroadcastDefs,
                EmitChips,
                () => Emit(CalcFieldImports()),
                () => Emit(CalcPointerWidths()),
                () => Emit(XedOperands.Views.OpWidths)
            );
        }

       public Index<PointerWidthInfo> CalcPointerWidths()
            => Data(nameof(PointerWidthInfo), () => mapi(PointerWidths.Where(x => x.Kind != 0), (i,w) => w.ToRecord((byte)i)));

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

        void EmitFormImports()
            => Emit(Xed.Views.FormImports);

        public void Emit(ReadOnlySpan<FormImport> src)
            => AppSvc.TableEmit(src, Targets().Table<FormImport>());

        public void ImportInstBlocks()
            => BlockImporter.Import(Xed.Views.InstImports, PllExec);

        void Emit(ReadOnlySpan<FieldImport> src)
            => AppSvc.TableEmit(src, XedPaths.Imports().Table<FieldImport>());

        void Emit(ReadOnlySpan<PointerWidthInfo> src)
            => AppSvc.TableEmit(src, XedPaths.Imports().Table<PointerWidthInfo>());

        void Emit(ReadOnlySpan<OpWidthRecord> src)
            => AppSvc.TableEmit(src, XedPaths.Imports().Table<OpWidthRecord>());

        void EmitChips()
            => AppSvc.TableEmit(SymServices.kindrows<ChipCode>(), Targets().Path("xed.chips", FileKind.Csv));

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

            AppSvc.FileEmit(dst.Emit(), counter, Targets().Path(FS.file("xed.chipmap", FS.Csv)));
        }

        public void EmitIsaForms()
        {
            var codes = Symbols.index<ChipCode>();
            var forms = Xed.Views.FormImports;
            var map = Xed.Views.ChipMap;
            var formisa = forms.Select(x => (x.InstForm.Kind, x.IsaKind)).ToDictionary();
            var isakinds = formisa.Values.ToHashSet();
            var isaforms = cdict<InstIsaKind,HashSet<FormImport>>();
            iter(isakinds, k => isaforms[k] = new());
            iter(forms, f => isaforms[f.IsaKind].Add(f));
            iter(codes.Kinds, chip => {
                var kinds = map[chip];
                var dst = Targets("isaforms").Path(FS.file(string.Format("xed.isa.{0}", chip), FS.Csv));
                var matches = bag<FormImport>();
                iter(kinds, k => {
                    if(isaforms.TryGetValue(k, out var forms))
                        matches.AddRange(forms);
                    });
                AppSvc.TableEmit(matches.ToArray().Sort().Resequence(), dst);
            },PllExec);
        }

        static Index<InstBlockField> _BlockFields;

        static Symbols<VisibilityKind> Visibilities;

        static Symbols<XedFieldType> FieldTypes;

        static Symbols<PointerWidthKind> PointerWidthKinds;

        static Index<PointerWidth> PointerWidths;

        static XedImport()
        {
            _BlockFields = Symbols.index<InstBlockField>().Kinds.ToArray();
            PointerWidthKinds = Symbols.index<PointerWidthKind>();
            PointerWidths = map(PointerWidthKinds.View, s => (PointerWidth)s.Kind);
            Visibilities = Symbols.index<VisibilityKind>();
            FieldTypes = Symbols.index<XedFieldType>();
        }
    }
}