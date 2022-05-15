//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ApiServices : AppService<ApiServices>
    {
        AppDb AppDb => Service(Wf.AppDb);

        AppServices AppSvc => Service(Wf.AppServices);

        Index<Assembly> _ApiParts;

        protected override void Initialized()
        {
            _ApiParts = ApiRuntimeCatalog.Components;
        }

        public ApiComments Comments => Service(Wf.ApiComments);

        public ApiAssets Assets => Service(Wf.ApiAssets);

        public BitMaskServices ApiBitMasks => Service(Wf.ApiBitMasks);

        public Symbolism Symbolism => Service(Wf.Symbolism);

        public ref readonly Index<Assembly> ApiParts
        {
            [MethodImpl(Inline)]
            get => ref _ApiParts;
        }

        public Index<SymLiteralRow> CalcSymLits()
            => Data(nameof(CalcSymLits), ()=> Symbols.literals(ApiParts));

        public SymHeap CalcSymHeap(Index<SymLiteralRow> src)
            => SymHeaps.define(src);

        public Index<CompilationLiteral> CalcCompilationLits()
            => Data(nameof(CalcCompilationLits), () => LiteralProvider.CompilationLiterals(ApiParts));

        public Index<DataTypeRecord> CalcDataTypes()
            => DataTypes.records(ApiParts);

        public Index<ApiFlowSpec> CalcDataFlows()
        {
            var src = ApiDataFlow.discover(ApiParts);
            var count = src.Length;
            var buffer = alloc<ApiFlowSpec>(count);
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var flow = ref src[i];
                dst.Actor = flow.Actor.Name;
                dst.Source = flow.Source?.ToString() ?? EmptyString;
                dst.Target = flow.Target?.ToString() ?? EmptyString;
                dst.Description = flow.Format();
            }
            return buffer.Sort();
        }

        public Index<SymHeapEntry> CalcHeapEntries(SymHeap src)
            => SymHeaps.entries(src);

        public void Emit(SymHeap src)
            => AppSvc.TableEmit(CalcHeapEntries(src), AppDb.ApiTargets().Table<SymHeapEntry>());

        public void EmitBitMasks()
            => ApiBitMasks.Emit();

        public void EmitComments()
            => Comments.Collect();

        public void EmitApiMd()
            => Comments.EmitMarkdownDocs(new string[]{
                nameof(vpack),
                nameof(vmask),
                nameof(cpu),
                nameof(gcpu),
                nameof(BitMasks),
                nameof(BitMaskLiterals),
                });

        public ReadOnlySpan<SymLiteralRow> EmitSymLiterals<E>(FS.FilePath dst)
            where E : unmanaged, Enum
                => Service(Wf.Symbolism).EmitLiterals<E>(dst);

        public void Emit(ReadOnlySpan<SymLiteralRow> src)
            => AppSvc.TableEmit(src, AppDb.ApiTargets().Table<SymLiteralRow>());

        public void Emit(ReadOnlySpan<CompilationLiteral> src)
            => AppSvc.TableEmit(src, AppDb.ApiTargets().Table<CompilationLiteral>());

        public void Emit(ReadOnlySpan<DataTypeRecord> src)
            => AppSvc.TableEmit(src, AppDb.ApiTargets().Table<DataTypeRecord>());

        public void Emit(ReadOnlySpan<ApiFlowSpec> src)
            => AppSvc.TableEmit(src, AppDb.ApiTargets().Table<ApiFlowSpec>());

        Index<ClrEnumRecord> CalcEnumRecords(Assembly src)
            => Enums.records(src);

        void Emit(ReadOnlySpan<ClrEnumRecord> src)
            => TableEmit(src, AppDb.ApiTargets().Table<ClrEnumRecord>());

        public FS.FilePath EmitEnumList()
        {
            var dst = AppDb.ApiTargets().Path("api.enums.types", FileKind.List);
            var src = ApiParts
                .Where(x => !x.FullName.Contains("codegen."))
                .Storage.Enums()
                .Where(x => x.ContainsGenericParameters == false && nonempty(x.Namespace));
            var emitting = EmittingFile(dst);
            var count = src.Length;
            using var writer = dst.Utf8Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(src,i).AssemblyQualifiedName);
            EmittedFile(emitting,count);
            return dst;
        }
    }
}