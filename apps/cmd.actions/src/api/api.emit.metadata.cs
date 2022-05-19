//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmd
    {
        [CmdOp("api/emit")]
        Outcome ApiEmit(CmdArgs args)
        {
            Wf.ApiEmitters().Emit();
            return true;
        }

        [CmdOp("api/emit/metadata")]
        Outcome EmitApiMetadata(CmdArgs args)
        {
            var result = Outcome.Success;
            EmitCliMetadata();
            EmitApiInfo();
            return result;
        }

        [CmdOp("api/emit/info")]
        Outcome EmitApiInfo(CmdArgs args)
        {
            EmitApiInfo();
            return true;
        }

        void EmitApiInfo()
        {
            Wf.ApiEmitters().Emit();
            EmitApiClasses();
            EmitApiTokens();
        }

        void EmitTableReport()
            => ApiCatalogs.EmitTableDefs();

        void EmitApiDataTypes()
            => TableEmit(DataTypes.records(ApiRuntimeCatalog.Components).View, DataTypeRecord.RenderWidths, Ws.Api().TablePath<DataTypeRecord>());

        void EmitApiComments()
            => ApiComments.Collect();

        void EmitApiClasses()
            => ApiCatalogs.EmitApiClasses();

        void EmitCliMetadata()
            => CliEmitter.EmitMetadaSets(WorkflowOptions.@default());

        void EmitApiTokens()
            => ApiMetadata.EmitApiTokens();
    }
}