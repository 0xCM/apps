//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ApiServices : AppService<ApiServices>
    {
        AppDb AppDb
            => Service(Wf.AppDb);

        public ApiComments Comments => Service(Wf.ApiComments);

        public ApiAssets Assets => Service(Wf.ApiAssets);

        public BitMaskServices ApiBitMasks => Service(Wf.ApiBitMasks);

        public Symbolism Symbolism => Service(Wf.Symbolism);

        public Index<CompilationLiteral> ApiLiterals()
            => Data(nameof(ApiLiterals), () => LiteralProvider.CompilationLiterals(ApiRuntimeCatalog.Components));

        public void EmitSymHeap()
            => Symbolism.EmitSymHeap();

        public void EmitBitMasks()
            => ApiBitMasks.Emit();

        public void EmitComments()
            => Comments.Collect();

        public void EmitApiLiterals()
            => TableEmit(ApiLiterals().View, ProjectDb.ApiTablePath<CompilationLiteral>());

        public void EmitApiMd()
            => Comments.EmitMarkdownDocs(new string[]{
                nameof(vpack),
                nameof(vmask),
                nameof(cpu),
                nameof(gcpu),
                nameof(BitMasks),
                nameof(BitMaskLiterals),
                });

        public void EmitDataTypes()
            => TableEmit(DataTypes.records(ApiRuntimeCatalog.Components).View, DataTypeRecord.RenderWidths, Ws.ProjectDb().Api() + Tables.filename<DataTypeRecord>());

        public void EmitDataFlows()
        {
            var src = ApiDataFlow.discover(ApiRuntimeCatalog.Components);
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

            TableEmit(@readonly(buffer.Sort()), ApiFlowSpec.RenderWidths, ProjectDb.ApiTablePath<ApiFlowSpec>());
        }

        public FS.FilePath EmitEnumList()
        {
            var dst = AppDb.Api().Path("api.enums.types", FileKind.List);
            var src = ApiRuntimeCatalog.Components
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