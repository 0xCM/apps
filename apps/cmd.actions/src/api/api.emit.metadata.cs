//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;

    using System;


    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/metadata")]
        Outcome EmitApiMetadata(CmdArgs args)
        {
            var result = Outcome.Success;
            EmitCliMetadata();
            ApiEmitters.EmitApiComments();
            EmitApiInfo();
            return result;
        }

        [CmdOp("api/emit/info")]
        Outcome EmitApiInfo(CmdArgs args)
        {
            EmitApiInfo();
            return true;
        }

        ApiEmitters ApiEmitters => Service(Wf.ApiEmitters);

        void EmitApiInfo()
        {
            EmitTableReport();
            EmitApiDataTypes();
            EmitApiClasses();
            EmitBitmasks();
            ApiEmitters.EmitSymHeap();
            EmitApiTokens();
            ApiEmitters.EmitApiLiterals();
            EmitApiCommands();
            ApiEmitters.EmitDataFlowSpecs();
        }

        void EmitTableReport()
            => ApiCatalogs.EmitTableDefs();

        void EmitApiDataTypes()
            => TableEmit(DataTypes.records(ApiRuntimeCatalog.Components).View, DataTypeRecord.RenderWidths, Ws.Api().TablePath<DataTypeRecord>());

        void EmitApiComments()
            => ApiComments.Collect();

        void EmitApiClasses()
            => ApiCatalogs.EmitApiClasses();

        void EmitBitmasks()
            => ApiBitmasks.Emit();

        void EmitCliMetadata()
            => CliEmitter.EmitMetadaSets(WorkflowOptions.@default());

        void EmitApiTokens()
            => ApiMetadata.EmitApiTokens();

        void EmitApiCommands()
        {
            var types = Cmd.types(ApiRuntimeCatalog.Components);
            var buffer = list<ApiCmdRow>();
            foreach(var type in types)
            {
                var name = type.Tag<CmdAttribute>().Require().Name;
                var cmdargs = type.DeclaredInstanceFields();
                var instance = Activator.CreateInstance(type);
                var values = ClrFields.values(instance);
                foreach(var arg in cmdargs)
                {
                    var cmdarg = new ApiCmdRow();
                    cmdarg.CmdName = name;
                    cmdarg.CmdType = type.Name;
                    cmdarg.ArgName = arg.Name;
                    cmdarg.DataType = TypeSyntax.infer(arg.FieldType);
                    cmdarg.Expression = arg.Tag<CmdArgAttribute>().MapValueOrDefault(x => x.Expression, EmptyString);
                    cmdarg.DefaultValue = values[arg.Name].Value?.ToString() ?? EmptyString;
                    buffer.Add(cmdarg);
                }
            }
            TableEmit(buffer.ViewDeposited(), ApiCmdRow.RenderWidths, ProjectDb.ApiTablePath<ApiCmdRow>());
        }
    }
}