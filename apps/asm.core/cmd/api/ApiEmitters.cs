//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using L = LiteralProvider;

    using static core;

    public class ApiEmitters : AppService<ApiEmitters>
    {
        Index<CompilationLiteral> ApiLiterals()
            => Data(nameof(ApiLiterals), () => L.CompilationLiterals(ApiRuntimeCatalog.Components));

        AppDb AppDb
            => Service(Wf.AppDb);

        Symbolism Symbolism => Service(Wf.Symbolism);

        ApiComments ApiComments => Service(Wf.ApiComments);

        BitMaskServices ApiBitMasks => Service(Wf.ApiBitMasks);

        AsmDocs AsmDocs => Service(Wf.AsmDocs);

        public void EmitDataTypes()
            => TableEmit(DataTypes.records(ApiRuntimeCatalog.Components).View, DataTypeRecord.RenderWidths, Ws.ProjectDb().Api() + Tables.filename<DataTypeRecord>());

        public void EmitApiMd()
            => ApiComments.EmitMarkdownDocs(new string[]{
                nameof(vpack),
                nameof(vmask),
                nameof(cpu),
                nameof(gcpu),
                nameof(BitMasks),
                nameof(BitMaskLiterals),
                });

        public void EmitAsmDocs()
            => AsmDocs.Emit();

        public void EmitBitMasks()
            => ApiBitMasks.Emit();

        public void EmitApiComments()
            => ApiComments.Collect();

        public void EmitApiLiterals()
            => TableEmit(ApiLiterals().View, ProjectDb.ApiTablePath<CompilationLiteral>());

        public void EmitSymHeap()
            => Symbolism.EmitSymHeap();

        public void EmitDataFlowSpecs()
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