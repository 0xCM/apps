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

        void EmitBroadcastDefs()
            => TableEmit(XedOperands.Views.BroadcastDefs, BroadcastDef.RenderWidths, XedPaths.Table<BroadcastDef>());

        void EmitIsaImports()
            => Emit(Xed.Views.IsaImport);

        void EmitCpuIdImports()
            => Emit(Xed.Views.CpuIdImport);

        void Emit(Index<CpuIdImport> src)
            => AppSvc.TableEmit(src, XedPaths.RefTable<CpuIdImport>());

        void Emit(Index<IsaImport> src)
            => AppSvc.TableEmit(src, XedPaths.RefTable<IsaImport>());

        public static ref readonly Index<BlockField> BlockFields
        {
            [MethodImpl(Inline)]
            get => ref _BlockFields;
        }

        void EmitFormImports()
            => AppSvc.TableEmit(Xed.Views.FormImports, XedPaths.FormCatalogPath());

        public void Emit(ReadOnlySpan<FormImport> src)
            => AppSvc.TableEmit(src, XedPaths.FormCatalogPath());

        public void ImportInstBlocks()
        {
            using var importer = new InstBlockImporter(AppSvc);
            importer.Run();
        }

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
            AppSvc.FileEmit(dst.Emit(),counter,XedPaths.ChipMapTarget());
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

        void EmitIsaForms(ChipMap map, ChipCode code)
        {
            var forms = Xed.Views.FormImports;
            var kinds = map[code].ToHashSet();
            var matches = list<FormImport>();
            var count = forms.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref forms[i];
                if(kinds.Contains(form.IsaKind))
                    matches.Add(form);
            }

            AppSvc.TableEmit(matches.ToArray().Sort().Resequence(), XedPaths.Service.IsaFormsPath(code));
        }

        static Index<BlockField> _BlockFields;

        static XedImport()
        {
            _BlockFields = Symbols.index<BlockField>().Kinds.ToArray();
        }
    }
}