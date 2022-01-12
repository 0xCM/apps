//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/metadata")]
        Outcome EmitApiMetadata(CmdArgs args)
        {
            var result = Outcome.Success;
            EmitBitmasks();
            EmitApiClasses();
            EmitCliMetadata();
            EmitApiComments();
            EmitApiDataTypes();
            EmitSymHeap();
            EmitApiTokens();
            EmitTableReport();
            return result;
        }

        void EmitTableReport()
            => ApiCatalogs.EmitTableDefs();

        void EmitApiDataTypes()
            => TableEmit(ApiRuntimeCatalog.ApiDataTypes, ApiDataType.RenderWidths, ProjectDb.ApiTablePath<ApiDataType>());

        void EmitApiComments()
            => ApiComments.Collect();

        void EmitApiClasses()
            => ApiCatalogs.EmitApiClasses();

        void EmitBitmasks()
            => ApiBitmasks.Emit();

        void EmitCliMetadata()
            => CliEmitter.EmitMetadaSets(WorkflowOptions.@default());

        void EmitSymHeap()
            => Symbolism.EmitSymHeap();

        void EmitApiTokens()
            => ApiMetadata.EmitApiTokens();

        void EmitApiLiterals()
            => TableEmit(ApiLiterals().View, ProjectDb.ApiTablePath<CompilationLiteral>());
    }
}