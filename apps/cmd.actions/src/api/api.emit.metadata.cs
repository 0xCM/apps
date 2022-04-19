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
            EmitApiComments();
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
            EmitTableReport();
            EmitApiDataTypes();
            EmitApiClasses();
            EmitBitmasks();
            EmitSymHeap();
            EmitApiTokens();
            EmitApiLiterals();
            EmitApiCommands();
            EmitDataFlowSpecs();
        }

        ApiAssets ApiAssets => Service(Wf.ApiAssets);

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