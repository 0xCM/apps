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

    partial class XTend
    {
        public static void AddRange<T>(this HashSet<T> dst, HashSet<T> src)
        {
            foreach(var item in src)
                dst.Add(item);
        }

        public static void AddRange<T>(this ConcurrentBag<T> dst, HashSet<T> src)
        {
            foreach(var item in src)
                dst.Add(item);
        }
    }

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
                () => Emit(CalcFieldDefs()),
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

        void Emit(ReadOnlySpan<XedFieldDef> src)
            => AppSvc.TableEmit(src, XedPaths.Imports().Table<XedFieldDef>());

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

        // public ConcurrentDictionary<InstIsaKind,HashSet<FormImport>> CalcIsaFormImports()
        // {
        //     var codes = Symbols.index<ChipCode>();
        //     var forms = Xed.Views.FormImports;
        //     var formisa = forms.Select(x => (x.InstForm.Kind, x.IsaKind)).ToDictionary();
        //     var isakinds = formisa.Values.ToHashSet();
        //     var isaforms = cdict<InstIsaKind,HashSet<FormImport>>();
        //     var lookup = cdict<ChipCode,HashSet<FormImport>>();
        //     iter(isakinds, k => isaforms[k] = new());
        //     iter(codes.Kinds, code => lookup[code] = new());
        //     iter(forms, f => isaforms[f.IsaKind].Add(f));
        //     return isaforms;
        // }

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

        public Index<XedFieldDef> CalcFieldDefs()
        {
            var src = XedPaths.DocSource(XedDocKind.Fields);
            var dst = list<XedFieldDef>();
            var result = Outcome.Success;
            var line = EmptyString;
            var lines = src.ReadLines().Reader();
            while(lines.Next(out line))
            {
                var content = line.Trim();
                if(text.empty(content) || text.begins(content,Chars.Hash))
                    continue;

                var cells = text.split(text.despace(content), Chars.Space).Reader();
                var record = XedFieldDef.Empty;
                record.Name = cells.Next();

                cells.Next();
                result = FieldTypes.ExprKind(cells.Next(), out XedFieldType ft);
                if(result.Fail)
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(record.FieldType), cells.Prior()));
                else
                    record.FieldType = ft;

                result = DataParser.parse(cells.Next(), out record.Width);
                if(result.Fail)
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(record.Width), cells.Prior()));

                if(!Visibilities.ExprKind(cells.Next(), out record.Visibility))
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(record.Visibility), cells.Prior()));

                dst.Add(record);
            }

            return dst.ToArray().Sort();
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